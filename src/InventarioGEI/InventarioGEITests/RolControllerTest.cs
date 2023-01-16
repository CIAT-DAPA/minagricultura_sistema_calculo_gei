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

        [SetUp]
        public void Setup()
        {
            var rol = new Rol {idRol = 1, nombreRol = "Rol1test", permisoConfiguracion = true, permisoRol = true, enabled=true};

            var userTest = new Usuario {idUsuario = 1, email = "adminTest@admin.com", idRol=1, enabled=true};

            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseInMemoryDatabase("DBTest");
            var _dbContext = new Context(optionsBuilder.Options);
            _dbContext.Rol.Add(rol);
            _dbContext.Usuario.Add(userTest);
            _dbContext.SaveChangesAsync();
            controller = new RolsController(_dbContext);
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
        public async Task TestCreateRolCorrect()
        {
            var rol = new Rol { idRol = 2, nombreRol = "Rol2test", permisoConfiguracion = true, permisoRol = true, enabled = true };

            var result = await controller.Create(rol);
            var redirectResult = result as RedirectToActionResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", redirectResult.ActionName);
        }

        [Test]
        public async Task TestCreateRolIncorrect()
        {
            var rol = new Rol { permisoConfiguracion = true, permisoRol = true, enabled = true };

            var result = await controller.Create(rol);
            var redirectResult = result as RedirectToActionResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", redirectResult.ActionName);
        }
    }
}