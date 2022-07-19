using Proyecto.Ecommerce.Aplicacion.Dtos;
using Proyecto.Ecommerce.Dominio.Entidades;

namespace Proyecto.Ecommerce.Aplicacion.Servicios
{
    public interface ICarroComprasAppServicio
    {
        Task<bool> AgregarOrden(AgregarOrdenDto ordenDto);
        Task<OrdenItemsDto> AgregarProductosCarro(AgregarOrdenItemsDto ordenItemsDto);
        Task<bool> EliminarItemsCarro(Guid Id);
        Task<bool> VaciarCarro();
        Task<bool> ValidarStock(Guid Id, int cantidadReuqerida);
        Task<Orden> VerCarro();
    }
}