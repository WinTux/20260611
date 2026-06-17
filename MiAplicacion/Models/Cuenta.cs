using Microsoft.AspNetCore.Mvc.Rendering;

namespace MiAplicacion.Models
{
    public class Cuenta
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public string Descripcion { get; set; }
        public bool Disponible { get; set; }
        public string Genero { get; set; }
        public List<string> Lenguajes { get; set; }
        public string Cargo { get; set; }
    }
    public class Lenguaje { 
        public string Id { get; set; }
        public string Nombre { get; set; }
        public bool estaMarcado { get; set; }
    }
    public class Cargo {
        public string Id { get; set; }
        public string Nombre { get; set; }
    }
    public class CuentaViewModel
    {
        public Cuenta cuenta { get; set; }
        public List<Lenguaje> Lenguajes { get; set; }
        public SelectList Cargos { get; set; }
    }
}
