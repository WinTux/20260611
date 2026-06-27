using MiAplicacion.Models;
using Microsoft.EntityFrameworkCore;

namespace MiAplicacion.Herramientas
{
    public class MinimarketContext : DbContext
    {
        public virtual DbSet<Producto> productos { get; set; }
        public MinimarketContext()
        {
            
        }
        public MinimarketContext(DbContextOptions<MinimarketContext> options) : base(options)
        {
            
        }
    }
}
