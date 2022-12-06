using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventarioGEI.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Handle(int errorCode)
        {
            return View(errorCode);
        }
       
    }
}
