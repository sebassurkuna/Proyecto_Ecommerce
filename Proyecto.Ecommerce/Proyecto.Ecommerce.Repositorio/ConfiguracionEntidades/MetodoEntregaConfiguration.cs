using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proyecto.Ecommerce.Dominio.Entidades;

namespace Proyecto.Ecommerce.Infraestructura.ConfiguracionEntidades
{
    public class MetodoEntregaConfiguration : IEntityTypeConfiguration<MetodoEntrega>
    {
        public void Configure(EntityTypeBuilder<MetodoEntrega> builder)
        {
            builder.ToTable("MetodosEntregas");
            builder.HasKey(t => t.Id);

            builder.Property(m => m.Id).IsRequired().HasMaxLength(4);

            builder.Property(m => m.Nombre)
                .HasMaxLength(20).IsRequired().HasColumnName("Nombre");

            builder.Property(m => m.Descripcion)
                .HasMaxLength(256).IsRequired().HasColumnName("Descripcion");

            builder.Property(m => m.CostoEntrega)
                .IsRequired().HasColumnName("CostosEntrega");
        }
    }
}
