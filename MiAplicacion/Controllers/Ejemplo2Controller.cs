using Microsoft.AspNetCore.Mvc;

namespace MiAplicacion.Controllers
{
    public class Ejemplo2Controller : Controller
    {
        private readonly IConfiguration _configuration;

        public Ejemplo2Controller(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            ViewBag.resultado1 = _configuration["Mensaje"];
            ViewBag.resultado2 = _configuration["MisConfiguraciones:Configuracion1"];
            ViewBag.resultado3 = _configuration["MisConfiguraciones:Configuracion2"];
            ViewBag.resultado4 = _configuration["MisConfiguraciones:Configuracion3"];
            ViewBag.resultado5 = _configuration["Logging:LogLevel:Microsoft.AspNetCore"];
            return View();
        }
    }
}
