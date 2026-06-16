using Microsoft.AspNetCore.Mvc;

namespace MiAplicacion.Controllers
{
    [Route("Ejemplo3")]
    public class Ejemplo3Controller : Controller
    {
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("parametro/{id}")] // http://localhost:5000/Ejemplo3/Prueba2/123
        [Route("Prueba2/{id}")]
        [Route("Pruebita/{id}")]
        public IActionResult Prueba2(string id)
        {
            ViewBag.parametro = id;
            return View();
        }
        [Route("Prueba3/{id1}/llave/{id2}")] // http://localhost:5000/Ejemplo3/Prueba3/123/llave/456
        public IActionResult Prueba3(string id1, string id2)
        {
            ViewBag.parametro1 = id1;
            ViewBag.parametro2 = id2;
            return View();
        }
        [Route("Prueba4")] // http://localhost:5000/Ejemplo3/Prueba4?id1=123&id2=456
        public IActionResult Prueba4([FromQuery(Name = "id2")] string id2, [FromQuery(Name = "id1")] string id1)
        {
            ViewBag.parametro1 = id1;
            ViewBag.parametro2 = id2;
            return View("Prueba3");
        }
        [Route("Prueba5")]
        public IActionResult Prueba5()
        {
            bool hayValor = HttpContext.Request.Query.TryGetValue("id1", out var id1);
            var id2 = HttpContext.Request.Query["id2"].ToString(); // Otra forma de obtener el valor de id2
            if (hayValor)
                ViewBag.parametro1 = id1;
            else
                ViewBag.parametro1 = "No se proporcionó id1";
            ViewBag.parametro2 = id2;
            return View("Prueba3");
        }
    }
}
