using InventarioGEI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InventarioGEITests
{
    public class AlcanceTest
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void VerificarModeloAlcance()
        {
            // Arrange
            var alcance = new Alcance();
            string alcanceEsperado = "Alcance unitTest";
            bool isBioEsperado = true;

            // Act
            alcance.nombreAlcance = alcanceEsperado;
            alcance.isBiocombustible = isBioEsperado;
            string alcanceObtenido = alcance.nombreAlcance;
            bool isBioObtenido = alcance.isBiocombustible;

            // Assert
            Assert.That(alcanceEsperado, Is.EqualTo(alcanceObtenido));
            Assert.That(isBioEsperado, Is.EqualTo(isBioObtenido));
        }
    }
}
