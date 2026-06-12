using Microsoft.AspNetCore.Mvc;

namespace MiAplicacion.Controllers
{
    public class Ejemplo1Controller : Controller
    {
        public IActionResult Index() // Acción para la ruta /Ejemplo1/Index
        {
            return View();
        }
        public IActionResult PasandoDatos() // Acción para la ruta /Ejemplo1/PasandoDatos
        {
            ViewBag.Mensajito = "¡Hola desde el controlador!";
            ViewBag.edad = 20;
            ViewBag.Nombrecompleto = "Pepe Perales";
            ViewBag.casado = true;
            ViewBag.estatura = 1.75;
            ViewBag.fechaNacimiento = DateTime.Now;
            return View();
        }
    }
}
