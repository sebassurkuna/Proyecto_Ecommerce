using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proyecto.Ecommerce.Dominio.Entidades;

namespace Proyecto.Ecommerce.Infraestructura.ConfiguracionEntidades
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("Productos");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired();

            builder.Property(x => x.Nombre)
                .IsRequired().HasMaxLength(256).HasColumnName("Nombre");

            builder.Property(x => x.Descripcion)
                .IsRequired().HasMaxLength(256).HasColumnName("Descripcion");

            builder.Property(x => x.Precio)
                .IsRequired().HasColumnName("Precio");

            builder.Property(x => x.Stock)
                .IsRequired().HasColumnName("Stock");

            builder.Property(x => x.MarcaId)
                .IsRequired().HasMaxLength(4).HasColumnName("MarcaId");

            builder.Property(x => x.TipoProductoId)
                .IsRequired().HasMaxLength(4).HasColumnName("TipoProductoId");

            builder.HasOne(x => x.Marca).WithMany()
                .HasForeignKey(x => x.MarcaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.TipoProducto).WithMany()
                .HasForeignKey(x => x.TipoProductoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
