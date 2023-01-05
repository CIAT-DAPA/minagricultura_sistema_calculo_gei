using InventarioGEI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioGEITests
{
    public class CombustibleTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void VerificarModeloCombustible()
        {
            // Arrange
            var combustible = new Combustible();
            string combustibleEsperado = "Combustible unitTest";
            bool enabledEsperado = true;

            // Act
            combustible.nombreCombustible = combustibleEsperado;
            combustible.enabled = enabledEsperado;
            string combustibleObtenido = combustible.nombreCombustible;
            bool enabledObtenido = combustible.enabled;

            // Assert
            Assert.That(combustibleEsperado, Is.EqualTo(combustibleObtenido));
            Assert.That(enabledEsperado, Is.EqualTo(enabledObtenido));
        }
    }
}
