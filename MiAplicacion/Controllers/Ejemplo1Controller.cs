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
        public IActionResult PasandoDatosObjetos() // Acción para la ruta /Ejemplo1/PasandoDatos2
        {
            var producto = new Models.Producto
            {
                Id = "pro01",
                Nombre = "Camiseta",
                Precio = 19.99m,
                Cantidad = 100,
                Foto = "camiseta.jpeg"
            };
            ViewBag.Producto = producto;
            return View();
        }
        public IActionResult PasandoDatosListaObjetos() // Acción para la ruta /Ejemplo1/PasandoDatos2
        {
            var productos = new List<Models.Producto>
            {
                new Models.Producto
            {
                Id = "pro01",
                Nombre = "Camiseta",
                Precio = 19.99m,
                Cantidad = 100,
                Foto = "camiseta.jpeg"
            },
                new Models.Producto
            {
                Id = "pro02",
                Nombre = "Camiseta 2",
                Precio = 29.99m,
                Cantidad = 76,
                Foto = "camiseta2.tiff"
            },
                new Models.Producto
            {
                Id = "pro03",
                Nombre = "Camiseta 3",
                Precio = 39.99m,
                Cantidad = 50,
                Foto = "camiseta3.jpg"
            },
                 new Models.Producto
            {
                Id = "pro04",
                Nombre = "Camiseta 4",
                Precio = 49.99m,
                Cantidad = 25,
                Foto = "camiseta4.jpg"
            } };
            ViewBag.Productos = productos;
            return View();
        }
    }
}
