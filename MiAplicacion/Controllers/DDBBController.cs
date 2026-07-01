using MiAplicacion.Herramientas;
using MiAplicacion.Models;
using Microsoft.AspNetCore.Mvc;

namespace MiAplicacion.Controllers
{
    [Route("ddbb")]
    public class DDBBController : Controller
    {
        private MinimarketContext db;
        public DDBBController(MinimarketContext minimarket)
        {
            db = minimarket;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            ViewBag.productos = db.productos.ToList();
            // Viene del ejemplo de eliminacion logica de Eliminar
            //ViewBag.productos = db.productos.Where(p => p.Estado == true).ToList();
            return View();
        }
        [HttpGet]
        [Route("Agregar")]
        public IActionResult Agregar()
        {
            return View();
        }
        [HttpPost]
        [Route("Agregar")]
        public IActionResult Agregar(Producto prod)
        {
            db.productos.Add(prod);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Modificar")]
        public IActionResult Modificar(string id)
        {
            Producto producto = db.productos.Find(id);
            return View(producto);
        }
        [HttpPost]
        [Route("Modificar")]
        public IActionResult Modificar(Producto prod)
        {
            db.Entry(prod).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
        [Route("Eliminar")]
        public IActionResult Eliminar(string id)
        {
            // Eliminacion fisica del producto
            db.productos.Remove(db.productos.Find(id));
            db.SaveChanges();
            // Eliminacion logica del producto
            /*Producto producto = db.productos.Find(id);
            producto.Estado = false;
            db.Entry(producto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();*/
            return RedirectToAction("Index");
        }
    }
}
