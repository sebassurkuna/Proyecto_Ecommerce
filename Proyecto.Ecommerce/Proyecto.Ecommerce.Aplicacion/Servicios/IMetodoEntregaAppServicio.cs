using Proyecto.Ecommerce.Aplicacion.Dtos;
using Proyecto.Ecommerce.Dominio.Entidades;

namespace Proyecto.Ecommerce.Aplicacion.Servicios
{
    public interface IMetodoEntregaAppServicio
    {
        /// <summary>
        /// Método que permite obtener una lista de MetodosEntregaDto
        /// presentes en la tabla respectiva
        /// </summary>
        /// <returns>Task&lt;ICollection&lt;MetodosEntregaDto&gt;&gt;</returns>
        Task<ICollection<MetodoEntregaDto>> ObtenerMetodosEntregaDtoAsync();

        /// <summary>
        /// Método que permite obtener un objeto de tipo MetodosEntregaDto 
        /// por el Id correspondiente
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Task&lt;MetodosEntregaDto&gt;</returns>
        Task<MetodoEntregaDto> ObtenerMetodoEntregaDtoByIdAsync(string Id);

        /// <summary>
        /// Método que permite obtener un objeto de tipo MetodoEntrega 
        /// por el Id correspondiente
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Task&lt;MetodoEntrega&gt;</returns>
        Task<MetodoEntrega> ObtenerMetodoEntregaByIdAsync(string Id);

        /// <summary>
        /// Método que permite agregar un MetodoEntrega a la tabla correspondiente
        /// </summary>
        /// <param name="metodoEntrega"></param>
        /// <returns>Task&lt;MetodoEntregaDto&gt;</returns>
        Task<MetodoEntregaDto> AgregarMetodoEntregaAsync(AgregarMetodoEntregaDto metodoEntrega);

        /// <summary>
        /// Método que permite modificar los valores de un MetodoEntrega 
        /// de la tabla corresponsienrte
        /// </summary>
        /// <param name="metodoEntrega"></param>
        /// <param name="Id"></param>
        /// <returns>Task&lt;bool&gt;</returns>
        Task<bool> ModificarMetodoEntregaAsync(AgregarMetodoEntregaDto metodoEntrega, string Id);

        /// <summary>
        /// Método que permite eliminar un MetodoEntrega de la tabla corresponsiente
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Task&lt;bool&gt;</returns>
        Task<bool> EliminarMetodoEntregaById(string Id);

    }
}
