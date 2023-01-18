using InventarioGEI.Controllers;
using InventarioGEI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InventarioGEITests
{
    public class FuenteEmisionControllerTest
    {
        public FuenteEmisionsController controller;
        public Context _dbContext;

        [SetUp]
        public void Setup()
        {
            var rol = new Rol { idRol = 1, nombreRol = "Rol1test", permisoConfiguracion = true, permisoRol = true, enabled = true };
            var userTest = new Usuario { idUsuario = 1, email = "adminTest@admin.com", idRol = 1, enabled = true };

            var fuenteToEdit = new FuenteEmision {idFuenteEmision = 5, nombreFuenteEmision = "fuente", enabled = true, usuario = userTest };


            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseInMemoryDatabase("DBTest");
            _dbContext = new Context(optionsBuilder.Options);
            _dbContext.Rol.Add(rol);
            _dbContext.FuenteEmision.Add(fuenteToEdit);
            _dbContext.Usuario.Add(userTest);
            _dbContext.SaveChangesAsync();
            controller = new FuenteEmisionsController(_dbContext);
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
            Assert.Greater(((IEnumerable<FuenteEmision>)viewResult.Model).Count(), 0);
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
            var fuente = new FuenteEmision { idFuenteEmision = 2, nombreFuenteEmision = "fuente", enabled = true };

            var result = await controller.Create(fuente);
            var redirectResult = result as RedirectToActionResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", redirectResult.ActionName);
        }

        [Test]
        public async Task TestCreateIncorrect()
        {
            var fuente = new FuenteEmision { idFuenteEmision = 8, enabled = true };
            controller.ModelState.AddModelError("nombreCombustible", "Es necesario un nombre para el combustible");

            var result = await controller.Create(fuente);
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
            _dbContext.Entry(_dbContext.FuenteEmision.Find(5)).State = EntityState.Detached;
            var fuenteEdited = new FuenteEmision { idFuenteEmision = 5, nombreFuenteEmision = "fuente", enabled = true };
            var result = await controller.Edit(5, fuenteEdited);

            var redirectResult = result as RedirectToActionResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", redirectResult.ActionName);
        }

        [Test]
        public async Task TestEditIncorrect()
        {
            var fuente = new FuenteEmision { idFuenteEmision = 5, enabled = true };
            controller.ModelState.AddModelError("nombreAlcance", "Es necesario un nombre para el alcance");

            var result = await controller.Edit(5, fuente);
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
            _dbContext.Entry(_dbContext.FuenteEmision.Find(5)).State = EntityState.Detached;
            var result = await controller.DeleteConfirmed(5);

            var redirectResult = result as RedirectToActionResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", redirectResult.ActionName);
        }
    }
}
