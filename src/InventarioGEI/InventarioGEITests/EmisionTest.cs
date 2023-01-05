using InventarioGEI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioGEITests
{
    public class EmisionTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void VerificarModeloEmision()
        {
            // Arrange
            var emision = new Emision();
            double mes1Esperado = 453;
            double mes4Esperado = 234;
            double valorAnualEsperado = 687;
            int noDatosEsperado = 2;
            double promedioEsperado = 345;
            double desviacionEstandarEsperado = 0.8;
            double coeficienteVariacionEsperado = 0.5;
            double factorTEsperado = 1.7;
            double IncertidumbreEsperado = 14.7;
            double emisionTotalEsperado = 3.56;

            // Act
            emision.mes1 = mes1Esperado;
            emision.mes4 = mes4Esperado;
            emision.valorAnual = valorAnualEsperado;
            emision.noDatos = noDatosEsperado;
            emision.promedio = promedioEsperado;
            emision.desviacionEstandar = desviacionEstandarEsperado;
            emision.coeficienteVariacion = coeficienteVariacionEsperado;
            emision.factorT = factorTEsperado;
            emision.incertidumbre = IncertidumbreEsperado;
            emision.emisionTotal = emisionTotalEsperado;
            double mes1Obtenido = (double)emision.mes1;
            double mes4Obtenido = (double)emision.mes4;
            double valorAnualObtenido = emision.valorAnual;
            int noDatosObtenido = emision.noDatos;
            double promedioObtenido = emision.promedio;
            double desviacionEstandarObtenido = emision.desviacionEstandar;
            double coeficienteVariacionObtenido = emision.coeficienteVariacion;
            double factorTObtenido = emision.factorT;
            double IncertidumbreObtenido = emision.incertidumbre;
            double emisionTotalObtenido = emision.emisionTotal;

            // Assert
            Assert.That(mes1Esperado, Is.EqualTo(mes1Obtenido));
            Assert.That(mes4Esperado, Is.EqualTo(mes4Obtenido));
            Assert.That(valorAnualEsperado, Is.EqualTo(valorAnualObtenido));
            Assert.That(noDatosEsperado, Is.EqualTo(noDatosObtenido));
            Assert.That(promedioEsperado, Is.EqualTo(promedioObtenido));
            Assert.That(desviacionEstandarEsperado, Is.EqualTo(desviacionEstandarObtenido));
            Assert.That(coeficienteVariacionEsperado, Is.EqualTo(coeficienteVariacionObtenido));
            Assert.That(factorTEsperado, Is.EqualTo(factorTObtenido));
            Assert.That(IncertidumbreEsperado, Is.EqualTo(IncertidumbreObtenido));
            Assert.That(emisionTotalEsperado, Is.EqualTo(emisionTotalObtenido));
            
        }
    }
}
