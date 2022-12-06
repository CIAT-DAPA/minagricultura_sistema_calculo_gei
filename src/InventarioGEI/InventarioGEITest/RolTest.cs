using InventarioGEI.Controllers;
using InventarioGEI.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace InventarioGEITest
{
    [TestClass]
    public class RolTest
    {
        private readonly Mock<Context> _mockRepo;
        private readonly RolsController _controller;
        public RolTest()
        {
            _mockRepo = new Mock<Context>();
            _controller = new RolsController(_mockRepo.Object);
        }

        [TestMethod]
        public void IndexTest()
        {
            var result = _controller.Index();
          //  Assert.IsType<ViewResult>(result);
        }

        [TestMethod()]
        public async Task CreateTest()
        {
            Rol rolTest = new Rol() { idRol = 100, nombreRol = "unitTestRol1" };

            List<Rol> roles = new List<Rol>();
            roles.Add(rolTest);
            roles.Add(new Rol() { idRol = 101, nombreRol = "unitTestRol2" });

            var mockRepo = new Mock<Context>();
            mockRepo.Setup(repo => repo.Rol.Add(rolTest));
            RolsController controller = new RolsController(mockRepo.Object);
            var model = new Rol
            {
                idRol = 99,
                nombreRol = "unitTestRol",

            };

            // Act
            var createResult = await controller.Create(model);

            var viewResult = createResult as ViewResult;
            Assert.IsNotNull(viewResult);
        }

    }
}