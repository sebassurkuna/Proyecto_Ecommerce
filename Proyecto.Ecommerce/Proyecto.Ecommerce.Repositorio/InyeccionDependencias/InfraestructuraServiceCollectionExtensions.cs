using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Proyecto.Ecommerce.Dominio.Repositorio;
using Proyecto.Ecommerce.Infraestructura.Repositorio;

namespace Proyecto.Ecommerce.Infraestructura.InyeccionDependencias
{
    public static class InfraestructuraServiceCollectionExtensions
    {
        public static IServiceCollection AddInfraestructura(this IServiceCollection services, IConfiguration configuration)
        {
            //Dependencias Entidades
            services.AddTransient(typeof(IRepositorioGenerico<>), typeof(RepositorioGenerico<>));

            return services;
        }
    }
}
