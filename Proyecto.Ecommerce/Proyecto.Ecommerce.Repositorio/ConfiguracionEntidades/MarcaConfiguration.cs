using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proyecto.Ecommerce.Dominio.Entidades;

namespace Proyecto.Ecommerce.Infraestructura.ConfiguracionEntidades
{
    public class MarcaConfiguration : IEntityTypeConfiguration<Marca>
    {
        public void Configure(EntityTypeBuilder<Marca> builder)
        {
            builder.ToTable("Marcas");
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                .HasMaxLength(4).IsRequired();

            builder.Property(c => c.Nombre)
                .IsRequired().HasMaxLength(256).HasColumnName("Nombre");
        }
    }
}
