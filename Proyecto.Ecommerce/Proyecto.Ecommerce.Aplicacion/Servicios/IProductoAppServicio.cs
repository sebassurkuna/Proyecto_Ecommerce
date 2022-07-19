using Proyecto.Ecommerce.Aplicacion.Dtos;
using Proyecto.Ecommerce.Dominio.Entidades;

namespace Proyecto.Ecommerce.Aplicacion.Servicios
{
    public interface IProductoAppServicio
    {
        /// <summary>
        /// Método que permite obtener una lista de ProductoDto
        /// presentes en la tabla respectiva
        /// </summary>
        /// <returns>Task&lt;ICollection&lt;ProductoDto&gt;&gt;</returns>
        Task<ICollection<ProductoDto>> ObtenerProductosDtoAsync();

        /// <summary>
        /// Método que permite obtener un objeto de tipo ProductoDto 
        /// por el Id correspondiente
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Task&lt;ProductoDto&gt;</returns>
        Task<ProductoDto> ObtenerProductoDtoByIdAsync(Guid Id);

        /// <summary>
        /// Método que permite obtener un objeto de tipo Producto 
        /// por el Id correspondiente
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Task&lt;Producto&gt;</returns>
        Task<Producto> ObtenerProductoByIdAsync(Guid Id);

        /// <summary>
        /// Método que permite agregar un Producto a la tabla correspondiente
        /// </summary>
        /// <param name="productoDto"></param>
        /// <returns>Task&lt;ProductoDto&gt;</returns>
        Task<ProductoDto> AgregarProductoAsync(AgregarProductoDto productoDto);

        /// <summary>
        /// Método que permite modificar los valores de un Producto 
        /// de la tabla corresponsienrte
        /// </summary>
        /// <param name="productoDto"></param>
        /// <param name="Id"></param>
        /// <returns>Task&lt;bool&gt;</returns>
        Task<bool> ModificarProductoAsync(AgregarProductoDto productoDto, Guid Id);

        /// <summary>
        /// Método que permite eliminar un Producto de la tabla corresponsiente
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Task&lt;bool&gt;</returns>
        Task<bool> EliminarProductoById(Guid Id);

        /// <summary>
        /// Permite obtener una lista de objetos de tipo ProductoDto
        /// filtrados por caracteres contenidos (nombre), precio menor a
        ///  (precio), y paginada tomando en cuenta un limite de objetos 
        ///  (limit) y cierta cantidad de objetos saltados (offset).
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <param name="nombre"></param>
        /// <param name="precio"></param>
        /// <returns>Task&lt;ICollection&lt;ProductoDto&gt;&gt;</returns>
        Task<ICollection<ProductoDto>> GetPaginacion(int limit = 0, int offset = 0, string nombre = "", long precio = 0);
    }
}
