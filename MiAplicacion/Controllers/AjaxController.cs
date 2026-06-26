using MiAplicacion.Models;
using Microsoft.AspNetCore.Mvc;

namespace MiAplicacion.Controllers
{
    [Route("ajax")]
    public class AjaxController : Controller
    {
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("ejemplo1")]
        public ContentResult Ejemplo1()
        {
            return Content("Hola a todos", "text/plain");
        }
        [Route("ejemplo2/{nombre}")]
        public ContentResult Ejemplo2(string nombre)
        {
            return Content("Hola " + nombre, "text/plain");
        }
        [Route("ejemplo3")]
        public IActionResult Ejemplo3()
        {
            Producto3 producto = new Producto3() { 
                Id = "p01",
                Nombre = "Camiseta",
                Precio = 200,
                Foto = "camiseta2.tiff"
            };
            return new JsonResult(producto);
        }
        public IActionResult Ejemplo4()
        {
            List<Producto3> productos = new List<Producto3>() {
                new Producto3()
                {
                    Id = "p01",
                    Nombre = "Camiseta 1",
                    Precio = 200,
                    Foto = "camiseta2.tiff"
                },
                new Producto3()
                {
                    Id = "p02",
                    Nombre = "Camiseta 2",
                    Precio = 200,
                    Foto = "camiseta.jpeg"
                },
                new Producto3()
                {
                    Id = "p03",
                    Nombre = "Camiseta 3",
                    Precio = 200,
                    Foto = "camiseta3.jpg"
                },
                new Producto3()
                {
                    Id = "p04",
                    Nombre = "Camiseta 4",
                    Precio = 200,
                    Foto = "camiseta4.jpg"
                }
            };
            return new JsonResult(productos);
        }
    }
}
