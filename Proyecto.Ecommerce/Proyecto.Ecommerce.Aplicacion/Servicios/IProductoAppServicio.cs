using Proyecto.Ecommerce.Dominio.Entidades;

namespace Proyecto.Ecommerce.Aplicacion.Servicios
{
    public interface IProductoAppServicio
    {
        Task<ICollection<Producto>> ObtenerProductosAsync();
        Task<Producto> ObtenerProductoByIdAsync(Guid Id);
        Task<Producto> AgregarProductoAsync(Producto producto);
        Task<Producto> ModificarProductoAsync(Producto producto);
        Task<bool> EliminarProductoById(Guid Id);
    }
}
