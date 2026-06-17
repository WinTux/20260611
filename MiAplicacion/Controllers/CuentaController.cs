using MiAplicacion.Models;
using Microsoft.AspNetCore.Mvc;

namespace MiAplicacion.Controllers
{
    [Route("cuenta")]
    public class CuentaController : Controller
    {
        [Route("index")]
        public IActionResult Index()
        {
            var cuentaViewModel = new CuentaViewModel()
            {
                cuenta = new Cuenta()
                {
                    Id = 1,
                    Disponible = true,
                    Genero = "F"
                },
                Lenguajes = new List<Lenguaje>()
                {
                    new Lenguaje() { Id = "len01", Nombre = "C#", estaMarcado = true },
                    new Lenguaje() { Id = "len02", Nombre = "Java", estaMarcado = false },
                    new Lenguaje() { Id = "len03", Nombre = "Python", estaMarcado = true },
                    new Lenguaje() { Id = "len04", Nombre = "COBOL", estaMarcado = false }
                }
            };
            var listaCargos = new List<Cargo>() {
                new Cargo { Id = "car01", Nombre = "Desarrollador" },
                new Cargo { Id = "car02", Nombre = "Auxiliar de desarrollo" },
                new Cargo { Id = "car03", Nombre = "Administrador de Base de datos" }
            };
            cuentaViewModel.Cargos = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(listaCargos, "Id", "Nombre");
            return View("Index", cuentaViewModel);
        }

        //public IActionResult Registrar() { 
        //}
    }
}
