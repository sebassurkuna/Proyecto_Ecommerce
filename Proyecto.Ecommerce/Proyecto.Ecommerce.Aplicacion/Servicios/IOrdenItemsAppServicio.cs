using Proyecto.Ecommerce.Dominio.Entidades;

namespace Proyecto.Ecommerce.Aplicacion.Servicios
{
    public interface IOrdenItemsAppServicio
    {
        Task<ICollection<OrdenItems>> ObtenerOrdenItemsAsync();
        Task<OrdenItems> ObtenerOrdenItemsByIdAsync(Guid Id);
        Task<OrdenItems> AgregarOrdenItemsAsync(OrdenItems ordenItems);
        Task<OrdenItems> ModificarOrdenItemsAsync(OrdenItems ordenItems);
        Task<bool> EliminarOrdenItemsById(Guid Id);
    }
}
