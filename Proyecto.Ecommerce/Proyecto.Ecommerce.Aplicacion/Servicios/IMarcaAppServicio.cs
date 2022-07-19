using Proyecto.Ecommerce.Aplicacion.Dtos;
using Proyecto.Ecommerce.Dominio.Entidades;

namespace Proyecto.Ecommerce.Aplicacion.Servicios
{
    public interface IMarcaAppServicio
    {
        /// <summary>
        /// Método que permite obtener una lista de MarcaDto
        /// presentes en la tabla respectiva
        /// </summary>
        /// <returns>Task&lt;ICollection&lt;MarcaDto&gt;&gt;</returns>
        Task<ICollection<MarcaDto>> ObtenerMarcasDtoAsync();

        /// <summary>
        /// Método que permite obtener un objeto de tipo MarcaDto 
        /// por el Id correspondiente
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Task&lt;MarcaDto&gt;</returns>
        Task<MarcaDto> ObtenerMarcaDtoByIdAsync(string Id);

        /// <summary>
        /// Método que permite obtener un objeto de tipo Marca 
        /// por el Id correspondiente
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Task&lt;Marca&gt;</returns>
        Task<Marca> ObtenerMarcaByIdAsync(string Id);

        /// <summary>
        /// Método que permite agregar una Marca a la tabla correspondiente
        /// </summary>
        /// <param name="marcaDto"></param>
        /// <returns>Task&lt;MarcaDto&gt;</returns>
        Task<MarcaDto> AgregarMarcaAsync(AgregarMarcaDto marcaDto);

        /// <summary>
        /// Método que permite modificar los valores de una Marca 
        /// de la tabla corresponsienrte
        /// </summary>
        /// <param name="marcaDto"></param>
        /// <param name="Id"></param>
        /// <returns>Task&lt;bool&gt;</returns>
        Task<bool> ModificarMarcaAsync(AgregarMarcaDto marcaDto, string Id);

        /// <summary>
        /// Método que permite eliminar una Marca de la tabla corresponsiente
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Task&lt;bool&gt;</returns>
        Task<bool> EliminarMarcaById(string Id);
    }
}
