using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proyecto.Ecommerce.Dominio.Entidades;

namespace Proyecto.Ecommerce.Infraestructura.ConfiguracionEntidades
{
    public class OrdenConfiguration : IEntityTypeConfiguration<Orden>
    {
        public void Configure(EntityTypeBuilder<Orden> builder)
        {
            builder.ToTable("Ordenes");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired();

            builder.Property(o => o.MetodoEntregaId)
                .HasMaxLength(4).IsRequired();

            builder.Property(o => o.ClienteId)
                .IsRequired();

            builder.HasOne(o=>o.MetodoEntrega).WithMany()
                .HasForeignKey(o => o.MetodoEntregaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.Cliente).WithMany()
                .HasForeignKey(o => o.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
