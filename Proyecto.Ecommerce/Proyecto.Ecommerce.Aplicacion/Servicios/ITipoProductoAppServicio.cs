using Proyecto.Ecommerce.Dominio.Entidades;

namespace Proyecto.Ecommerce.Aplicacion.Servicios
{
    public interface ITipoProductoAppServicio
    {
        Task<ICollection<TipoProducto>> ObtenerTipoProductosAsync();
        Task<TipoProducto> ObtenerTipoProductoByIdAsync(string Id);
        Task<TipoProducto> AgregarTipoProductoAsync(TipoProducto tipoProducto);
        Task<TipoProducto> ModificarTipoProductoAsync(TipoProducto tipoProducto);
        Task<bool> EliminarTipoProductoById(string Id);
    }
}
