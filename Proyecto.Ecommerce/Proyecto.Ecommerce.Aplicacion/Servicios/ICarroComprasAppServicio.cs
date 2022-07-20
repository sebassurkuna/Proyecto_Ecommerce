using Proyecto.Ecommerce.Aplicacion.Dtos;

namespace Proyecto.Ecommerce.Aplicacion.Servicios
{
    public interface ICarroComprasAppServicio
    {
        /// <summary>
        /// Metodo que permite agregar una Orden a la tabla Ordenes
        /// </summary>
        /// <param name="ordenDto"></param>
        /// <returns>Task&lt;bool&gt;</returns>
        Task<bool> AgregarOrden(AgregarOrdenDto ordenDto);

        /// <summary>
        /// Metodo que permite Agregar OrdenItems a la tabla OrdenItems
        /// </summary>
        /// <param name="ordenItemsDto"></param>
        /// <returns>Task&lt;OrdenItemsDto&gt;</returns>
        Task<OrdenItemsDto> AgregarProductosCarro(AgregarOrdenItemsDto ordenItemsDto);

        /// <summary>
        /// Metodo que permite eliminar OrdenItems de la tabla OrdenItems
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Task&lt;bool&gt;</returns>
        Task<bool> EliminarItemsCarro(Guid Id);

        /// <summary>
        /// Metodo que permite eliminar toda la informacion de la tablas OrdenItems y Ordenes
        /// </summary>
        /// <returns>Task&lt;bool&gt;</returns>
        Task<bool> VaciarCarro();

        /// <summary>
        /// Metodo que permite validar si existe el stock requerido
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="cantidadReuqerida"></param>
        /// <returns>Task&lt;bool&gt;</returns>
        Task<bool> ValidarStock(Guid Id, int cantidadReuqerida);

        /// <summary>
        /// Metodo que permite obtener un objeto OrdenCarroDto simulando ser un carro de compras
        /// </summary>
        /// <returns>Task&lt;OrdenCarroDto&gt;</returns>
        Task<OrdenCarroDto> VerCarro();

        /// <summary>
        /// Metodo que permite modificar el Stock de los productos
        /// </summary>
        /// <param name="cantidadEliminar"></param>
        /// <param name="IdProducto"></param>
        /// <returns>Task&lt;bool&gt;</returns>
        Task<bool> EliminarProductosStock(int cantidadEliminar, Guid IdProducto);

        /// <summary>
        /// Metodo que permite modificar los valores de la tabla Ordenes
        /// </summary>
        /// <param name="ordenDto"></param>
        /// <param name="Id"></param>
        /// <returns>Task&lt;bool&gt;</returns>
        Task<bool> ModificarOrden(AgregarOrdenDto ordenDto, Guid Id);
    }
}