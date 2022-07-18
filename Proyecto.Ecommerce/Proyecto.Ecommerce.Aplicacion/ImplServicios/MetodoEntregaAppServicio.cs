using Proyecto.Ecommerce.Aplicacion.Servicios;
using Proyecto.Ecommerce.Dominio.Entidades;
using Proyecto.Ecommerce.Dominio.Repositorio;

namespace Proyecto.Ecommerce.Aplicacion.ImplServicios
{
    public class MetodoEntregaAppServicio : IMetodoEntregaAppServicio
    {
        private readonly IRepositorioGenerico<MetodoEntrega> repositorio;

        public MetodoEntregaAppServicio(IRepositorioGenerico<MetodoEntrega> repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<MetodoEntrega> AgregarMetodoEntregaAsync(MetodoEntrega metodoEntrega)
        {
            await repositorio.AddAsync(metodoEntrega);
            return await ObtenerMetodoEntregaByIdAsync(metodoEntrega.Id);
        }

        public async Task<bool> EliminarMetodoEntregaById(string Id)
        {
            var metodoEntrega = await ObtenerMetodoEntregaByIdAsync(Id);
            await repositorio.DeleteAsync(metodoEntrega);
            return true;
        }

        public async Task<MetodoEntrega> ModificarMetodoEntregaAsync(MetodoEntrega metodoEntrega)
        {
            await repositorio.UpdateAsync(metodoEntrega);
            return await ObtenerMetodoEntregaByIdAsync(metodoEntrega.Id);
        }

        public Task<MetodoEntrega> ObtenerMetodoEntregaByIdAsync(string Id)
        {
            return repositorio.GetByIdAsync(Id);
        }

        public Task<ICollection<MetodoEntrega>> ObtenerMetodosEntregaAsync()
        {
            return repositorio.GetAsync();
        }
    }
}
