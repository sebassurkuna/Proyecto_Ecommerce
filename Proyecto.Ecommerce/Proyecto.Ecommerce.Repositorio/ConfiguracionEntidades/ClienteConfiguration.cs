using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proyecto.Ecommerce.Dominio.Entidades;

namespace Proyecto.Ecommerce.Infraestructura.ConfiguracionEntidades
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasMaxLength(4).IsRequired();

            builder.Property(c=>c.Nombre)
                .IsRequired().HasMaxLength(256).HasColumnName("Nombre");

            builder.Property(c => c.Apellido)
                .IsRequired().HasMaxLength(256).HasColumnName("Apellido");

            builder.Property(c => c.Contraseña)
                .IsRequired().HasMaxLength(20).HasColumnName("Password");

            builder.Property(c => c.NombreUsuario)
                .IsRequired().HasMaxLength(50).HasColumnName("Usuario");

            builder.Property(c => c.Edad)
                .IsRequired().HasMaxLength(2).HasColumnName("Edad");

            builder.Property(c => c.NumeroCedula)
                .IsRequired().HasMaxLength(10).HasColumnName("CI");

            builder.Property(c => c.Email)
                .IsRequired().HasMaxLength(20).HasColumnName("Email");
        }
    }
}
