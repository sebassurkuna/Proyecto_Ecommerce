using Proyecto.Ecommerce.Aplicacion.Servicios;
using Proyecto.Ecommerce.Dominio.Entidades;
using Proyecto.Ecommerce.Dominio.Repositorio;

namespace Proyecto.Ecommerce.Aplicacion.ImplServicios
{
    public class ProductoAppServicio : IProductoAppServicio
    {
        private readonly IRepositorioGenerico<Producto> repositorio;

        public ProductoAppServicio(IRepositorioGenerico<Producto> repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<Producto> AgregarProductoAsync(Producto producto)
        {
            await repositorio.AddAsync(producto);
            return await ObtenerProductoByIdAsync(producto.Id);
        }

        public async Task<bool> EliminarProductoById(Guid Id)
        {
            var producto = await ObtenerProductoByIdAsync(Id);
            await repositorio.DeleteAsync(producto);
            return true;
        }

        public async Task<Producto> ModificarProductoAsync(Producto producto)
        {
            await repositorio.UpdateAsync(producto);
            return await ObtenerProductoByIdAsync(producto.Id);
        }

        public Task<Producto> ObtenerProductoByIdAsync(Guid Id)
        {
            return repositorio.GetByIdAsync(Id);
        }

        public Task<ICollection<Producto>> ObtenerProductosAsync()
        {
            return repositorio.GetAsync();
        }
    }
}
