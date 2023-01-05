using InventarioGEI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioGEITests
{
    public class CategoriaTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void VerificarModeloCategoria()
        {
            // Arrange
            var categoria = new Categoria();
            string categoriaEsperado = "Categoria unitTest";
            bool enabledEsperado = true;

            // Act
            categoria.nombreCategoria = categoriaEsperado;
            categoria.enabled = enabledEsperado;
            string categoriaObtenido = categoria.nombreCategoria;
            bool enabledObtenido = categoria.enabled;

            // Assert
            Assert.That(categoriaEsperado, Is.EqualTo(categoriaObtenido));
            Assert.That(enabledEsperado, Is.EqualTo(enabledObtenido));
        }
    }
}
