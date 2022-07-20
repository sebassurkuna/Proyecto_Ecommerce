using AutoMapper;
using FluentValidation;
using Proyecto.Ecommerce.Aplicacion.Dtos;
using Proyecto.Ecommerce.Aplicacion.Servicios;
using Proyecto.Ecommerce.Dominio.Entidades;
using Proyecto.Ecommerce.Dominio.Repositorio;

namespace Proyecto.Ecommerce.Aplicacion.ImplServicios
{
    public class MarcaAppServicio : IMarcaAppServicio
    {
        private readonly IRepositorioGenerico<Marca> repositorio;
        private readonly IValidator<AgregarMarcaDto> validator;

        public IMapper Mapper { get; }

        public MarcaAppServicio(IRepositorioGenerico<Marca> repositorio, IMapper mapper, IValidator<AgregarMarcaDto> validator)
        {
            this.repositorio = repositorio;
            Mapper = mapper;
            this.validator = validator;
        }

        #region Metodo Agregar Marcas
        //Método para agregar Marcas
        public async Task<MarcaDto> AgregarMarcaAsync(AgregarMarcaDto marcaDto)
        {
            //Validar 
            validator.ValidateAndThrow(marcaDto);
            //Se crea un Id aleatorio de tipo string
            var token = Guid.NewGuid();
            var Id = token.ToString().Replace("-", String.Empty).Substring(0, 4);

            //Mapeo de AgregarMarcaDto--->Marca
            var marca = Mapper.Map<Marca>(marcaDto);

            //Completar los datos de Marca
            marca.Id = Id; 
            marca.FechaCreacion=DateTime.Now;
            marca.Eliminado = false;

            //Usar metodo del repositorio para añadir
            await repositorio.AddAsync(marca);
            return await ObtenerMarcaDtoByIdAsync(marca.Id);
        }
        #endregion

        #region Metodo Eliminar Marca
        //Metodo que permite eliminar una Marca por el Id
        public async Task<bool> EliminarMarcaById(string Id)
        {
            //Obtener el objeto Marca por Id
            var marca = await ObtenerMarcaByIdAsync(Id);
            //Utiliar el repositorio para eliminar
            await repositorio.DeleteAsync(marca);
            return true;
        }
        #endregion

        #region Metodo Modificar Marca
        //Metodo que permite modificar los datos de Marca
        public async Task<bool> ModificarMarcaAsync(AgregarMarcaDto marcaDto, string Id)
        {
            //Validar
            validator.ValidateAndThrow(marcaDto);
            //Se obtiene el objeto Marca por Id
            var marca = await ObtenerMarcaByIdAsync(Id);

            //Se modifican sus campos con la info del AgregarMarcaDto
            marca.Nombre = marcaDto.Nombre;
            marca.FechaModificacion = DateTime.Now;

            //Se usa el repositorio para modificar
            await repositorio.UpdateAsync(marca);
            return true;
        }
        #endregion

        #region Metodo Obtener Marca por Id 
        //Metodo que permite obtener una MarcaDto por Id
        public async Task<MarcaDto> ObtenerMarcaDtoByIdAsync(string Id)
        {
            //Obtener el objeto Marca por Id
            var marca = await repositorio.GetByIdAsync(Id);

            //Mapear el Marca--->MarcaDto
            var marcaDto = Mapper.Map<MarcaDto>(marca);
            return marcaDto;
        }
        #endregion

        #region Metodo Obtener Lista de Marcas
        //Metodo que permite obtener la lista completa de la tabla Marcas
        //en objetos de tipo MarcaDto
        public async Task<ICollection<MarcaDto>> ObtenerMarcasDtoAsync()
        {
            //Obtener la lista de objetos Marca
            var consulta = await repositorio.GetAsync();

            //Inicializar la lista de Marca
            var Lista = new List<MarcaDto>();

            //Mapera cada objeto Marca--->MarcaDto
            foreach (var item in consulta)
            {
               Lista.Add(Mapper.Map<MarcaDto>(item));
            }
            return Lista;
        }
        #endregion

        #region Metodo publico
        //Metodo que permite obtener una Marca por Id
        public async Task<Marca> ObtenerMarcaByIdAsync (string Id)
        {
            return await repositorio.GetByIdAsync(Id);
        }
        #endregion
    }
}
