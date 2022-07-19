using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Proyecto.Ecommerce.Dominio.InyeccionDependencias
{
    public static class DominioServiceCollectionExtensions
    {
        public static IServiceCollection AddDominio(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}
