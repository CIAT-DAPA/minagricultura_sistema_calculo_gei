using InventarioGEI.Controllers;
using InventarioGEI.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventarioGEITest
{
    [TestClass]
    public class RolTest
    {
        private readonly Context _context;
        [TestMethod]
        public void IndexTest()
        {
            RolsController controller = new RolsController(_context);
            bool permiso = true;
            ViewResult result = (ViewResult) controller.Create(permiso); 

            Assert.IsNotNull(result);
        }
    }
}