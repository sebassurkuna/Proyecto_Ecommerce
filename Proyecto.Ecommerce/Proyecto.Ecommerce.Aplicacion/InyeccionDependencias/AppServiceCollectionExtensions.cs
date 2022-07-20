using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Proyecto.Ecommerce.Aplicacion.Servicios;
using Proyecto.Ecommerce.Aplicacion.ImplServicios;
using System.Reflection;
using FluentValidation;

namespace Proyecto.Ecommerce.Aplicacion.InyeccionDependencias
{
    public static class AppServiceCollectionExtensions
    {
        public static IServiceCollection AddApp(this IServiceCollection services, IConfiguration configuration)
        {
            //Dependecias de entidades
            services.AddTransient<IClienteAppServicio, ClienteAppServicio>();
            services.AddTransient<IMarcaAppServicio, MarcaAppServicio>();
            services.AddTransient<IMetodoEntregaAppServicio, MetodoEntregaAppServicio>();
            services.AddTransient<IProductoAppServicio, ProductoAppServicio>();
            services.AddTransient<ITipoProductoAppServicio, TipoProductoAppServicio>();
            services.AddTransient<ICarroComprasAppServicio, CarroComprasAppServicio>();

            //Dependecia de Mapeo
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //Depenedencia de Validaciones
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
