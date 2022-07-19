using Microsoft.AspNetCore.Mvc;
using Proyecto.Ecommerce.Aplicacion.Dtos;
using Proyecto.Ecommerce.Aplicacion.Servicios;
using Proyecto.Ecommerce.Dominio.Entidades;

namespace Proyecto.Ecommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetodoEntregaController : ControllerBase
    {
        private readonly IMetodoEntregaAppServicio servicio;

        public MetodoEntregaController(IMetodoEntregaAppServicio servicio)
        {
            this.servicio = servicio;
        }

        [HttpPost]
        public Task<MetodoEntregaDto> AgregarMetodoEntregaAsync([FromBody] AgregarMetodoEntregaDto metodoEntrega)
        {
            return servicio.AgregarMetodoEntregaAsync(metodoEntrega);
        }

        [HttpDelete]
        public Task<bool> EliminarMetodoEntregaById(string Id)
        {
            return servicio.EliminarMetodoEntregaById(Id);
        }

        [HttpPut("{Id}")]
        public Task<bool> ModificarMetodoEntregaAsync(AgregarMetodoEntregaDto metodoEntregaDto,string Id)
        {
            return servicio.ModificarMetodoEntregaAsync(metodoEntregaDto,Id);
        }

        [HttpGet("{Id}")]
        public Task<MetodoEntregaDto> ObtenerMetodoEntregaDtoByIdAsync(string Id)
        {
            return servicio.ObtenerMetodoEntregaDtoByIdAsync(Id);
        }

        [HttpGet]
        public Task<ICollection<MetodoEntregaDto>> ObtenerMetodosEntregaDtoAsync()
        {
            return servicio.ObtenerMetodosEntregaDtoAsync();
        }
    }
}
