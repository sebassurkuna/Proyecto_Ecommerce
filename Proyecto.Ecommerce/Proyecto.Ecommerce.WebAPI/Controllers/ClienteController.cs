using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Ecommerce.Aplicacion.Dtos;
using Proyecto.Ecommerce.Aplicacion.Servicios;

namespace Proyecto.Ecommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteAppServicio servicio;

        public ClienteController(IClienteAppServicio servicio)
        {
            this.servicio = servicio;
        }

        [HttpPost]
        public Task<ClienteDto> AgregarClienteAsync([FromBody] ClienteDto clienteDto)
        {
            return servicio.AgregarClienteAsync(clienteDto);
        }

        [HttpDelete]
        public Task<bool> EliminarClienteById(Guid Id)
        {
            return servicio.EliminarClienteById(Id);
        }

        [HttpPut("{Id}")]
        public Task<bool> ModificarClienteAsync([FromBody] ClienteDto clienteDto, Guid Id)
        {
            return servicio.ModificarClienteAsync(clienteDto,Id);
        }

        [HttpGet("{Id}")]
        public Task<ClienteDto> ObtenerClienteDtoByIdAsync(Guid Id)
        {
            return servicio.ObtenerClienteDtoByIdAsync(Id);
        }

        [HttpGet]
        [Authorize]
        public Task<ICollection<ClienteDto>> ObtenerClientesDtoAsync()
        {
            return servicio.ObtenerClientesDtoAsync();
        }

        [HttpGet("/Paginada/")]
        public Task<ICollection<ClienteDto>> GetPaginacion(int limit=0, int offset=0, string nombre="", string? cedula="")
        {
            return servicio.GetPaginacion(limit,offset,nombre,cedula);
        }
    }
}
