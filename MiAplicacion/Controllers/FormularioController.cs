using Microsoft.AspNetCore.Mvc;

namespace MiAplicacion.Controllers
{
    public class FormularioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
