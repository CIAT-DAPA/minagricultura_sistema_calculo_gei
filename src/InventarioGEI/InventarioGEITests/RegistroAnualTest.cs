using InventarioGEI.Controllers;
using InventarioGEI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Moq;
using System.Net.Sockets;
using System.Security.Claims;

namespace InventarioGEITests
{
    public class RegistroAnualTest
    {
        public RegistroAnualsController controller;
        public Context _dbContext;
        [SetUp]
        public void Setup()
        {

            var rol = new Rol { idRol = 1, nombreRol = "Rol1test", permisoConfiguracion = true, permisoRol = true, permisoRegistro=true, enabled = true };
            var userTest = new Usuario { idUsuario = 1, email = "adminTest@admin.com", idRol = 1, enabled = true };
            var municipio = new Municipio {codigoMunicipio=1, nombreMunicipio="muni" };
            var sede = new Sede { idSede = 1, nombreSede = "sede", direccion="dir", enabled=true, municipio=municipio  };
            var regAnuToEdit = new RegistroAnual { idRegistroAnual = 5, fechaRegistro = DateTime.Now, año = 2006, sede = sede, estado = true, user=userTest };

            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseInMemoryDatabase("DBTest");
            _dbContext = new Context(optionsBuilder.Options);
            _dbContext.Rol.Add(rol);
            _dbContext.Usuario.Add(userTest);
            _dbContext.Add(regAnuToEdit);
            _dbContext.SaveChangesAsync();
            controller = new RegistroAnualsController(_dbContext);
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                            {
                                new Claim(ClaimTypes.Name, "adminTest@admin.com"),

                            }, "mock"));
            controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = user };
        }

        [Test]
        public async Task TestIndexView()
        {
            var result = await controller.Index();
            var viewResult = result as ViewResult;

            Assert.IsNotNull(viewResult);
            Assert.Greater(((IEnumerable<RegistroAnual>)viewResult.Model).Count(), 0);
        }

        [Test]
        public async Task TestCreateView()
        {
            var result = controller.Create();
            var viewResult = result as ViewResult;

            Assert.IsNotNull(viewResult);
        }

        [Test]
        public async Task TestCreateCorrect()
        {
            var regAnu = new RegistroAnual { idRegistroAnual = 2, fechaRegistro = DateTime.UtcNow, año = 2007, estado = true };

            var result = await controller.Create(regAnu);
            var redirectResult = result as RedirectToActionResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", redirectResult.ActionName);
        }

        [Test]
        public async Task TestCreateIncorrect()
        {
            var regAnu = new RegistroAnual { idRegistroAnual = 2, estado = true };
            controller.ModelState.AddModelError("nombreRol", "Es necesario un nombre para el rol");

            var result = await controller.Create(regAnu);
            var redirectResult = result as RedirectToActionResult;

            Assert.IsNotNull(result);
            Assert.IsNull(redirectResult);
        }

        [Test]
        public async Task TestDeleteView()
        {
            var result = await controller.Delete(5);
            var viewResult = result as ViewResult;

            Assert.IsNotNull(viewResult);
        }

        [Test]
        public async Task TestDeleteAnIDDoesntExist()
        {
            var result = await controller.Delete(76);

            Assert.AreEqual(404, ((NotFoundResult)result).StatusCode);
        }

        [Test]
        public async Task TestDelete()
        {
            _dbContext.Entry(_dbContext.RegistroAnual.Find(5)).State = EntityState.Detached;
            var result = await controller.DeleteConfirmed(5);

            var redirectResult = result as RedirectToActionResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", redirectResult.ActionName);
        }
    }
}
