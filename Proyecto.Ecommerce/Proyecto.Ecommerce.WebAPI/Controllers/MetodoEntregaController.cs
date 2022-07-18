using Microsoft.AspNetCore.Mvc;
using Proyecto.Ecommerce.Aplicacion.Servicios;
using Proyecto.Ecommerce.Dominio.Entidades;

namespace Proyecto.Ecommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetodoEntregaController : ControllerBase, IMetodoEntregaAppServicio
    {
        private readonly IMetodoEntregaAppServicio servicio;

        public MetodoEntregaController(IMetodoEntregaAppServicio servicio)
        {
            this.servicio = servicio;
        }

        [HttpPost]
        public Task<MetodoEntrega> AgregarMetodoEntregaAsync([FromBody] MetodoEntrega metodoEntrega)
        {
            return servicio.AgregarMetodoEntregaAsync(metodoEntrega);
        }

        [HttpDelete]
        public Task<bool> EliminarMetodoEntregaById(string Id)
        {
            return servicio.EliminarMetodoEntregaById(Id);
        }

        [HttpPut]
        public Task<MetodoEntrega> ModificarMetodoEntregaAsync(MetodoEntrega metodoEntrega)
        {
            return servicio.ModificarMetodoEntregaAsync(metodoEntrega);
        }

        [HttpGet("{Id}")]
        public Task<MetodoEntrega> ObtenerMetodoEntregaByIdAsync(string Id)
        {
            return servicio.ObtenerMetodoEntregaByIdAsync(Id);
        }

        [HttpGet]
        public Task<ICollection<MetodoEntrega>> ObtenerMetodosEntregaAsync()
        {
            return servicio.ObtenerMetodosEntregaAsync();
        }
    }
}
