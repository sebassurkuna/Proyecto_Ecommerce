using Microsoft.AspNetCore.Mvc;
using Proyecto.Ecommerce.Aplicacion.Servicios;
using Proyecto.Ecommerce.Dominio.Entidades;

namespace Proyecto.Ecommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase, IProductoAppServicio
    {
        private readonly IProductoAppServicio servicio;

        public ProductoController(IProductoAppServicio servicio)
        {
            this.servicio = servicio;
        }

        [HttpPost]
        public Task<Producto> AgregarProductoAsync([FromBody] Producto producto)
        {
            return servicio.AgregarProductoAsync(producto);
        }

        [HttpDelete]
        public Task<bool> EliminarProductoById(Guid Id)
        {
            return servicio.EliminarProductoById(Id);
        }

        [HttpPut]
        public Task<Producto> ModificarProductoAsync(Producto producto)
        {
            return servicio.ModificarProductoAsync(producto);
        }

        [HttpGet("{Id}")]
        public Task<Producto> ObtenerProductoByIdAsync(Guid Id)
        {
            return servicio.ObtenerProductoByIdAsync(Id);
        }

        [HttpGet]
        public Task<ICollection<Producto>> ObtenerProductosAsync()
        {
            return servicio.ObtenerProductosAsync();
        }
    }
}
