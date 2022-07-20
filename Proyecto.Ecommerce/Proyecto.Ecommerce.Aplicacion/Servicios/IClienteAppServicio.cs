using Proyecto.Ecommerce.Aplicacion.Dtos;
using Proyecto.Ecommerce.Dominio.Entidades;

namespace Proyecto.Ecommerce.Aplicacion.Servicios
{
    public interface IClienteAppServicio
    {
        /// <summary>
        /// Método que permite obtener una lista de ClienteDto
        /// presentes en la tabla respectiva
        /// </summary>
        /// <returns>Task&lt;ICollection&lt;ClienteDto&gt;&gt;</returns>
        Task<ICollection<ClienteDto>> ObtenerClientesDtoAsync();

        /// <summary>
        /// Método que permite obtener un objeto de tipo ClienteDto 
        /// por el Id correspondiente
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Task&lt;ClienteDto&gt;</returns>
        Task<ClienteDto> ObtenerClienteDtoByIdAsync(Guid Id);

        /// <summary>
        /// Método que permite obtener un objeto de tipo Cliente 
        /// por el Id correspondiente
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Task&lt;Cliente&gt;</returns>
        Task<Cliente> ObtenerClienteByIdAsync(Guid Id);

        /// <summary>
        /// Método que permite agregar un Cliente a la tabla correspondiente
        /// </summary>
        /// <param name="clienteDto"></param>
        /// <returns>Task&lt;ClienteDto&gt;</returns>
        Task<ClienteDto> AgregarClienteAsync(ClienteDto clienteDto);

        /// <summary>
        /// Método que permite modificar los valores de un Cliente 
        /// de la tabla corresponsienrte
        /// </summary>
        /// <param name="clienteDto"></param>
        /// <param name="Id"></param>
        /// <returns>Task&lt;bool&gt;</returns>
        Task<bool> ModificarClienteAsync(ClienteDto clienteDto, Guid Id);

        /// <summary>
        /// Método que permite eliminar un Cliente de la tabla corresponsiente
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Task&lt;bool&gt;</returns>
        Task<bool> EliminarClienteById(Guid Id);

        /// <summary>
        /// Método que permite obtener una lista de productos paginada y filtrada 
        /// por los parámetros nombre y cedula
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <param name="nombre"></param>
        /// <param name="cedula"></param>
        /// <returns>Task&lt;ICollection&lt;ClienteDto&gt;&gt;</returns>
        Task<ICollection<ClienteDto>> GetPaginacion(int limit, int offset, string nombre, string cedula);
    }
} 
