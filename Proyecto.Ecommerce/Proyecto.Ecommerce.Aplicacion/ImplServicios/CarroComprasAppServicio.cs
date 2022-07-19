using AutoMapper;
using Proyecto.Ecommerce.Aplicacion.Dtos;
using Proyecto.Ecommerce.Aplicacion.Servicios;
using Proyecto.Ecommerce.Dominio.Entidades;
using Proyecto.Ecommerce.Dominio.Repositorio;

namespace Proyecto.Ecommerce.Aplicacion.ImplServicios
{
    public class CarroComprasAppServicio : ICarroComprasAppServicio
    {
        private readonly IRepositorioGenerico<OrdenItems> repositorioOItem;
        private readonly IRepositorioGenerico<Orden> repositorioOrden;
        private readonly IMapper mapper;
        private readonly IProductoAppServicio producto;
        private readonly IMetodoEntregaAppServicio metodo;
        private readonly IClienteAppServicio cliente;

        public CarroComprasAppServicio(IRepositorioGenerico<OrdenItems> repositorioOItem, IRepositorioGenerico<Orden> repositorioOrden,
            IMapper mapper, IProductoAppServicio producto, IMetodoEntregaAppServicio metodo, IClienteAppServicio cliente)
        {
            this.repositorioOItem = repositorioOItem;
            this.repositorioOrden = repositorioOrden;
            this.mapper = mapper;
            this.producto = producto;
            this.metodo = metodo;
            this.cliente = cliente;
        }

        public async Task<bool> ValidarStock(Guid Id, int cantidadReuqerida)
        {
            var product = await producto.ObtenerProductoByIdAsync(Id);
            var stock = product.Stock;
            if (cantidadReuqerida > stock)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<OrdenItemsDto> AgregarProductosCarro(AgregarOrdenItemsDto ordenItemsDto)
        {
            var validarStock = ValidarStock(ordenItemsDto.ProductoId, ordenItemsDto.CantidadProducto);
            if (!validarStock.Result)
            {
                throw new ArgumentException("No se tiene el stock requerido");
            }
            var ordenItems = mapper.Map<OrdenItems>(ordenItemsDto);
            ordenItems.Id = Guid.NewGuid();
            ordenItems.FechaCreacion = DateTime.Now;
            var product = await producto.ObtenerProductoByIdAsync(ordenItemsDto.ProductoId);
            ordenItems.Producto = product;

            //Añadir
            await repositorioOItem.AddAsync(ordenItems);

            var ordenItemsMapp = mapper.Map<OrdenItemsDto>(ordenItems);
            ordenItemsMapp.NombreProducto = product.Nombre;

            //Modificar Stock producto
            product.Stock = product.Stock - ordenItems.CantidadProducto;
            var agregarProducto = mapper.Map<AgregarProductoDto>(product);
            await producto.ModificarProductoAsync(agregarProducto, product.Id);

            return ordenItemsMapp;
        }

        public async Task<bool> EliminarItemsCarro(Guid Id)
        {
            var ordenItem = await repositorioOItem.GetByIdAsync(Id);
            await repositorioOItem.DeleteAsync(ordenItem);
            return true;
        }

        public async Task<bool> AgregarOrden(AgregarOrdenDto ordenDto)
        {
            var orden = mapper.Map<Orden>(ordenDto);
            orden.Id = Guid.NewGuid();
            orden.Cliente = await cliente.ObtenerClienteByIdAsync(ordenDto.ClienteId);
            orden.OrdenItems = (List<OrdenItems>?)await repositorioOItem.GetAsync();
            orden.MetodoEntrega = await metodo.ObtenerMetodoEntregaByIdAsync(ordenDto.MetodoEntregaId);
            orden.SubTotal = 0;
            foreach (var item in orden.OrdenItems)
            {
                var product = await producto.ObtenerProductoByIdAsync(item.ProductoId);
                item.Producto = product;
                orden.SubTotal = orden.SubTotal + item.Producto.Precio;
            }

            orden.Iva = 12;
            orden.Total = orden.SubTotal * (1 + (orden.Iva / 100));

            if (orden.OrdenItems.Count() <= 0)
            {
                throw new ArgumentException("No hay objetos para añadir al carro de compras");
            }

            await repositorioOrden.AddAsync(orden);
            return true;
        }

        public async Task<Orden> VerCarro()
        {
            var ordenConsulta = repositorioOrden.GetQueryable();
            var orden = ordenConsulta.FirstOrDefault();
            if (orden == null)
            {
                throw new ArgumentException("No se a creado el carro de compras");
            }
            orden.Cliente = await cliente.ObtenerClienteByIdAsync(orden.ClienteId);
            orden.OrdenItems = (List<OrdenItems>?)await repositorioOItem.GetAsync();
            foreach (var item in orden.OrdenItems)
            {
                var product = await producto.ObtenerProductoByIdAsync(item.ProductoId);
                item.Producto = product;
            }
            orden.MetodoEntrega = await metodo.ObtenerMetodoEntregaByIdAsync(orden.MetodoEntregaId);
            return orden;
        }

        public async Task<bool> VaciarCarro()
        {
            var ordenConsulta = repositorioOrden.GetQueryable();
            var orden = ordenConsulta.FirstOrDefault();
            if (orden == null)
            {
                throw new ArgumentException("No existe carro de compras");
            }
            var ordenItems = (List<OrdenItems>?)await repositorioOItem.GetAsync();
            foreach (var item in ordenItems)
            {
                var product = await producto.ObtenerProductoByIdAsync(item.ProductoId);
                product.Stock = product.Stock + item.CantidadProducto;
                var agregarProducto = mapper.Map<AgregarProductoDto>(product);
                await producto.ModificarProductoAsync(agregarProducto, product.Id);
            }
            await repositorioOItem.DeleteAllAsync(ordenItems);
            await repositorioOrden.DeleteAsync(orden);
            return true;
        }
    }
}
