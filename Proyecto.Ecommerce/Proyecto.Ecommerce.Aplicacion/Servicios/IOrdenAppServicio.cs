using Proyecto.Ecommerce.Dominio.Entidades;

namespace Proyecto.Ecommerce.Aplicacion.Servicios
{
    public interface IOrdenAppServicio
    {
        Task<ICollection<Orden>> ObtenerOrdenesAsync();
        Task<Orden> ObtenerOrdenByIdAsync(Guid Id);
        Task<Orden> AgregarOrdenAsync(Orden orden);
        Task<Orden> ModificarOrdenAsync(Orden orden);
        Task<bool> EliminarOrdenById(Guid Id);
    }
}
