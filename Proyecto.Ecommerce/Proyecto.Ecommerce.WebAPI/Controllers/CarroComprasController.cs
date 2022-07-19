using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Ecommerce.Aplicacion.Dtos;
using Proyecto.Ecommerce.Aplicacion.Servicios;
using Proyecto.Ecommerce.Dominio.Entidades;

namespace Proyecto.Ecommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarroComprasController : ControllerBase
    {
        private readonly ICarroComprasAppServicio carroCompras;

        public CarroComprasController(ICarroComprasAppServicio carroCompras)
        {
            this.carroCompras = carroCompras;
        }

        [HttpPost("/Orden")]
        public Task<bool> AgregarOrden([FromBody] AgregarOrdenDto ordenDto)
        {
            return carroCompras.AgregarOrden(ordenDto);
        }

        [HttpPost("/Producto")]
        public Task<OrdenItemsDto> AgregarProductosCarro([FromBody] AgregarOrdenItemsDto ordenItemsDto)
        {
            return carroCompras.AgregarProductosCarro(ordenItemsDto);
        }

        [HttpDelete("/Producto/{Id}")]
        public Task<bool> EliminarItemsCarro(Guid Id)
        {
            return carroCompras.EliminarItemsCarro(Id);
        }

        [HttpDelete("/Orden")]
        public Task<bool> VaciarCarro()
        {
            return carroCompras.VaciarCarro();
        }

        [HttpGet("/Stock")]
        public async Task<string> ValidarStock(Guid Id, int cantidadReuqerida)
        {
            var validarStock = await carroCompras.ValidarStock(Id, cantidadReuqerida);
            if (validarStock)
            {
                return "Hay stock";
            }
            else
            {
                return "No hay stock";
            }
        }

        [HttpGet("/Carro")]
        public Task<Orden> VerCarro()
        {
            return carroCompras.VerCarro();
        }
    }
}
