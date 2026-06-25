using MiAplicacion.Herramientas;
using MiAplicacion.Models;
using Microsoft.AspNetCore.Mvc;

namespace MiAplicacion.Controllers
{
    [Route("carrito")]
    public class CarritoController : Controller
    {
        [Route("Index")]
        public IActionResult Index()
        {
            List<Item> carrito = HerramientaSesion.ConvertirJsonAobjeto<List<Item>>(HttpContext.Session, "carrito");
            ViewBag.carrito = carrito;
            ViewBag.total = carrito.Sum(i => i.producto.Precio * i.Cantidad);
            return View();
        }
        [Route("agregar/{id}")]
        public IActionResult Agregar(string id)
        {
            ProductoModel productoModel = new ProductoModel();
            if (HerramientaSesion.ConvertirJsonAobjeto<List<Item>>(HttpContext.Session, "carrito") == null)
            {
                List<Item> carrito = new List<Item>();
                carrito.Add(new Item { producto = productoModel.buscar(id), Cantidad = 1 });
                HerramientaSesion.ConvertirObjetoAjson(HttpContext.Session, "carrito", carrito);
            }
            else {
                List<Item> carrito = HerramientaSesion.ConvertirJsonAobjeto<List<Item>>(HttpContext.Session, "carrito");
                int indice = existe(id);
                if (indice != -1)
                    carrito[indice].Cantidad++;
                else
                    carrito.Add(new Item { producto =productoModel.buscar(id), Cantidad = 1 });
                HerramientaSesion.ConvertirObjetoAjson(HttpContext.Session, "carrito", carrito);
            }
            return RedirectToAction("EjemploCarrito", "Sesiones");
        }
        [Route("Eliminar/{id}")]
        public IActionResult eliminar(string id) {
            List<Item> carrito = HerramientaSesion.ConvertirJsonAobjeto<List<Item>>(HttpContext.Session, "carrito");
            int indice = existe(id);
            carrito.RemoveAt(indice);
            HerramientaSesion.ConvertirObjetoAjson(HttpContext.Session, "carrito", carrito);
            return RedirectToAction("Index");
        }
        private int existe(string id)
        {
            List<Item> carrito = HerramientaSesion.ConvertirJsonAobjeto<List<Item>>(HttpContext.Session, "carrito");
            for (int i = 0; i < carrito.Count; i++)
                if (carrito[i].producto.Id.Equals(id))
                    return i;
            return -1;
        }
    }
}
