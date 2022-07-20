using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Ecommerce.Aplicacion.Dtos;
using Proyecto.Ecommerce.Aplicacion.Servicios;
using Proyecto.Ecommerce.Dominio.Entidades;

namespace Proyecto.Ecommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TipoProductoController : ControllerBase
    {
        private readonly ITipoProductoAppServicio servicio;

        public TipoProductoController(ITipoProductoAppServicio servicio)
        {
            this.servicio = servicio;
        }

        [HttpPost]
        public Task<TipoProductoDto> AgregarTipoProductoAsync([FromBody] AgregarTipoProductoDto tipoProductoDto)
        {
            return servicio.AgregarTipoProductoAsync(tipoProductoDto);
        }

        [HttpDelete]
        public Task<bool> EliminarTipoProductoById(string Id)
        {
            return servicio.EliminarTipoProductoById(Id);
        }

        [HttpPut("{Id}")]
        public Task<bool> ModificarTipoProductoAsync([FromBody] AgregarTipoProductoDto tipoProductoDto, string Id)
        {
            return servicio.ModificarTipoProductoAsync(tipoProductoDto,Id);
        }

        [HttpGet("{Id}")]
        public Task<TipoProductoDto> ObtenerTipoProductoDtoByIdAsync(string Id)
        {
            return servicio.ObtenerTipoProductoDtoByIdAsync(Id);
        }

        [HttpGet]
        public Task<ICollection<TipoProductoDto>> ObtenerTipoProductosDtoAsync()
        {
            return servicio.ObtenerTipoProductosDtoAsync();
        }
    }
}
