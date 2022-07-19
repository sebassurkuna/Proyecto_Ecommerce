using AutoMapper;
using Proyecto.Ecommerce.Aplicacion.Dtos;
using Proyecto.Ecommerce.Aplicacion.Servicios;
using Proyecto.Ecommerce.Dominio.Entidades;
using Proyecto.Ecommerce.Dominio.Repositorio;

namespace Proyecto.Ecommerce.Aplicacion.ImplServicios
{
    public class TipoProductoAppServicio : ITipoProductoAppServicio
    {
        private readonly IRepositorioGenerico<TipoProducto> repositorio;
        public IMapper Mapper { get; }

        public TipoProductoAppServicio(IRepositorioGenerico<TipoProducto> repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            Mapper = mapper;
        }

        #region Metodo Agregar Tipo de Producto
        //Método para agregar Tipos de Productos
        public async Task<TipoProductoDto> AgregarTipoProductoAsync(AgregarTipoProductoDto tipoProductoDto)
        {
            //Se crea un Id aleatorio de tipo string
            var token = Guid.NewGuid();
            var Id = token.ToString().Replace("-", String.Empty).Substring(0, 4);

            //Mapeo de AgregarTipoProductoDto--->TipoProducto
            var tipoProducto = Mapper.Map<TipoProducto>(tipoProductoDto);
            //Completar los datos de TipoProducto
            tipoProducto.Id = Id;
            tipoProducto.FechaCreacion=DateTime.Now;
            tipoProducto.Eliminado = false;

            //Usar metodo del repositorio para añadir a la base de datos
            await repositorio.AddAsync(tipoProducto);
            return await ObtenerTipoProductoDtoByIdAsync(tipoProducto.Id);
        }
        #endregion

        #region Metodo Eliminar Tipo de Porducto
        //Metodo que permite eliminar un TipoProducto por el Id
        public async Task<bool> EliminarTipoProductoById(string Id)
        {
            //Obtener el objeto TipoProducto por Id
            var tipoProducto = await ObtenerTipoProductoByIdAsync(Id);
            //Utiliar el repositorio para eliminar
            await repositorio.DeleteAsync(tipoProducto);
            return true;
        }
        #endregion

        #region Metodo Modificar Tipo de Porducto
        //Metodo que permite modificar los datos de TipoProducto
        public async Task<bool> ModificarTipoProductoAsync(AgregarTipoProductoDto tipoProductoDto, string Id)
        {
            //Se obtiene el objeto TipoProducto por Id
            var tipoProducto = await ObtenerTipoProductoByIdAsync(Id);

            //Se modifican sus campos con la info del AgregarTipoProductoDto
            tipoProducto.Nombre = tipoProductoDto.Nombre;
            tipoProducto.FechaModificacion = DateTime.Now;

            //Se usa el repositorio para modificar
            await repositorio.UpdateAsync(tipoProducto);
            return true;
        }
        #endregion

        #region Metodo Obtener Tipo de Producto por Id
        //Metodo que permite obtener un TipoProductoDto por Id
        public async Task<TipoProductoDto> ObtenerTipoProductoDtoByIdAsync(string Id)
        {
            //Obtener el objeto TipoProducto por Id
            var tipoProducto = await repositorio.GetByIdAsync(Id);

            //Mapear el TipoProducto--->TipoProductoDto
            var tipoProductoDto = Mapper.Map<TipoProductoDto>(tipoProducto);
            return tipoProductoDto;
        }
        #endregion

        #region Metodo Obtener Lista de Tipo de Porducto
        //Metodo que permite obtener la lista completa de la tabla TipoPorducto
        //en objetos de tipo TipoProductoDto
        public async Task<ICollection<TipoProductoDto>> ObtenerTipoProductosDtoAsync()
        {
            //Obtener la lista de objetos TipoProducto
            var consulta = await repositorio.GetAsync();

            //Inicializar la lista de TipoProductoDto
            var Lista = new List<TipoProductoDto>();

            //Mapera cada objeto TipoProducto--->TipoProductoDto
            foreach (var item in consulta)
            {
               Lista.Add(Mapper.Map<TipoProductoDto>(item));
            }
            return Lista;
        }
        #endregion

        #region Metodo publico
        //Metodo que permite obtener un TipoProducto por Id
        public async Task<TipoProducto> ObtenerTipoProductoByIdAsync (string Id)
        {
            return await repositorio.GetByIdAsync(Id);
        }
        #endregion
    }
}
