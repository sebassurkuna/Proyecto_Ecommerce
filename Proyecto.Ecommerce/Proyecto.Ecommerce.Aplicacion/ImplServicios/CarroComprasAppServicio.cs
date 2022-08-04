using AutoMapper;
using FluentValidation;
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
        private readonly IValidator<AgregarOrdenDto> validatorOrder;
        private readonly IValidator<AgregarOrdenItemsDto> validatorOItems;

        public CarroComprasAppServicio(IRepositorioGenerico<OrdenItems> repositorioOItem, IRepositorioGenerico<Orden> repositorioOrden,
            IMapper mapper, IProductoAppServicio producto, IMetodoEntregaAppServicio metodo, IClienteAppServicio cliente,
            IValidator<AgregarOrdenDto> validatorOrder, IValidator<AgregarOrdenItemsDto> validatorOItems)
        {
            this.repositorioOItem = repositorioOItem;
            this.repositorioOrden = repositorioOrden;
            this.mapper = mapper;
            this.producto = producto;
            this.metodo = metodo;
            this.cliente = cliente;
            this.validatorOrder = validatorOrder;
            this.validatorOItems = validatorOItems;
        }

        #region Metodo Validar Stock
        //Método que permite validar el stock del algun producto
        public async Task<bool> ValidarStock(Guid Id, int cantidadReuqerida)
        {
            //Obtener producto por Id
            var product = await producto.ObtenerProductoByIdAsync(Id);
            //Extraer el stock del producto
            var stock = product.Stock;
            //Validad el stock con la cantidad de producto requerido
            if (cantidadReuqerida > stock)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region Metodo Eliminar productos stock

        //Método que permite modificar el stock de los productos cuando sea necesario
        public async Task<bool> EliminarProductosStock(int cantidadEliminar, Guid IdProducto)
        {
            //Obtener producto por Id
            var product = await producto.ObtenerProductoByIdAsync(IdProducto);
            //Modificar la propiedad Stock
            product.Stock = product.Stock - cantidadEliminar;
            //Mapear de Producto--->AgregarProductoDto
            var agregarProducto = mapper.Map<AgregarProductoDto>(product);
            //Modificar Producto con nuevo stock
            await producto.ModificarProductoAsync(agregarProducto, product.Id);
            return true;
        }
        #endregion

        #region Metodo Agregar Productos Carro 
        //Método que permite agregar objetos de tipo OrdenItems simulando ser objetos
        //del carro de compras
        public async Task<OrdenItemsDto> AgregarProductosCarro(AgregarOrdenItemsDto ordenItemsDto)
        {
            //Validar
            //validatorOItems.ValidateAndThrow(ordenItemsDto);

            //Validar el stock solicitado
            var validarStock = ValidarStock(ordenItemsDto.ProductoId, ordenItemsDto.CantidadProducto);
            //Lanzar excepcion si no se cuenta con stock
            if (!validarStock.Result)
            {
                throw new ArgumentException("No se tiene el stock requerido");
            }

            //Se valida si el objeto es repetido
            var validarItemRepetido = await repositorioOItem.GetAsync();
            var validacionRepetido = false;
            var idValidacion = new Guid();
            foreach (var item in validarItemRepetido)
            {
                //Si el producto es repetido se devuelve true y el Id del producto
                if (item.ProductoId == ordenItemsDto.ProductoId)
                {
                    validacionRepetido = true;
                    idValidacion = item.Id;
                }
            }

            //Si validacionRepetido==true, se modifica el objeto ya existente con el nuevo stock
            if (validacionRepetido)
            {
                //Obtener el objeto ya existente
                var ordenItemUpdate = await repositorioOItem.GetByIdAsync(idValidacion);
                //Modificar stock de producto
                await EliminarProductosStock(ordenItemsDto.CantidadProducto, ordenItemUpdate.ProductoId);
                //Modificar cantidad de producto del objeto
                ordenItemUpdate.CantidadProducto= ordenItemUpdate.CantidadProducto +ordenItemsDto.CantidadProducto;
                //Modificar el objeto con la nueva informacion de cantidad de producto
                await repositorioOItem.UpdateAsync(ordenItemUpdate);
                //Obtener producto
                var productName = await producto.ObtenerProductoByIdAsync(ordenItemUpdate.ProductoId);
                //Mapear de OrdenItems--->OrdenItemsDto
                var ordenItemsMappUpdate = mapper.Map<OrdenItemsDto>(ordenItemUpdate);
                //Agregar el nombre del producto
                ordenItemsMappUpdate.NombreProducto = productName.Nombre;
                return ordenItemsMappUpdate;
            }

            //Mapear de AgregarOrdenItemsDto--->OrdenItems
            var ordenItems = mapper.Map<OrdenItems>(ordenItemsDto);
            //Agregar propiedades faltantes
            ordenItems.Id = Guid.NewGuid();
            ordenItems.FechaCreacion = DateTime.Now;
            var product = await producto.ObtenerProductoByIdAsync(ordenItemsDto.ProductoId);
            ordenItems.Producto = product;

            //Agregar objeto a la tabla
            await repositorioOItem.AddAsync(ordenItems);

            //Mapear de OrdenItems--->OrdenItemsDto
            var ordenItemsMapp = mapper.Map<OrdenItemsDto>(ordenItems);
            //Agregar el nombre del producto
            ordenItemsMapp.NombreProducto = product.Nombre;

            //Modificar Stock producto
            await EliminarProductosStock(ordenItems.CantidadProducto, product.Id);

            return ordenItemsMapp;
        }
        #endregion

        #region Metodo Eliminar Items del Carro
        //Método que nos permite eliminar objetos de tipo OrdenItems de la tabla respectiva
        //simulando estos ser Items del carro de compras
        public async Task<bool> EliminarItemsCarro(Guid Id)
        {
            //Obtener OrdenItem por Id
            var ordenItem = await repositorioOItem.GetByIdAsync(Id);
            //Eliminar entidad de la tabla
            await repositorioOItem.DeleteAsync(ordenItem);
            //Modificar Stock del producto (añadir)
            await EliminarProductosStock(-ordenItem.CantidadProducto, ordenItem.ProductoId);
            return true;
        }
        #endregion

        #region Metodo Agregar Orden
        //Metodo que nos permite agregar el objeto Orden a la tabla correspondiente
        //simulando ser este el carro de compras 
        //***NOTA***
        //1.-Solo se puede tener una sola orden activa (un solo carro de compras)
        //2.-Para modificar el carro de compras se debe usar este metodo con la Id
        //de cliente correspondiente 
        public async Task<bool> AgregarOrden(AgregarOrdenDto ordenDto)
        {
            //Validar
            //validatorOrder.ValidateAndThrow(ordenDto);

            //Obtener la consulta
            var ordenConsulta = repositorioOrden.GetQueryable();
            //Como solo hay uno, se escoje el primero o null
            var ordenValidar = ordenConsulta.FirstOrDefault();
            //Validar si existe orden
            if (ordenValidar != null)
            {
                //Si existe orden y tiene el mismo Id de cliente se realiza la
                //modificacion de la orden
                if (ordenValidar.ClienteId == ordenDto.ClienteId)
                {
                    await ModificarOrden(ordenDto, ordenValidar.Id);
                    return true;
                }
                else
                {
                    throw new ArgumentException("Ya existe carro de compras activo para un usuario");
                }
                
            }

            //Mepar de AgregarOrdenDto--->Orden
            var orden = mapper.Map<Orden>(ordenDto);
            //Agregar parametros faltantes
            orden.Id = Guid.NewGuid();
            orden.Cliente = await cliente.ObtenerClienteByIdAsync(ordenDto.ClienteId);
            orden.OrdenItems = (List<OrdenItems>?)await repositorioOItem.GetAsync();
            orden.MetodoEntrega = await metodo.ObtenerMetodoEntregaByIdAsync(ordenDto.MetodoEntregaId);

            //Sumar todos los valores de productos tomando en cuenta la cantidad de elementos
            orden.SubTotal = 0;
            foreach (var item in orden.OrdenItems)
            {
                var product = await producto.ObtenerProductoByIdAsync(item.ProductoId);
                item.Producto = product;
                orden.SubTotal = orden.SubTotal + (item.Producto.Precio*item.CantidadProducto);
            }

            orden.Iva = 12;
            //Calcular el total incluyendo IVA y coste de entrega
            orden.Total = orden.SubTotal * (1 + ((long)orden.Iva / 100));
            
            //Validar si existen productos para añadir al carro
            if (orden.OrdenItems.Count() <= 0)
            {
                throw new ArgumentException("No hay objetos para añadir al carro de compras");
            }

            //Agregar orden
            await repositorioOrden.AddAsync(orden);
            return true;
        }
        #endregion

        #region Modificar Orden
        //Metodo que permite modificar los valores de las propiedades de la entidad Orden
        public async Task<bool> ModificarOrden(AgregarOrdenDto ordenDto, Guid Id)
        {
            //Validar
            //validatorOrder.ValidateAndThrow(ordenDto);

            //Obtener el objetos Orden por Id
            var orden = await repositorioOrden.GetByIdAsync(Id);

            //Modificar campos
            orden.MetodoEntregaId = ordenDto.MetodoEntregaId;
            orden.OrdenItems = (List<OrdenItems>?)await repositorioOItem.GetAsync();
            orden.MetodoEntrega = await metodo.ObtenerMetodoEntregaByIdAsync(ordenDto.MetodoEntregaId);
            orden.SubTotal = 0;
            foreach (var item in orden.OrdenItems)
            {
                var product = await producto.ObtenerProductoByIdAsync(item.ProductoId);
                item.Producto = product;
                orden.SubTotal = orden.SubTotal + (item.Producto.Precio * item.CantidadProducto);
            }

            orden.Iva = 12;
            orden.Total = orden.SubTotal * (1 + ((float)orden.Iva / 100)) + orden.MetodoEntrega.CostoEntrega;
            if (orden.OrdenItems.Count() <= 0)
            {
                throw new ArgumentException("No hay objetos para añadir al carro de compras");
            }

            //Modificar Orden
            await repositorioOrden.UpdateAsync(orden);
            return true;
        }
        #endregion

        #region Metodo Ver Carro
        //Metodo que permite ver un objeto OrdenCarroDto que simula ser el carro de compras 
        //***NOTA***
        //1.- Para ver el carro de compras actualizado (modificaciones en Items
        //(agregar,aliminar,modificar)) es necesario actualizar la Orden corriendo el metodo 
        //AgregarOrden
        public async Task<OrdenCarroDto> VerCarro()
        {
            //Obtener consulta de la entidad Orden
            var ordenConsulta = repositorioOrden.GetQueryable();
            //Obtener el primero o null
            var orden = ordenConsulta.FirstOrDefault();
            //Validar si la lista está vacia
            if (orden == null)
            {
                throw new ArgumentException("No se a creado el carro de compras");
            }

            //Agregar campos faltantes a Orden (propiedades de tipo objeto)
            orden.Cliente = await cliente.ObtenerClienteByIdAsync(orden.ClienteId);
            orden.OrdenItems = (List<OrdenItems>?)await repositorioOItem.GetAsync();
            foreach (var item in orden.OrdenItems)
            {
                var product = await producto.ObtenerProductoByIdAsync(item.ProductoId);
                item.Producto = product;
            }
            orden.MetodoEntrega = await metodo.ObtenerMetodoEntregaByIdAsync(orden.MetodoEntregaId);

            var ordenItemsDto = new List<OrdenItemsDto>();

            //Obtener uns lista mapeada de OrdenItems--->OrdenItemsDto
            foreach (var item in orden.OrdenItems)
            {
                ordenItemsDto.Add(mapper.Map<OrdenItemsDto>(item));
            }

            //Mapear de Orden--->OrdenCarroDto
            var ordenCarroDto = mapper.Map <OrdenCarroDto>(orden);
            //Agregar lista mapeada
            ordenCarroDto.OrdenItemsDtos = ordenItemsDto;
            return ordenCarroDto;
        }
        #endregion

        #region Metodo Vaciar Carro
        //Metodo que permite simular vaciar un carro de compras 
        //esto incluye eliminar todos los Items y la Orden
        public async Task<bool> VaciarCarro()
        {
            //Obtener consulta de Orden
            var ordenConsulta = repositorioOrden.GetQueryable();
            //Obtener el primero o null
            var orden = ordenConsulta.FirstOrDefault();
            //Validar si existe Orden
            if (orden == null)
            {
                throw new ArgumentException("No existe carro de compras");
            }

            //Obtener la lista de OrdenItems a eliminar (todos)
            var ordenItems = (List<OrdenItems>?)await repositorioOItem.GetAsync();

            //Modificar el stock de productos (añadir)
            foreach (var item in ordenItems)
            {
                await EliminarProductosStock(-item.CantidadProducto, item.ProductoId);
            }

            //Eliminar OrdenItems
            await repositorioOItem.DeleteAllAsync(ordenItems);
            //Eliminar Orden
            await repositorioOrden.DeleteAsync(orden);
            return true;
        }
        #endregion

        #region Metodo Simular compra
        //Metodo que permite simular la compra, vaciando el carro de compras 
        //sin modificar el stock de los productos 
        public async Task<bool> SimularCompra()
        {
            //Obtener consulta de Orden
            var ordenConsulta = repositorioOrden.GetQueryable();
            //Obtener el primero o null
            var orden = ordenConsulta.FirstOrDefault();
            //Validar si existe Orden
            if (orden == null)
            {
                throw new ArgumentException("No existe carro de compras");
            }

            //Obtener la lista de OrdenItems a eliminar (todos)
            var ordenItems = (List<OrdenItems>?)await repositorioOItem.GetAsync();

            //Eliminar OrdenItems
            await repositorioOItem.DeleteAllAsync(ordenItems);
            //Eliminar Orden
            await repositorioOrden.DeleteAsync(orden);
            return true;
        }
        #endregion
    }
}
