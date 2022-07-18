using Microsoft.AspNetCore.Mvc;
using Proyecto.Ecommerce.Aplicacion.Servicios;
using Proyecto.Ecommerce.Dominio.Entidades;

namespace Proyecto.Ecommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoProductoController : ControllerBase, ITipoProductoAppServicio
    {
        private readonly ITipoProductoAppServicio servicio;

        public TipoProductoController(ITipoProductoAppServicio servicio)
        {
            this.servicio = servicio;
        }

        [HttpPost]
        public Task<TipoProducto> AgregarTipoProductoAsync([FromBody] TipoProducto tipoProducto)
        {
            return servicio.AgregarTipoProductoAsync(tipoProducto);
        }

        [HttpDelete]
        public Task<bool> EliminarTipoProductoById(string Id)
        {
            return servicio.EliminarTipoProductoById(Id);
        }

        [HttpPut]
        public Task<TipoProducto> ModificarTipoProductoAsync(TipoProducto tipoProducto)
        {
            return servicio.ModificarTipoProductoAsync(tipoProducto);
        }

        [HttpGet("{Id}")]
        public Task<TipoProducto> ObtenerTipoProductoByIdAsync(string Id)
        {
            return servicio.ObtenerTipoProductoByIdAsync(Id);
        }

        [HttpGet]
        public Task<ICollection<TipoProducto>> ObtenerTipoProductosAsync()
        {
            return servicio.ObtenerTipoProductosAsync();
        }
    }
}
