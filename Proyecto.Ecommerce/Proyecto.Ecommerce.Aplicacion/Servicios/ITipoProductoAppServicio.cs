using Proyecto.Ecommerce.Aplicacion.Dtos;
using Proyecto.Ecommerce.Dominio.Entidades;

namespace Proyecto.Ecommerce.Aplicacion.Servicios
{
    public interface ITipoProductoAppServicio
    {
        /// <summary>
        /// Método que permite obtener una lista de TipoProductoDto
        /// presentes en la tabla respectiva
        /// </summary>
        /// <returns>Task&lt;ICollection&lt;TipoProductoDto&gt;&gt;</returns>
        Task<ICollection<TipoProductoDto>> ObtenerTipoProductosDtoAsync();

        /// <summary>
        /// Método que permite obtener un objeto de tipo TipoProductoDto 
        /// por el Id correspondiente
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Task&lt;TipoProductoDto&gt;</returns>
        Task<TipoProductoDto> ObtenerTipoProductoDtoByIdAsync(string Id);

        /// <summary>
        /// Método que permite obtener un objeto de tipo TipoProducto 
        /// por el Id correspondiente
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Task&lt;TipoProducto&gt;</returns>
        Task<TipoProducto> ObtenerTipoProductoByIdAsync(string Id);

        /// <summary>
        /// Método que permite agregar un TipoProducto a la tabla correspondiente
        /// </summary>
        /// <param name="tipoProductoDto"></param>
        /// <returns>Task&lt;TipoProductoDto&gt;</returns>
        Task<TipoProductoDto> AgregarTipoProductoAsync(AgregarTipoProductoDto tipoProductoDto);

        /// <summary>
        /// Método que permite modificar los valores de un TipoProducto 
        /// de la tabla corresponsienrte
        /// </summary>
        /// <param name="tipoProductoDto"></param>
        /// <param name="Id"></param>
        /// <returns>Task&lt;bool&gt;</returns>
        Task<bool> ModificarTipoProductoAsync(AgregarTipoProductoDto tipoProductoDto, string Id);

        /// <summary>
        /// Método que permite eliminar un TipoProducto de la tabla corresponsiente
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Task&lt;bool&gt;</returns>
        Task<bool> EliminarTipoProductoById(string Id);
    }
}
