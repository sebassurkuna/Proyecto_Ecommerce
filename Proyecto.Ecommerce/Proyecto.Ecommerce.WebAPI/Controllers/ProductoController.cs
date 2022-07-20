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
    public class ProductoController : ControllerBase
    {
        private readonly IProductoAppServicio servicio;

        public ProductoController(IProductoAppServicio servicio)
        {
            this.servicio = servicio;
        }

        [HttpPost]
        public Task<ProductoDto> AgregarProductoAsync([FromBody] AgregarProductoDto productoDto)
        {
            return servicio.AgregarProductoAsync(productoDto);
        }

        [HttpDelete]
        public Task<bool> EliminarProductoById(Guid Id)
        {
            return servicio.EliminarProductoById(Id);
        }

        [HttpPut("{Id}")]
        public Task<bool> ModificarProductoAsync([FromBody] AgregarProductoDto productoDto, Guid Id)
        {
            return servicio.ModificarProductoAsync(productoDto, Id);
        }

        [HttpGet("{Id}")]
        public Task<ProductoDto> ObtenerProductoDtoByIdAsync(Guid Id)
        {
            return servicio.ObtenerProductoDtoByIdAsync(Id);
        }

        [HttpGet]
        public Task<ICollection<ProductoDto>> ObtenerProductosDtoAsync()
        {
            return servicio.ObtenerProductosDtoAsync();
        }

        [HttpGet("/Paginado/")]
        public Task<ICollection<ProductoDto>> GetPaginacion(int limit = 0, int offset = 0, string nombre = "", long precio = 0)
        {
            return servicio.GetPaginacion(limit,offset,nombre,precio);
        }
    }
}
