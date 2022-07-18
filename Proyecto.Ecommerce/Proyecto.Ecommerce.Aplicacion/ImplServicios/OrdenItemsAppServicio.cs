using Proyecto.Ecommerce.Aplicacion.Servicios;
using Proyecto.Ecommerce.Dominio.Entidades;
using Proyecto.Ecommerce.Dominio.Repositorio;

namespace Proyecto.Ecommerce.Aplicacion.ImplServicios
{
    public class OrdenItemsAppServicio : IOrdenItemsAppServicio
    {
        private readonly IRepositorioGenerico<OrdenItems> repositorio;

        public OrdenItemsAppServicio(IRepositorioGenerico<OrdenItems> repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<OrdenItems> AgregarOrdenItemsAsync(OrdenItems ordenItems)
        {
            await repositorio.AddAsync(ordenItems);
            return await ObtenerOrdenItemsByIdAsync(ordenItems.Id);
        }

        public async Task<bool> EliminarOrdenItemsById(Guid Id)
        {
            var ordenItems = await ObtenerOrdenItemsByIdAsync(Id);
            await repositorio.DeleteAsync(ordenItems);
            return true;
        }

        public async Task<OrdenItems> ModificarOrdenItemsAsync(OrdenItems ordenItems)
        {
            await repositorio.UpdateAsync(ordenItems);
            return await ObtenerOrdenItemsByIdAsync(ordenItems.Id);
        }

        public Task<OrdenItems> ObtenerOrdenItemsByIdAsync(Guid Id)
        {
            return repositorio.GetByIdAsync(Id);
        }

        public Task<ICollection<OrdenItems>> ObtenerOrdenItemsAsync()
        {
            return repositorio.GetAsync();
        }
    }
}
