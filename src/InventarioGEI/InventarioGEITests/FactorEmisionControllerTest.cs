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
    public class FactorEmisionControllerTest
    {
        public FactorEmisionsController controller;
        public Context _dbContext;

        [SetUp]
        public void Setup()
        {
            var rol = new Rol { idRol = 1, nombreRol = "Rol1test", permisoConfiguracion = true, permisoRol = true, enabled = true };
            var userTest = new Usuario { idUsuario = 1, email = "adminTest@admin.com", idRol = 1, enabled = true };
            var unidad = new Unidad {idUnidad=1, unidad="unidad" };
            var combustible = new Combustible { idCombustible = 1, nombreCombustible = "combustible", unidad=unidad};
            var subcategoria = new Subcategoria { idSubcategoria = 1, nombreSubcategoria = "subcategoria" };
            var fuenteEmision = new FuenteEmision { idFuenteEmision = 1, nombreFuenteEmision = "fuente" };
            var conf = new ConfiguracionActividad { idConfiguracion = 5, biocombustible = true, combustible = combustible, subcategoria = subcategoria, fuenteEmision = fuenteEmision, enabled = true};
            var gei = new GEI { idGei= 1, nombreGei="gei" };

            var factorToEdit = new FactorEmision { idFE = 5, factorEmision = 43, PCG = 34, incertidumbreMas=2, incertidumbreMenos= 4, configuracion=conf, gei= gei , enabled = true, usuario = userTest };


            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseInMemoryDatabase("DBTest");
            _dbContext = new Context(optionsBuilder.Options);
            _dbContext.Rol.Add(rol);
            _dbContext.FactorEmision.Add(factorToEdit);
            _dbContext.Usuario.Add(userTest);
            _dbContext.SaveChangesAsync();
            controller = new FactorEmisionsController(_dbContext);
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                            {
                                new Claim(ClaimTypes.Name, "adminTest@admin.com"),

                            }, "mock"));
            controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = user };
        }

        [TearDown]
        public void TearDown()
        {
            // Limpia el contexto de la base de datos después de cada ejecución de pruebas
            _dbContext.Rol.RemoveRange(_dbContext.Rol);
            _dbContext.Unidad.RemoveRange(_dbContext.Unidad);
            //_dbContext.Combustible.RemoveRange(_dbContext.Combustible);
            _dbContext.Subcategoria.RemoveRange(_dbContext.Subcategoria);
            _dbContext.FuenteEmision.RemoveRange(_dbContext.FuenteEmision);
            //_dbContext.ConfiguracionActividad.RemoveRange(_dbContext.ConfiguracionActividad);
            _dbContext.Gei.RemoveRange(_dbContext.Gei);
            //_dbContext.FactorEmision.RemoveRange(_dbContext.FactorEmision);
            //_dbContext.Usuario.RemoveRange(_dbContext.Usuario);
            _dbContext.SaveChanges();
        }

        [Test]
        public async Task TestIndexView()
        {
            var result = await controller.Index();
            var viewResult = result as ViewResult;

            Assert.IsNotNull(viewResult);
            Assert.Greater(((IEnumerable<FactorEmision>)viewResult.Model).Count(), 0);
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
            var factor = new FactorEmision { idFE = 2, PCG = 32, factorEmision=32, incertidumbreMas=3, incertidumbreMenos=2, enabled = true };

            var result = await controller.Create(factor);
            var redirectResult = result as RedirectToActionResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", redirectResult.ActionName);
        }

        [Test]
        public async Task TestCreateIncorrect()
        {
            var factor = new FactorEmision { idFE = 8, enabled = true };
            controller.ModelState.AddModelError("nombreCombustible", "Es necesario un nombre para el combustible");

            var result = await controller.Create(factor);
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
            _dbContext.Entry(_dbContext.FactorEmision.Find(5)).State = EntityState.Detached;
            var factorEdited = new FactorEmision { idFE = 5, factorEmision = 23, PCG=32, incertidumbreMenos=2,incertidumbreMas=2, enabled = true };
            var result = await controller.Edit(5, factorEdited);

            var redirectResult = result as RedirectToActionResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", redirectResult.ActionName);
        }

        [Test]
        public async Task TestEditIncorrect()
        {
            var factor = new FactorEmision { idFE = 5, enabled = true };
            controller.ModelState.AddModelError("nombreAlcance", "Es necesario un nombre para el alcance");

            var result = await controller.Edit(5, factor);
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
            _dbContext.Entry(_dbContext.FactorEmision.Find(5)).State = EntityState.Detached;
            var result = await controller.DeleteConfirmed(5);

            var redirectResult = result as RedirectToActionResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", redirectResult.ActionName);
        }
    }
}
