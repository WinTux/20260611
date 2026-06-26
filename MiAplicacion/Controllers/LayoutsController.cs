using Microsoft.AspNetCore.Mvc;

namespace MiAplicacion.Controllers
{
    public class LayoutsController : Controller
    {
        public IActionResult Home()
        {
            ViewBag.titulo = "HOME";
            return View();
        }
        public IActionResult Acerca()
        {
            return View();
        }
        public IActionResult Noticias()
        {
            return View();
        }
        public IActionResult Acerca1()
        {
            return View();
        }
        public IActionResult Acerca2()
        {
            return View();
        }
        public IActionResult Noticias1()
        {
            return View();
        }
        public IActionResult Noticias2()
        {
            return View();
        }
    }
}
