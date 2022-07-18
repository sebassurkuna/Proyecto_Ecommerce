using Microsoft.AspNetCore.Mvc;
using Proyecto.Ecommerce.Aplicacion.Servicios;
using Proyecto.Ecommerce.Dominio.Entidades;

namespace Proyecto.Ecommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase, IClienteAppServicio
    {
        private readonly IClienteAppServicio servicio;

        public ClienteController(IClienteAppServicio servicio)
        {
            this.servicio = servicio;
        }

        [HttpPost]
        public Task<Cliente> AgregarClienteAsync([FromBody] Cliente cliente)
        {
            return servicio.AgregarClienteAsync(cliente);
        }

        [HttpDelete]
        public Task<bool> EliminarClienteById(Guid Id)
        {
            return servicio.EliminarClienteById(Id);
        }

        [HttpPut]
        public Task<Cliente> ModificarClienteAsync(Cliente cliente)
        {
            return servicio.ModificarClienteAsync(cliente);
        }

        [HttpGet("{Id}")]
        public Task<Cliente> ObtenerClienteByIdAsync(Guid Id)
        {
            return servicio.ObtenerClienteByIdAsync(Id);
        }

        [HttpGet]
        public Task<ICollection<Cliente>> ObtenerClientesAsync()
        {
            return servicio.ObtenerClientesAsync();
        }
    }
}
