﻿using InventarioGEI.Controllers;
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
    public class SedeControllerTest
    {
        public SedesController controller;
        public Context _dbContext;
        [SetUp]
        public void Setup()
        {

            var rol = new Rol { idRol = 1, nombreRol = "Rol1test", permisoConfiguracion = true, permisoRol = true, permisoRegistro = true, permisoVisualizacion = true, permisoSede=true, enabled = true };
            var userTest = new Usuario { idUsuario = 1, email = "adminTest@admin.com", idRol = 1, enabled = true };
            var departamento = new Departamento {codigoDepartamento=1, nombreDepartamento="departamento" };
            var municipio = new Municipio { codigoMunicipio = 1, nombreMunicipio = "municipio", departamento=departamento };
            var sedeToEdit = new Sede { idSede = 5, nombreSede = "sede", direccion = "dir", enabled=true,usuCreador=userTest, municipio=municipio };

            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseInMemoryDatabase("DBTest");
            _dbContext = new Context(optionsBuilder.Options);
            _dbContext.Rol.Add(rol);
            _dbContext.Usuario.Add(userTest);
            _dbContext.Sede.Add(sedeToEdit);
            _dbContext.SaveChangesAsync();
            controller = new SedesController(_dbContext);
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
            //_dbContext.Sede.RemoveRange(_dbContext.Sede);
            //_dbContext.Usuario.RemoveRange(_dbContext.Usuario);
            _dbContext.Departamento.RemoveRange(_dbContext.Departamento);
            //_dbContext.Municipio.RemoveRange(_dbContext.Municipio);

            _dbContext.SaveChangesAsync();
            
        }

        [Test]
        public async Task TestIndexView()
        {
            var result = await controller.Index("");
            var viewResult = result as ViewResult;

            Assert.IsNotNull(viewResult);
            Assert.Greater(((IEnumerable<Sede>)viewResult.Model).Count(), 0);
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
            var sede = new Sede { idSede = 2, nombreSede = "sede", direccion="dir"};

            var result = await controller.Create(sede);
            var redirectResult = result as RedirectToActionResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", redirectResult.ActionName);
        }

        [Test]
        public async Task TestCreateIncorrect()
        {
            var sede = new Sede { idSede = 2};
            controller.ModelState.AddModelError("nombreRol", "Es necesario un nombre para el rol");

            var result = await controller.Create(sede);
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
            _dbContext.Entry(_dbContext.Sede.Find(5)).State = EntityState.Detached;
            var sedeEdited = new Sede { idSede = 5, nombreSede = "sede", direccion = "dir" };
            var result = await controller.Edit(5, sedeEdited);

            var redirectResult = result as RedirectToActionResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", redirectResult.ActionName);
        }

        [Test]
        public async Task TestEditIncorrect()
        {
            var sede = new Sede { idSede = 2 };
            controller.ModelState.AddModelError("nombreAlcance", "Es necesario un nombre para el alcance");

            var result = await controller.Edit(5, sede);
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
            _dbContext.Entry(_dbContext.Sede.Find(5)).State = EntityState.Detached;
            var result = await controller.DeleteConfirmed(5);

            var redirectResult = result as RedirectToActionResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", redirectResult.ActionName);
        }
    }
}