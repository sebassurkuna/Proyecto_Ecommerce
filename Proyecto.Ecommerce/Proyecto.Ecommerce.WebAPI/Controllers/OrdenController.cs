using Microsoft.AspNetCore.Mvc;
using Proyecto.Ecommerce.Aplicacion.Servicios;
using Proyecto.Ecommerce.Dominio.Entidades;

namespace Proyecto.Ecommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenController : ControllerBase, IOrdenAppServicio
    {
        private readonly IOrdenAppServicio servicio;

        public OrdenController(IOrdenAppServicio servicio)
        {
            this.servicio = servicio;
        }

        [HttpPost]
        public Task<Orden> AgregarOrdenAsync([FromBody] Orden orden)
        {
            return servicio.AgregarOrdenAsync(orden);
        }

        [HttpDelete]
        public Task<bool> EliminarOrdenById(Guid Id)
        {
            return servicio.EliminarOrdenById(Id);
        }

        [HttpPut]
        public Task<Orden> ModificarOrdenAsync(Orden orden)
        {
            return servicio.ModificarOrdenAsync(orden);
        }

        [HttpGet("{Id}")]
        public Task<Orden> ObtenerOrdenByIdAsync(Guid Id)
        {
            return servicio.ObtenerOrdenByIdAsync(Id);
        }

        [HttpGet]
        public Task<ICollection<Orden>> ObtenerOrdenesAsync()
        {
            return servicio.ObtenerOrdenesAsync();
        }
    }
}
