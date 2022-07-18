using Microsoft.AspNetCore.Mvc;
using Proyecto.Ecommerce.Aplicacion.Servicios;
using Proyecto.Ecommerce.Dominio.Entidades;

namespace Proyecto.Ecommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase, IMarcaAppServicio
    {
        private readonly IMarcaAppServicio servicio;

        public MarcaController(IMarcaAppServicio servicio)
        {
            this.servicio = servicio;
        }

        [HttpPost]
        public Task<Marca> AgregarMarcaAsync([FromBody] Marca marca)
        {
            return servicio.AgregarMarcaAsync(marca);
        }

        [HttpDelete]
        public Task<bool> EliminarMarcaById(string Id)
        {
            return servicio.EliminarMarcaById(Id);
        }

        [HttpPut]
        public Task<Marca> ModificarMarcaAsync(Marca marca)
        {
            return servicio.ModificarMarcaAsync(marca);
        }

        [HttpGet("{Id}")]
        public Task<Marca> ObtenerMarcaByIdAsync(string Id)
        {
            return servicio.ObtenerMarcaByIdAsync(Id);
        }

        [HttpGet]
        public Task<ICollection<Marca>> ObtenerMarcasAsync()
        {
            return servicio.ObtenerMarcasAsync();
        }
    }
}
