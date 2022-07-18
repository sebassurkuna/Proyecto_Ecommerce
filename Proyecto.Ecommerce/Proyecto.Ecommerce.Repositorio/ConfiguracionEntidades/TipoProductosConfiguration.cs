using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proyecto.Ecommerce.Dominio.Entidades;

namespace Proyecto.Ecommerce.Infraestructura.ConfiguracionEntidades
{
    public class TipoProductosConfiguration : IEntityTypeConfiguration<TipoProducto>
    {
        public void Configure(EntityTypeBuilder<TipoProducto> builder)
        {
            builder.ToTable("TipoProducto");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .IsRequired().HasMaxLength(4);

            builder.Property(t => t.Nombre)
                .IsRequired().HasMaxLength(20).HasColumnName("Nombre");
        }
    }
}
