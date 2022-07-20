using Microsoft.EntityFrameworkCore;
using Proyecto.Ecommerce.Dominio.Entidades;
using System.Reflection;

namespace Proyecto.Ecommerce.Infraestructura.Context
{
    public class EcommerceDbContext : DbContext
    {
        public EcommerceDbContext(DbContextOptions options) : base(options)
        {
        }

        DbSet<Producto> Productos { get; set; }
        DbSet<Marca> Marcas { get; set; }
        DbSet<TipoProducto> TiposProductos { get; set; }
        DbSet<OrdenItems> OrdenesItems { get; set; }
        DbSet<MetodoEntrega> MetodosEntregas { get; set; }
        DbSet<Cliente> Clientes { get; set; }
        DbSet<Orden> Ordenes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
