using InventarioGEI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioGEITests
{
    public class ConfiguracionTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void VerificarModeloConfiguracion()
        {
            // Arrange
            var configuracion = new ConfiguracionActividad();
            bool confBioEsperado = false;
            int idCombustibleEsperado = 15;
            int idSubcategoriaEsperado = 15;
            int idFuenteEmisionEsperado = 15;
            bool enabledEsperado = true;

            // Act
            configuracion.biocombustible = confBioEsperado;
            configuracion.idCombustible = idCombustibleEsperado;
            configuracion.idSubcategoria = idSubcategoriaEsperado;
            configuracion.idFuenteEmision = idFuenteEmisionEsperado;
            configuracion.enabled = enabledEsperado;
            bool confBioObtenido = configuracion.biocombustible ;
            int idCombustibleObtenido = configuracion.idCombustible ;
            int idSubcategoriaObtenido = configuracion.idSubcategoria ;
            int idFuenteEmisionObtenido = configuracion.idFuenteEmision;
            bool enabledObtenido = configuracion.enabled;

            // Assert
            Assert.That(confBioEsperado, Is.EqualTo(confBioObtenido));
            Assert.That(idCombustibleEsperado, Is.EqualTo(idCombustibleObtenido));
            Assert.That(idSubcategoriaEsperado, Is.EqualTo(idSubcategoriaObtenido));
            Assert.That(idFuenteEmisionEsperado, Is.EqualTo(idFuenteEmisionObtenido));
            Assert.That(enabledEsperado, Is.EqualTo(enabledObtenido));
        }
    }
}
