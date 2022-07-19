using Proyecto.Ecommerce.Aplicacion.Dtos;
using Proyecto.Ecommerce.Dominio.Entidades;

namespace Proyecto.Ecommerce.Aplicacion.Servicios
{
    public interface IClienteAppServicio
    {
        Task<ICollection<ClienteDto>> ObtenerClientesDtoAsync();
        Task<ClienteDto> ObtenerClienteDtoByIdAsync(Guid Id);
        Task<Cliente> ObtenerClienteByIdAsync(Guid Id);
        Task<ClienteDto> AgregarClienteAsync(ClienteDto clienteDto);
        Task<bool> ModificarClienteAsync(ClienteDto clienteDto, Guid Id);
        Task<bool> EliminarClienteById(Guid Id);
        Task<ICollection<ClienteDto>> GetPaginacion(int limit, int offset, string nombre, string cedula);
    }
} 
