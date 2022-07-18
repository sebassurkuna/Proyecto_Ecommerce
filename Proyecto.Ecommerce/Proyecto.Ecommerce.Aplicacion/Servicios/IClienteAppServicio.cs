using Proyecto.Ecommerce.Dominio.Entidades;

namespace Proyecto.Ecommerce.Aplicacion.Servicios
{
    public interface IClienteAppServicio
    {
        Task<ICollection<Cliente>> ObtenerClientesAsync();
        Task<Cliente> ObtenerClienteByIdAsync(Guid Id);
        Task<Cliente> AgregarClienteAsync(Cliente cliente);
        Task<Cliente> ModificarClienteAsync(Cliente cliente);
        Task<bool> EliminarClienteById(Guid Id);
    }
}
