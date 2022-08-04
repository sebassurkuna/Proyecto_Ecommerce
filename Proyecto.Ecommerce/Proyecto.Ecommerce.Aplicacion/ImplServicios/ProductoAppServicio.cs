using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Proyecto.Ecommerce.Aplicacion.Dtos;
using Proyecto.Ecommerce.Aplicacion.Servicios;
using Proyecto.Ecommerce.Dominio.Entidades;
using Proyecto.Ecommerce.Dominio.Repositorio;

namespace Proyecto.Ecommerce.Aplicacion.ImplServicios
{
    public class ProductoAppServicio : IProductoAppServicio
    {
        private readonly IRepositorioGenerico<Producto> repositorio;
        private readonly IMarcaAppServicio marca;
        private readonly ITipoProductoAppServicio tipoProducto;
        private readonly IValidator<AgregarProductoDto> validator;

        public IMapper Mapper { get; }

        public ProductoAppServicio(IRepositorioGenerico<Producto> repositorio, IMapper mapper, 
            IMarcaAppServicio marca, ITipoProductoAppServicio tipoProducto, IValidator<AgregarProductoDto> validator)
        {
            this.repositorio = repositorio;
            Mapper = mapper;
            this.marca = marca;
            this.tipoProducto = tipoProducto;
            this.validator = validator;
        }

        #region Metodo Agregar Productos
        //Método para agregar Productos
        public async Task<ProductoDto> AgregarProductoAsync(AgregarProductoDto productoDto)
        {
            //Validar
           // validator.ValidateAndThrow(productoDto);
            //Mapeo de AgregarProductoDto--->Producto
            var producto = Mapper.Map<Producto>(productoDto);

            //Completar los datos de Producto
            producto.Id=Guid.NewGuid();
            producto.FechaCreacion=DateTime.Now;
            producto.Eliminado = false;
            producto.Marca = await marca.ObtenerMarcaByIdAsync(productoDto.MarcaId);
            producto.TipoProducto = await tipoProducto.ObtenerTipoProductoByIdAsync(productoDto.TipoProductoId);

            //Usar metodo del repositorio para añadir a la base de datos
            await repositorio.AddAsync(producto);
            return await ObtenerProductoDtoByIdAsync(producto.Id);
        }
        #endregion

        #region Metodo Eliminar Porducto
        //Metodo que permite eliminar un Producto por el Id
        public async Task<bool> EliminarProductoById(Guid Id)
        {
            //Obtener el objeto Producto por Id
            var producto = await ObtenerProductoByIdAsync(Id);
            //Utiliar el repositorio para eliminar
            await repositorio.DeleteAsync(producto);
            return true;
        }
        #endregion

        #region Metodo Modificar Porducto
        //Metodo que permite modificar los datos de Producto
        public async Task<bool> ModificarProductoAsync(AgregarProductoDto productoDto, Guid Id)
        {
            //Validar 
           // validator.ValidateAndThrow(productoDto);

            //Se obtiene el objeto Producto por Id
            var producto = await ObtenerProductoByIdAsync(Id);

            //Se modifican sus campos con la info del AgregarProductoDto
            producto.Nombre = productoDto.Nombre;
            producto.Descripcion=productoDto.Descripcion;
            producto.Precio = productoDto.Precio;
            producto.Stock = productoDto.Stock;
            producto.MarcaId = productoDto.MarcaId;
            producto.TipoProductoId = productoDto.TipoProductoId;
            producto.Marca = await marca.ObtenerMarcaByIdAsync(productoDto.MarcaId);
            producto.TipoProducto = await tipoProducto.ObtenerTipoProductoByIdAsync(productoDto.TipoProductoId);

            //Se usa el repositorio para modificar
            await repositorio.UpdateAsync(producto);
            return true;
        }
        #endregion

        #region Metodo Obtener Producto por Id
        public async Task<ProductoDto> ObtenerProductoDtoByIdAsync(Guid Id)
        {
            //Obtener el objeto Producto por Id
            var producto = await repositorio.GetByIdAsync(Id);

            //Mapear el Producto--->ProductoDto
            var productoDto = Mapper.Map<ProductoDto>(producto);
            var marcaName = await marca.ObtenerMarcaByIdAsync(producto.MarcaId);
            productoDto.NombreMarca = marcaName.Nombre;
            var tipoPorductoName = await tipoProducto.ObtenerTipoProductoDtoByIdAsync(producto.TipoProductoId);
            productoDto.NombreTipoProducto = tipoPorductoName.Nombre;

            return productoDto;
        }
        #endregion

        #region Metodo Obtener Lista de Porductos
        //Metodo que permite obtener la lista completa de la tabla Porducto
        //en objetos de tipo ProductoDto
        public async Task<ICollection<ProductoDto>> ObtenerProductosDtoAsync()
        {
            //Obtener la lista de objetos Producto
            var consulta = await repositorio.GetAsync();

            //Inicializar la lista de ProductoDto
            var Lista = new List<ProductoDto>();

            //Mapera cada objeto Producto--->ProductoDto
            foreach (var item in consulta)
            {
                var producto = Mapper.Map<ProductoDto>(item);
                var marcaName = await marca.ObtenerMarcaByIdAsync(item.MarcaId);
                producto.NombreMarca = marcaName.Nombre;
                var tipoPorductoName = await tipoProducto.ObtenerTipoProductoDtoByIdAsync(item.TipoProductoId);
                producto.NombreTipoProducto = tipoPorductoName.Nombre;
               Lista.Add(producto);
            }
            return Lista;
        }
        #endregion

        #region Metodo publico
        public async Task<Producto> ObtenerProductoByIdAsync (Guid Id)
        {
            return await repositorio.GetByIdAsync(Id);
        }
        #endregion

        #region Metodo paginacion y busqueda 
        //Método que permite obtener una lista paginada y con criterios de busqueda
        public async Task<ICollection<ProductoDto>> GetPaginacion(int limit, int offset, string nombre, long precio)
        {
            //Se obtiene un  objeto de tipo IQueriable para usar consultas con LINQ
            var consulta = repositorio.GetQueryable();

            //Creiterios de busqueda
            var listaPaginada = consulta.Where(x => x.Nombre.Contains(nombre) && x.Precio <= precio);

            //Paginacion
            listaPaginada = listaPaginada.Skip(offset).Take(limit);

            //Ordenamiento
            listaPaginada = listaPaginada.OrderBy(x => x.Nombre);

            //Ejecutar la busqueda
            var lista = await listaPaginada.ToListAsync();

            //Inicializar lista de ProductoDto
            var listaDto = new List<ProductoDto>();
            foreach (var item in lista)
            {
                //Mapear de Producto--->ProductoDto
                var producto = Mapper.Map<ProductoDto>(item);

                //Obtener nombres de marca y tipo de producto
                var marcaName = await marca.ObtenerMarcaByIdAsync(item.MarcaId);
                producto.NombreMarca = marcaName.Nombre;
                var tipoPorductoName = await tipoProducto.ObtenerTipoProductoDtoByIdAsync(item.TipoProductoId);
                producto.NombreTipoProducto = tipoPorductoName.Nombre;

                //Agragar a lista
                listaDto.Add(producto);
            }
            return listaDto;
        }
        #endregion
    }
}
