using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiAplicacion.Models
{
    [Table("Producto")]
    public class Producto
    {
        [Key]
        public string Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public string Foto { get; set; }
    }
    #region Para ejemplo de sesión
    public class Producto3 
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Foto { get; set; }
    }
    public class Item
    {
        public Producto3 producto {  get; set; }
        public int Cantidad { get; set; }
    }
    public class ProductoModel
    {
        private List<Producto3> productos;
        public ProductoModel()
        {
            productos = new List<Producto3>()
            {
                new Producto3
                {
                    Id = "prod01",
                    Nombre = "Helado",
                    Precio = 13.5m,
                    Foto = "helado1.jfif"
                },
                new Producto3
                {
                    Id = "prod02",
                    Nombre = "Camisa",
                    Precio = 143.8m,
                    Foto = "camiseta.jpeg"
                },
                new Producto3
                {
                    Id = "prod03",
                    Nombre = "Mapache",
                    Precio = 713.5m,
                    Foto = "mapache.jpg"
                }
            };
        }
        public List<Producto3> getTodos()
        {
            return this.productos;
        }
        public Producto3 buscar(string id)
        {
            return this.productos.Single(p => p.Id.Equals(id));
        }
    }
    #endregion
    public class Producto2
    {
        [Required]
        [StringLength(7)]
        [RegularExpression(@"^[a-zA-Z]{4}\d{3}$", ErrorMessage ="En Id tiene 4 letras y 3 numeros en ese orden.")]
        public string Id { get; set; }
        [Required]
        [MinLength(5, ErrorMessage ="Mínimo de 5 letras por favor")]
        [MaxLength(20, ErrorMessage = "Máximo de 20 letras por favor")]
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        [Range(1,100, ErrorMessage = "Se debe ingresar un valor entre 1 y 100")]
        public int Cantidad { get; set; }
        public List<string> Fotos { get; set; }
        [EmailAddress]
        public string? emailProductor { get; set; }
        [Url]
        public string? urlProductor { get; set; }
    }
}
