using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Ecommerce.Dominio.Repositorio
{
    public interface IRepositorioGenerico<T>
    {
        /// <summary>
        /// Método que obtiene toda la información de la tabla correspondiete 
        /// a la entidad.
        /// </summary>
        /// <returns> ICollection&lt;Entidad&gt; </returns>
        Task<ICollection<T>> GetAsync();

        /// <summary>
        /// Método que obtiene un objeto del tipo IQueryable que permite 
        /// realizar busquedas con LINQ sobre la tabla de la correspondiente entidad. 
        /// </summary>
        /// <returns>IQueryable&lt;Entidad&gt;</returns>
        IQueryable<T> GetQueryable();

        /// <summary>
        /// Método que permite obtener un elemento de una tabla de una específica 
        /// entidad mediante el parámetro Id. 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Task&lt;Entidad&gt;</returns>
        Task<T> GetByIdAsync(string Id);

        /// <summary>
        /// Método que permite obtener un elemento de una tabla de una específica 
        /// entidad mediante el parámetro Id. 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Task&lt;Entidad&gt;</returns>
        Task<T> GetByIdAsync(Guid Id);

        /// <summary>
        /// Método que permite añadir una entidad en la tabla corresponsiente a la entidad
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns>Task</returns>
        Task AddAsync(T Entity);

        /// <summary>
        /// Método que permite modificar los valores de una entidad en la tabla corresponsiente a la entidad
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns>Task</returns>
        Task UpdateAsync(T Entity);

        /// <summary>
        /// Método que permite eliminar una entidad presente en la tabla correspondinte a la entidad
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns>Task&lt;bool&gt;</returns>
        Task<bool> DeleteAsync(T Entity);
    }
}
