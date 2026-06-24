using Microsoft.AspNetCore.Mvc;

namespace MiAplicacion.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string usuario, string password) {
            if (usuario != null && password != null && usuario.Equals("pepe") && password.Equals("patito123")){
                HttpContext.Session.SetString("usu", usuario);
                return View("exito");
            }
            else {
                ViewBag.error = "¡Credenciales incorrectas!";
                return View("Index");
            }
        }
        [HttpGet]
        public IActionResult Logout() {
            HttpContext.Session.Remove("usu");
            return RedirectToAction("Index");
        }
    }
}
