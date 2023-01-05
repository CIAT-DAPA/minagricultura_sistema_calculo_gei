using InventarioGEI.Controllers;
using InventarioGEI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Security.Claims;

namespace InventarioGEITests
{
    public class RolControllerTest
    {
        [SetUp]
        public void Setup()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "Sebastian.Lopez@cgiar.org"),
                new Claim(ClaimTypes.Role, "Administrator"),
            };

            var claimsIdentity = new ClaimsIdentity(claims, "TestAuthType");
            var user = new ClaimsPrincipal(claimsIdentity);

            ClaimsPrincipal.ClaimsPrincipalSelector = () => user;
            Console.WriteLine("Termino SetUp");
        }

        [Test]
        public async Task TestIndexView()
        {
            Console.WriteLine("Test2");
            //Rol rol = new Rol() { idRol=99,
            //                        nombreRol="Roltest",
            //                        permisoConfiguracion=true,
            //                        permisoRol=true
            //                    };
            //Mock<Context> _context = new Mock<Context>(rol);

            //RolsController controller = new RolsController(_context.Object);
            //Assert.That(controller.Index, Is.InstanceOf<ViewResult>());

            // Arrange
            //var options = new DbContextOptionsBuilder<Context>().UseInMemoryDatabase(databaseName: "TestIndex").Options;

            
            var options = new DbContextOptionsBuilder<Context>()
                                        .UseInMemoryDatabase(databaseName: "TestIndex")
                                        .EnableSensitiveDataLogging()
                                        .Options;
            var context = new Context(options);
            var controller = new RolsController(context);

            // Act
            var result = await controller.Index();
            var viewResult = result as ViewResult;

            // Assert
            Assert.That(viewResult.ViewName, Is.EqualTo("Index"));
        }
    }
}