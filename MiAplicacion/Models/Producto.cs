using System.ComponentModel.DataAnnotations;

namespace MiAplicacion.Models
{
    public class Producto
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public string Foto { get; set; }
    }
    public class Producto2
    {
        [Required]
        [StringLength(7)]
        [RegularExpression(@"^[a-zA-Z]{4}\d{3}$")]
        public string Id { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        [Range(1,100)]
        public int Cantidad { get; set; }
        public List<string> Fotos { get; set; }
        [EmailAddress]
        public string? emailProductor { get; set; }
        [Url]
        public string? urlProductor { get; set; }
    }
}
