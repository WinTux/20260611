using Microsoft.AspNetCore.Mvc;

namespace MiAplicacion.Controllers
{
    public class CodigosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Generar(string valor)
        {
            ViewBag.valor = valor;
            return View("Index");
        }
    }
}
