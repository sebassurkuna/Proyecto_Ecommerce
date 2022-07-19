using Proyecto.Ecommerce.Aplicacion.Dtos;
using Proyecto.Ecommerce.Dominio.Entidades;

namespace Proyecto.Ecommerce.Aplicacion.Servicios
{
    public interface IMetodoEntregaAppServicio
    {
        Task<ICollection<MetodoEntregaDto>> ObtenerMetodosEntregaDtoAsync();
        Task<MetodoEntregaDto> ObtenerMetodoEntregaDtoByIdAsync(string Id);
        Task<MetodoEntrega> ObtenerMetodoEntregaByIdAsync(string Id);
        Task<MetodoEntregaDto> AgregarMetodoEntregaAsync(AgregarMetodoEntregaDto metodoEntrega);
        Task<bool> ModificarMetodoEntregaAsync(AgregarMetodoEntregaDto metodoEntrega, string Id);
        Task<bool> EliminarMetodoEntregaById(string Id);

    }
}
