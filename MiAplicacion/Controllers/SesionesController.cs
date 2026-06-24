using MiAplicacion.Herramientas;
using MiAplicacion.Models;
using Microsoft.AspNetCore.Mvc;

namespace MiAplicacion.Controllers
{
    public class SesionesController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Session.SetInt32("edad",78);
            HttpContext.Session.SetString("usuario","Pepe");

            Producto producto = new Producto
            {
                Id = "prod01",
                Nombre = "Helado",
                Precio = 45,
                Cantidad = 12,
                Foto = "helado1.jfif"
            };

            HerramientaSesion.ConvertirObjetoAjson(HttpContext.Session, "producto", producto);

            List<Producto> lista = new List<Producto>() {
                new Producto
                {
                    Id = "prod01",
                    Nombre = "Helado",
                    Precio = 45,
                    Cantidad = 12,
                    Foto = "helado1.jfif"
                },
                new Producto
                {
                    Id = "prod02",
                    Nombre = "Helado supremo",
                    Precio = 80,
                    Cantidad = 12,
                    Foto = "helado2.jfif"
                },
                new Producto
                {
                    Id = "prod03",
                    Nombre = "Helado económico",
                    Precio = 12,
                    Cantidad = 24,
                    Foto = "helado3.jpg"
                }
            };

            HerramientaSesion.ConvertirObjetoAjson(HttpContext.Session, "productos", lista);


            return View("Index");
        }

        public IActionResult EjemploCarrito()
        {
            var productoModel = new ProductoModel();
            ViewBag.productos = productoModel.getTodos();
            return View();
        }
    }
}
