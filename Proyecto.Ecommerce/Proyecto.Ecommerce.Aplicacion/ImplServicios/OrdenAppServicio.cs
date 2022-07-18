using Proyecto.Ecommerce.Aplicacion.Servicios;
using Proyecto.Ecommerce.Dominio.Entidades;
using Proyecto.Ecommerce.Dominio.Repositorio;

namespace Proyecto.Ecommerce.Aplicacion.ImplServicios
{
    public class OrdenAppServicio : IOrdenAppServicio
    {
        private readonly IRepositorioGenerico<Orden> repositorio;

        public OrdenAppServicio(IRepositorioGenerico<Orden> repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<Orden> AgregarOrdenAsync(Orden orden)
        {
            await repositorio.AddAsync(orden);
            return await ObtenerOrdenByIdAsync(orden.Id);
        }

        public async Task<bool> EliminarOrdenById(Guid Id)
        {
            var orden = await ObtenerOrdenByIdAsync(Id);
            await repositorio.DeleteAsync(orden);
            return true;
        }

        public async Task<Orden> ModificarOrdenAsync(Orden orden)
        {
            await repositorio.UpdateAsync(orden);
            return await ObtenerOrdenByIdAsync(orden.Id);
        }

        public Task<Orden> ObtenerOrdenByIdAsync(Guid Id)
        {
            return repositorio.GetByIdAsync(Id);
        }

        public Task<ICollection<Orden>> ObtenerOrdenesAsync()
        {
            return repositorio.GetAsync();
        }
    }
}
