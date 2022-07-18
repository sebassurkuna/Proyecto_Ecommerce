using Proyecto.Ecommerce.Aplicacion.Servicios;
using Proyecto.Ecommerce.Dominio.Entidades;
using Proyecto.Ecommerce.Dominio.Repositorio;

namespace Proyecto.Ecommerce.Aplicacion.ImplServicios
{
    public class TipoProductoAppServicio : ITipoProductoAppServicio
    {
        private readonly IRepositorioGenerico<TipoProducto> repositorio;

        public TipoProductoAppServicio(IRepositorioGenerico<TipoProducto> repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<TipoProducto> AgregarTipoProductoAsync(TipoProducto tipoProducto)
        {
            await repositorio.AddAsync(tipoProducto);
            return await ObtenerTipoProductoByIdAsync(tipoProducto.Id);
        }

        public async Task<bool> EliminarTipoProductoById(string Id)
        {
            var tipoProducto = await ObtenerTipoProductoByIdAsync(Id);
            await repositorio.DeleteAsync(tipoProducto);
            return true;
        }

        public async Task<TipoProducto> ModificarTipoProductoAsync(TipoProducto tipoProducto)
        {
            await repositorio.UpdateAsync(tipoProducto);
            return await ObtenerTipoProductoByIdAsync(tipoProducto.Id);
        }

        public Task<TipoProducto> ObtenerTipoProductoByIdAsync(string Id)
        {
            return repositorio.GetByIdAsync(Id);
        }

        public Task<ICollection<TipoProducto>> ObtenerTipoProductosAsync()
        {
            return repositorio.GetAsync();
        }
    }
}
