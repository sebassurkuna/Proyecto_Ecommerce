using Proyecto.Ecommerce.Aplicacion.Servicios;
using Proyecto.Ecommerce.Dominio.Entidades;
using Proyecto.Ecommerce.Dominio.Repositorio;

namespace Proyecto.Ecommerce.Aplicacion.ImplServicios
{
    public class ClienteAppServicio : IClienteAppServicio
    {
        private readonly IRepositorioGenerico<Cliente> repositorio;

        public ClienteAppServicio(IRepositorioGenerico<Cliente> repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<Cliente> AgregarClienteAsync(Cliente cliente)
        {
            await repositorio.AddAsync(cliente);
            return await ObtenerClienteByIdAsync(cliente.Id);
        }

        public async Task<bool> EliminarClienteById(Guid Id)
        {
            var cliente = await ObtenerClienteByIdAsync(Id);
            await repositorio.DeleteAsync(cliente);
            return true;
        }

        public async Task<Cliente> ModificarClienteAsync(Cliente cliente)
        {
            await repositorio.UpdateAsync(cliente);
            return await ObtenerClienteByIdAsync(cliente.Id);
        }

        public Task<Cliente> ObtenerClienteByIdAsync(Guid Id)
        {
            return repositorio.GetByIdAsync(Id);
        }

        public Task<ICollection<Cliente>> ObtenerClientesAsync()
        {
            return repositorio.GetAsync();
        }
    }
}
