using InventarioGEI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioGEITests
{
    public class FuenteEmisionTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void VerificarModeloFuenteEmision()
        {
            // Arrange
            var fuenteEmision = new FuenteEmision();
            string fuenteEmisionEsperado = "factor unitTest";
            bool enabledEsperado = true;

            // Act
            fuenteEmision.nombreFuenteEmision = fuenteEmisionEsperado;
            fuenteEmision.enabled = enabledEsperado;
            string fuenteEmisionObtenido = fuenteEmision.nombreFuenteEmision;
            bool enabledObtenido = fuenteEmision.enabled;

            // Assert
            Assert.That(fuenteEmisionEsperado, Is.EqualTo(fuenteEmisionObtenido));
            Assert.That(enabledEsperado, Is.EqualTo(enabledObtenido));

        }
    }
}
