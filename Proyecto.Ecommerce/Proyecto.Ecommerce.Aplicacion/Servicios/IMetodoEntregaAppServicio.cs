using Proyecto.Ecommerce.Dominio.Entidades;

namespace Proyecto.Ecommerce.Aplicacion.Servicios
{
    public interface IMetodoEntregaAppServicio
    {
        Task<ICollection<MetodoEntrega>> ObtenerMetodosEntregaAsync();
        Task<MetodoEntrega> ObtenerMetodoEntregaByIdAsync(string Id);
        Task<MetodoEntrega> AgregarMetodoEntregaAsync(MetodoEntrega metodoEntrega);
        Task<MetodoEntrega> ModificarMetodoEntregaAsync(MetodoEntrega metodoEntrega);
        Task<bool> EliminarMetodoEntregaById(string Id);
    }
}
