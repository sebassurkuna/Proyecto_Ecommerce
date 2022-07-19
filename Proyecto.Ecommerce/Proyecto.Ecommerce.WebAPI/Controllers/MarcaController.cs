using Microsoft.AspNetCore.Mvc;
using Proyecto.Ecommerce.Aplicacion.Dtos;
using Proyecto.Ecommerce.Aplicacion.Servicios;
using Proyecto.Ecommerce.Dominio.Entidades;

namespace Proyecto.Ecommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly IMarcaAppServicio servicio;

        public MarcaController(IMarcaAppServicio servicio)
        {
            this.servicio = servicio;
        }

        [HttpPost]
        public Task<MarcaDto> AgregarMarcaAsync([FromBody] AgregarMarcaDto marcaDto)
        {
            return servicio.AgregarMarcaAsync(marcaDto);
        }

        [HttpDelete]
        public Task<bool> EliminarMarcaById(string Id)
        {
            return servicio.EliminarMarcaById(Id);
        }

        [HttpPut("{Id}")]
        public async Task<bool> ModificarMarcaAsync([FromBody]AgregarMarcaDto marcaDto, string Id)
        {
            await servicio.ModificarMarcaAsync(marcaDto,Id);
            return true;
        }

        [HttpGet("{Id}")]
        public Task<MarcaDto> ObtenerMarcaDtoByIdAsync(string Id)
        {
            return servicio.ObtenerMarcaDtoByIdAsync(Id);
        }

        [HttpGet]
        public Task<ICollection<MarcaDto>> ObtenerMarcasDtoAsync()
        {
            return servicio.ObtenerMarcasDtoAsync();
        }
    }
}
