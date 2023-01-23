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
    public class RolControllerTest
    {
        public RolsController controller;
        public Context _dbContext;
        [SetUp]
        public void Setup()
        {
            var rol = new Rol {idRol = 1, nombreRol = "Rol1test", permisoConfiguracion = true, permisoRol = true, enabled=true};
            var rolToEdit = new Rol {idRol = 5, nombreRol = "RolEdit", permisoConfiguracion = true, permisoRol = true, permisoRegistro=false ,enabled=true};

            var userTest = new Usuario {idUsuario = 1, email = "adminTest@admin.com", idRol=1, enabled=true};

            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseInMemoryDatabase("DBTest");
            _dbContext = new Context(optionsBuilder.Options);
            _dbContext.Rol.Add(rol);
            _dbContext.Rol.Add(rolToEdit);
            _dbContext.Usuario.Add(userTest);
            _dbContext.SaveChangesAsync();
            controller = new RolsController(_dbContext);
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                            {
                                new Claim(ClaimTypes.Name, "adminTest@admin.com"),

                            }, "mock"));
            controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = user };
        }

        [TearDown]
        public void TearDown()
        {
            // Limpia el contexto de la base de datos despu�s de cada ejecuci�n de pruebas
            _dbContext.Rol.RemoveRange(_dbContext.Rol);
            //_dbContext.Usuario.RemoveRange(_dbContext.Usuario);
            _dbContext.SaveChanges();
        }

        [Test]
        public async Task TestIndexView()
        {
            var result = await controller.Index();
            var viewResult = result as ViewResult;

            Assert.IsNotNull(viewResult);
            Assert.Greater(((IEnumerable<Rol>)viewResult.Model).Count(), 0);
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
            var rol = new Rol { idRol = 2, nombreRol = "Rol2test", permisoConfiguracion = true, permisoRol = true, enabled = true };

            var result = await controller.Create(rol);
            var redirectResult = result as RedirectToActionResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", redirectResult.ActionName);
        }

        [Test]
        public async Task TestCreateIncorrect()
        {
            var rol = new Rol {permisoConfiguracion = true, permisoRol = true, enabled = true };
            controller.ModelState.AddModelError("nombreRol", "Es necesario un nombre para el rol");

            var result = await controller.Create(rol);
            var redirectResult = result as RedirectToActionResult;

            Assert.IsNotNull(result);
            Assert.IsNull(redirectResult);
        }

        [Test]
        public async Task TestEditView()
        {
            var result = await controller.Edit(5);
            var viewResult = result as ViewResult;

            Assert.IsNotNull(viewResult);
        }

        [Test]
        public async Task TestEditAnIDDoesntExist()
        {
            var result = await controller.Edit(76);
            
            Assert.AreEqual(404, ((NotFoundResult)result).StatusCode);
        }

        [Test]
        public async Task TestEditCorrect()
        {
            _dbContext.Entry(_dbContext.Rol.Find(5)).State = EntityState.Detached;
            var rolEdited = new Rol { idRol = 5, nombreRol = "RolEditado", permisoConfiguracion = true, permisoRol = true, permisoRegistro = false, enabled = true };
            var result = await controller.Edit(5, rolEdited);

            var redirectResult = result as RedirectToActionResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", redirectResult.ActionName);
        }

        [Test]
        public async Task TestEditIncorrect()
        {
            var rol = new Rol { idRol = 5, permisoConfiguracion = true, permisoRol = true, permisoRegistro = false, enabled = true };
            controller.ModelState.AddModelError("nombreRol", "Es necesario un nombre para el rol");

            var result = await controller.Edit(5, rol);
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
            _dbContext.Entry(_dbContext.Rol.Find(5)).State = EntityState.Detached;
            var result = await controller.DeleteConfirmed(5);

            var redirectResult = result as RedirectToActionResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", redirectResult.ActionName);
        }

    }
}