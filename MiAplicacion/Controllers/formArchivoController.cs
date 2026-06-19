using MiAplicacion.Models;
using Microsoft.AspNetCore.Mvc;

namespace MiAplicacion.Controllers
{
    [Route("archivo")]
    public class formArchivoController : Controller
    {
        private IWebHostEnvironment webHostEnvironment;

        public formArchivoController(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }
        [Route("index")]
        public IActionResult Index()
        {
            return View("Index", new Producto());
        }
        [Route("Guardar")]
        [HttpPost]
        public IActionResult Guardar(Producto prod, IFormFile foto) {
            if (foto == null || foto.Length == 0)
                return Content("Error: Foto no seleccionada");
            else {
                // "C:\Users\Pepe\Desktop" + "img.jpg"
                // "/home/Pepe/Escritorio" + "img.jpg"
                var ruta = Path.Combine(webHostEnvironment.WebRootPath, "imagenes", foto.FileName);
                var flujo = new FileStream(ruta, FileMode.Create);
                foto.CopyToAsync(flujo);
                prod.Foto = foto.FileName;
            }
            ViewBag.producto = prod;
            return View("ExitoArchivo"); 
        }
        [Route("index2")]
        public IActionResult multiple() {
            return View("Index2", new Producto2());
        }
        [Route("Guardar2")]
        [HttpPost]
        public IActionResult Guardar2(Producto2 prod, IFormFile[] fotos)
        {
            if (ModelState.IsValid)
            {
                if (fotos == null || fotos.Length == 0)
                    return Content("Error: Foto(s) no seleccionada(s)");
                else
                {
                    prod.Fotos = new List<string>();
                    foreach (IFormFile foto in fotos)
                    {
                        var ruta = Path.Combine(webHostEnvironment.WebRootPath, "imagenes", foto.FileName);
                        var flujo = new FileStream(ruta, FileMode.Create);
                        foto.CopyToAsync(flujo);
                        prod.Fotos.Add(foto.FileName);
                    }
                }
                ViewBag.producto = prod;
                return View("ExitoArchivo2");
            }
            else
                return View("Index2");
        }
    }
}
