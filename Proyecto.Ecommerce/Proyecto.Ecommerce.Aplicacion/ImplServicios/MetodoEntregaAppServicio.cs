using AutoMapper;
using FluentValidation;
using Proyecto.Ecommerce.Aplicacion.Dtos;
using Proyecto.Ecommerce.Aplicacion.Servicios;
using Proyecto.Ecommerce.Dominio.Entidades;
using Proyecto.Ecommerce.Dominio.Repositorio;

namespace Proyecto.Ecommerce.Aplicacion.ImplServicios
{
    public class MetodoEntregaAppServicio : IMetodoEntregaAppServicio
    {
        private readonly IRepositorioGenerico<MetodoEntrega> repositorio;
        private readonly IValidator<AgregarMetodoEntregaDto> validator;

        public IMapper Mapper { get; }

        public MetodoEntregaAppServicio(IRepositorioGenerico<MetodoEntrega> repositorio, IMapper mapper, IValidator<AgregarMetodoEntregaDto> validator)
        {
            this.repositorio = repositorio;
            Mapper = mapper;
            this.validator = validator;
        }

        #region Metodo Agregar MetodoEntrega
        //Método para agregar MetodoEntrega
        public async Task<MetodoEntregaDto> AgregarMetodoEntregaAsync(AgregarMetodoEntregaDto metodoEntregaDto)
        {
            //Validar
           // validator.ValidateAndThrow(metodoEntregaDto);
            //Se crea un Id aleatorio de tipo string
            var token = Guid.NewGuid();
            var Id = token.ToString().Replace("-", String.Empty).Substring(0, 4);

            //Mapeo de AgregarMetodoEntregaDto--->MetodoEntrega
            var metodoEntrega = Mapper.Map<MetodoEntrega>(metodoEntregaDto);
            //Completar los datos de MetodoEntrega
            metodoEntrega.Id = Id;
            metodoEntrega.FechaCreacion = DateTime.Now;
            metodoEntrega.Eliminado = false;

            //Agregar MetodoEntrega
            await repositorio.AddAsync(metodoEntrega);
            return await ObtenerMetodoEntregaDtoByIdAsync(metodoEntrega.Id);
        }
        #endregion

        #region Metodo Eliminar MetodoEntrega
        //Metodo que permite eliminar un MetodoEntrega por el Id
        public async Task<bool> EliminarMetodoEntregaById(string Id)
        {
            //Obtener el objeto MetodoEntrega por Id
            var metodoEntrega = await ObtenerMetodoEntregaByIdAsync(Id);
            //Eliminar MetodoEntrega
            await repositorio.DeleteAsync(metodoEntrega);
            return true;
        }
        #endregion

        #region Metodo Modificar MetodoEntrega
        //Metodo que permite modificar los datos de MetodoEntrega
        public async Task<bool> ModificarMetodoEntregaAsync(AgregarMetodoEntregaDto metodoEntregaDto, string Id)
        {
            //Validar
            //validator.ValidateAndThrow(metodoEntregaDto);
            //Se obtiene el objeto MetodoEntrega por Id
            var metodoEntrega = await ObtenerMetodoEntregaByIdAsync(Id);
            //Se modifican sus campos
            metodoEntrega.Nombre = metodoEntregaDto.Nombre;
            metodoEntrega.Descripcion = metodoEntregaDto.Descripcion;
            metodoEntrega.CostoEntrega = metodoEntregaDto.CostoEntrega;
            metodoEntrega.FechaModificacion = DateTime.Now;

            //Modificar MetodoEntrega
            await repositorio.UpdateAsync(metodoEntrega);
            return true;
        }
        #endregion

        #region Metodo Obtener MetodoEntrega por Id 
        //Metodo que permite obtener una MetodoEntregaDto por Id
        public async Task<MetodoEntregaDto> ObtenerMetodoEntregaDtoByIdAsync(string Id)
        {
            //Obtener el objeto MetodoEntrega por Id
            var metodoEntrega = await repositorio.GetByIdAsync(Id);
            //Mapear MetodoEntrega--->MetodoEntregaDto
            var metodoEntregaDto = Mapper.Map<MetodoEntregaDto>(metodoEntrega);
            return metodoEntregaDto;
        }
        #endregion

        #region Metodo Obtener Lista de MetodoEntrega
        //Metodo que permite obtener la lista completa de la tabla Marcas
        //en objetos de tipo MetodoEntregaDto
        public async Task<ICollection<MetodoEntregaDto>> ObtenerMetodosEntregaDtoAsync()
        {
            //Obtener la lista de objetos MetodoEntrega
            var consulta = await repositorio.GetAsync();
            //Inicializar la lista de MetodoEntrega
            var Lista = new List<MetodoEntregaDto>();
            //Mapear MetodoEntrega--->MetodoEntregaDto
            foreach (var item in consulta)
            {
               Lista.Add(Mapper.Map<MetodoEntregaDto>(item));
            }
            return Lista;
        }
        #endregion

        #region Metodo publico
        public async Task<MetodoEntrega> ObtenerMetodoEntregaByIdAsync (string Id)
        {
            return await repositorio.GetByIdAsync(Id);
        }
        #endregion
    }
}
