using Microsoft.AspNetCore.Mvc;

namespace MiAplicacion.Controllers
{
    public class Ejemplo3Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Route("Prueba2/{id}")] // http://localhost:5000/Ejemplo3/Prueba2/123
        public IActionResult Prueba2(string id)
        {
            return View();
        } 
        [Route("Prueba3/{id1}/llave/{id2}")] // http://localhost:5000/Ejemplo3/Prueba3/123/llave/456
        public IActionResult Prueba3(string id1, string id2) { 
            return View();
        }
    }
}
