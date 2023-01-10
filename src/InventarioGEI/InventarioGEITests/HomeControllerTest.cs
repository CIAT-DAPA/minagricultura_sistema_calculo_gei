using InventarioGEI.Controllers;
using InventarioGEI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InventarioGEITests
{
    public class HomeControllerTest
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void TestIndexView()
        {
            var mockLogger = new Mock<ILogger<HomeController>>();
            var options = new DbContextOptionsBuilder<Context>()
                                        .UseInMemoryDatabase(databaseName: "TestIndex")
                                        .EnableSensitiveDataLogging()
                                        .Options;
            var context = new Context(options);
            var controller = new HomeController(mockLogger.Object, context);

            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOf(typeof(ViewResult), result);
        }

        [Test]
        public void TestManualView()
        {
            var mockLogger = new Mock<ILogger<HomeController>>();
            //var mockContext = new Mock<Context>();
            var options = new DbContextOptionsBuilder<Context>()
                                        .UseInMemoryDatabase(databaseName: "TestIndex")
                                        .EnableSensitiveDataLogging()
                                        .Options;
            var context = new Context(options);
            var controller = new HomeController(mockLogger.Object, context);

            // Act
            var result = controller.Manual();

            // Assert
            Assert.IsInstanceOf(typeof(ViewResult), result);
        }

        [Test]
        public void TestAccesDeniedlView()
        {
            var mockLogger = new Mock<ILogger<HomeController>>();
            //var mockContext = new Mock<Context>();
            var options = new DbContextOptionsBuilder<Context>()
                                        .UseInMemoryDatabase(databaseName: "TestIndex")
                                        .EnableSensitiveDataLogging()
                                        .Options;
            var context = new Context(options);
            var controller = new HomeController(mockLogger.Object, context);

            // Act
            var result = controller.AccesDenied();

            // Assert
            Assert.IsInstanceOf(typeof(ViewResult), result);
        }

        [Test]
        public void TestError404View()
        {
            var mockLogger = new Mock<ILogger<HomeController>>();
            //var mockContext = new Mock<Context>();
            var options = new DbContextOptionsBuilder<Context>()
                                        .UseInMemoryDatabase(databaseName: "TestIndex")
                                        .EnableSensitiveDataLogging()
                                        .Options;
            var context = new Context(options);
            var controller = new HomeController(mockLogger.Object, context);

            // Act
            var result = controller.Error(404) as ViewResult;

            // Assert
            Assert.That(result.ViewName, Is.EqualTo("404"));
        }

        [Test]
        public void TestError500View()
        {
            var mockLogger = new Mock<ILogger<HomeController>>();
            //var mockContext = new Mock<Context>();
            var options = new DbContextOptionsBuilder<Context>()
                                        .UseInMemoryDatabase(databaseName: "TestIndex")
                                        .EnableSensitiveDataLogging()
                                        .Options;
            var context = new Context(options);
            var controller = new HomeController(mockLogger.Object, context);

            // Act
            var result = controller.Error(500) as ViewResult;

            // Assert
            Assert.That(result.ViewName, Is.EqualTo("500"));
        }
    }
}
