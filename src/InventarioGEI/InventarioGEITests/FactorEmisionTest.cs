using InventarioGEI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioGEITests
{
    public class FactorEmisionTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void VerificarModeloFactorEmision()
        {
            // Arrange
            var factorEmision = new FactorEmision();
            double factorEmisionEsperado = 453;
            double PCGEsperado = 2;
            double IncertidumbreMasEsperado = 0.3;
            double IncertidumbreMenosEsperado = 0.6;

            // Act
            factorEmision.factorEmision = factorEmisionEsperado;
            factorEmision.PCG = PCGEsperado;
            factorEmision.incertidumbreMas = IncertidumbreMasEsperado;
            factorEmision.incertidumbreMenos = IncertidumbreMenosEsperado;
            double factorEmisionObtenido = factorEmision.factorEmision;
            double PCGObtenido = factorEmision.PCG;
            double IncertidumbreMasObtenido = factorEmision.incertidumbreMas;
            double IncertidumbreMenosObtenido = factorEmision.incertidumbreMenos;

            // Assert
            Assert.That(factorEmisionEsperado, Is.EqualTo(factorEmisionObtenido));
            Assert.That(PCGEsperado, Is.EqualTo(PCGObtenido));
            Assert.That(IncertidumbreMasEsperado, Is.EqualTo(IncertidumbreMasObtenido));
            Assert.That(IncertidumbreMenosEsperado, Is.EqualTo(IncertidumbreMenosObtenido));

        }
    }
}
