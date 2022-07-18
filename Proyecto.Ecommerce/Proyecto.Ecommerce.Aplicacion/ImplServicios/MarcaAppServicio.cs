using Proyecto.Ecommerce.Aplicacion.Servicios;
using Proyecto.Ecommerce.Dominio.Entidades;
using Proyecto.Ecommerce.Dominio.Repositorio;

namespace Proyecto.Ecommerce.Aplicacion.ImplServicios
{
    public class MarcaAppServicio : IMarcaAppServicio
    {
        private readonly IRepositorioGenerico<Marca> repositorio;

        public MarcaAppServicio(IRepositorioGenerico<Marca> repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<Marca> AgregarMarcaAsync(Marca marca)
        {
            await repositorio.AddAsync(marca);
            return await ObtenerMarcaByIdAsync(marca.Id);
        }

        public async Task<bool> EliminarMarcaById(string Id)
        {
            var marca = await ObtenerMarcaByIdAsync(Id);
            await repositorio.DeleteAsync(marca);
            return true;
        }

        public async Task<Marca> ModificarMarcaAsync(Marca marca)
        {
            await repositorio.UpdateAsync(marca);
            return await ObtenerMarcaByIdAsync(marca.Id);
        }

        public Task<Marca> ObtenerMarcaByIdAsync(string Id)
        {
            return repositorio.GetByIdAsync(Id);
        }

        public Task<ICollection<Marca>> ObtenerMarcasAsync()
        {
            return repositorio.GetAsync();
        }
    }
}
