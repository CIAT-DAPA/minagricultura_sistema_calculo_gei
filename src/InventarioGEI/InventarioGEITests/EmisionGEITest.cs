using InventarioGEI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioGEITests
{
    public class EmisionGEITest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void VerificarModeloEmisionGEI()
        {
            // Arrange
            var emisionGEI = new EmisionGEI();
            double emisionGEIEsperado = 453;
            double emisionGEIEquiEsperado = 234;
            double factorEmisionEsperado = 687;
            double PCGEsperado = 2;

            // Act
            emisionGEI.emisionGEI = emisionGEIEsperado;
            emisionGEI.emisionGEIEqui = emisionGEIEquiEsperado;
            emisionGEI.factorEmision = factorEmisionEsperado;
            emisionGEI.PCG = PCGEsperado;
            double emisionGEIObtenido = emisionGEI.emisionGEI;
            double emisionGEIEquiObtenido = emisionGEI.emisionGEIEqui;
            double factorEmisionObtenido = emisionGEI.factorEmision;
            double PCGObtenido = emisionGEI.PCG;

            // Assert
            Assert.That(emisionGEIEsperado, Is.EqualTo(emisionGEIObtenido));
            Assert.That(emisionGEIEquiEsperado, Is.EqualTo(emisionGEIEquiObtenido));
            Assert.That(factorEmisionEsperado, Is.EqualTo(factorEmisionObtenido));
            Assert.That(PCGEsperado, Is.EqualTo(PCGObtenido));

        }
    }
}
