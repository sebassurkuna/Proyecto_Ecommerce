using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proyecto.Ecommerce.Dominio.Entidades;

namespace Proyecto.Ecommerce.Infraestructura.ConfiguracionEntidades
{
    public class OrdenItemsConfiguration : IEntityTypeConfiguration<OrdenItems>
    {
        public void Configure(EntityTypeBuilder<OrdenItems> builder)
        {
            builder.ToTable("OrdenItems");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired();

            builder.Property(x => x.CantidadProducto)
                .IsRequired().HasColumnName("CantidadProducto");

            builder.Property(x => x.ProductoId)
                .IsRequired().HasColumnName("ProductoId");

            builder.HasOne(o => o.Producto).WithMany()
                .HasForeignKey(o => o.ProductoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
