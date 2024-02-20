using BETarjeta.Models;
using Microsoft.EntityFrameworkCore;

namespace BETarjeta
{
    public class AplicationBDContext:DbContext
    {
        public DbSet<TarjetaCredito> TarjetaCredito { get; set; } //Se mapea el modelo con la tabla de la base de datos
        public AplicationBDContext(DbContextOptions<AplicationBDContext> options):base(options) {
            
        }
    }
}
