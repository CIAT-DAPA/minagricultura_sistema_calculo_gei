using InventarioGEI.Controllers;
using InventarioGEI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InventarioGEITests
{
    public class RegistroActividadControllerTest
    {
        public RegistroActividadsController controller;
        public Context _dbContext;
        [SetUp]
        public void Setup()
        {

            var rol = new Rol { idRol = 1, nombreRol = "Rol1test", permisoConfiguracion = true, permisoRol = true, permisoRegistro = true, permisoVisualizacion = true, permisoSede = true, enabled = true };
            var userTest = new Usuario { idUsuario = 1, email = "adminTest@admin.com", idRol = 1, enabled = true };
            var sede = new Sede { idSede = 1, nombreSede = "sede", direccion = "dir", enabled = true, usuCreador = userTest};
            var alcance = new Alcance { idAlcance = 9, nombreAlcance = "alcanceTest", isBiocombustible = false, enabled = true, usuario = userTest };
            var categoria1 = new Categoria { idCategoria = 10, nombreCategoria = "categoriaTest", enabled = true, alcance = alcance, usuarios = userTest, idAlcance=9 };
            var categoria2 = new Categoria { idCategoria = 11, nombreCategoria = "categoriaTest", enabled = true, alcance = alcance, usuarios = userTest, idAlcance= 9 };
            var unidad = new Unidad { idUnidad = 1, unidad = "unidad" };
            var combustible = new Combustible { idCombustible = 1, nombreCombustible = "combustible", unidad = unidad };
            var subcategoria = new Subcategoria { idSubcategoria = 1, nombreSubcategoria = "subcategoria", idCategoria=10, categoria=categoria1, enabled=true };
            var fuenteEmision = new FuenteEmision { idFuenteEmision = 1, nombreFuenteEmision = "fuente" };
            var conf = new ConfiguracionActividad { idConfiguracion = 1, combustible = combustible, subcategoria = subcategoria, fuenteEmision = fuenteEmision, enabled = true, idSubcategoria=1 };

            var registroToEdit = new RegistroActividad {idRegistroActividad = 5, valor = 45, mes = 3, año = 2021, enabled = true, usuario=userTest, sede= sede, configuracion=conf, idSede=1, idConfiguracion=1};

            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseInMemoryDatabase("DBTest");
            _dbContext = new Context(optionsBuilder.Options);
            _dbContext.Rol.Add(rol);
            _dbContext.Usuario.Add(userTest);
            _dbContext.RegistroActividad.Add(registroToEdit);
            _dbContext.Alcance.Add(alcance);
            _dbContext.Categoria.Add(categoria1);
            _dbContext.Categoria.Add(categoria2);
            _dbContext.SaveChangesAsync();
            controller = new RegistroActividadsController(_dbContext);
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                            {
                                new Claim(ClaimTypes.Name, "adminTest@admin.com"),

                            }, "mock"));
            controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = user };
        }

        [TearDown]
        public void TearDown()
        {
            // Limpia el contexto de la base de datos después de cada ejecución de pruebas
            _dbContext.Rol.RemoveRange(_dbContext.Rol);
            //_dbContext.Sede.RemoveRange(_dbContext.Sede);
            //_dbContext.Alcance.RemoveRange(_dbContext.Alcance);
            //_dbContext.Categoria.RemoveRange(_dbContext.Categoria);
            _dbContext.Unidad.RemoveRange(_dbContext.Unidad);
            //_dbContext.Combustible.RemoveRange(_dbContext.Combustible);
            //_dbContext.Subcategoria.RemoveRange(_dbContext.Subcategoria);
            _dbContext.FuenteEmision.RemoveRange(_dbContext.FuenteEmision);
            //_dbContext.ConfiguracionActividad.RemoveRange(_dbContext.ConfiguracionActividad);
            //_dbContext.Unidad.RemoveRange(_dbContext.Unidad);
            //_dbContext.RegistroActividad.RemoveRange(_dbContext.RegistroActividad);
            //_dbContext.Usuario.RemoveRange(_dbContext.Usuario);
            _dbContext.SaveChanges();
        }

        [Test]
        public async Task TestIndexView()
        {
            var result = await controller.Index();
            var viewResult = result as ViewResult;

            Assert.IsNotNull(viewResult);
            Assert.Greater(((IEnumerable<RegistroActividad>)viewResult.Model).Count(), 0);
        }

        [Test]
        public void TestGetCategorias()
        {
            var result = controller.GetCategorias(9);
      
            Assert.That(result, Is.TypeOf<JsonResult>());
        }

        [Test]
        public void TestGetCategoriaDoesntExist()
        {
            var result = controller.GetCategorias(0);

            Assert.IsNull(result);
        }

        [Test]
        public void TestGetCombustibles()
        {
            var result = controller.GetCombustibles(10).Result;

            Assert.That(result, Is.TypeOf<JsonResult>());
        }

        [Test]
        public void TestGetCombustiblesDoesntExist()
        {
            var result = controller.GetCombustibles(0).Result;

            Assert.IsNull(result);
        }

        [Test]
        public void TestGetValorRegistro()
        {
            var result = controller.GetValorDeRegistros(1, 3, 2021, 1).Result;

            Assert.That(result, Is.TypeOf<JsonResult>());
        }

        [Test]
        public void TestGetValorRegistroDoesntExist()
        {
            var result = controller.GetValorDeRegistros(5, 3, 2005, 1).Result;

            Assert.AreEqual(404, ((NotFoundResult)result).StatusCode);
        }

        [Test]
        public void TestPostRegistro()
        {
            List<RegistroActividad> registros = new List<RegistroActividad> { new RegistroActividad() { idRegistroActividad = 6, valor = 45, mes = 5, año = 2021, enabled = true, idSede = 1, idConfiguracion = 1 },
                                                                            new RegistroActividad() {idRegistroActividad = 7, valor = 45, mes = 4, año = 2021, enabled = true, idSede=1, idConfiguracion=1 } };
            
            var result = controller.PostRegistros(registros).Result;

            Assert.AreEqual(200, ((OkObjectResult)result).StatusCode);
        }
    }
}
