using AutoMapper;
using Proyecto.Ecommerce.Aplicacion.Dtos;
using Proyecto.Ecommerce.Aplicacion.Servicios;
using Proyecto.Ecommerce.Dominio.Entidades;
using Proyecto.Ecommerce.Dominio.Repositorio;

namespace Proyecto.Ecommerce.Aplicacion.ImplServicios
{
    public class MetodoEntregaAppServicio : IMetodoEntregaAppServicio
    {
        private readonly IRepositorioGenerico<MetodoEntrega> repositorio;
        public IMapper Mapper { get; }

        public MetodoEntregaAppServicio(IRepositorioGenerico<MetodoEntrega> repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            Mapper = mapper;
        }
        

        public async Task<MetodoEntregaDto> AgregarMetodoEntregaAsync(AgregarMetodoEntregaDto metodoEntregaDto)
        {
            //Se crea un Id aleatorio de tipo string
            var token = Guid.NewGuid();
            var Id = token.ToString().Replace("-", String.Empty).Substring(0, 4);

            var metodoEntrega = Mapper.Map<MetodoEntrega>(metodoEntregaDto);
            metodoEntrega.Id = Id;
            metodoEntrega.FechaCreacion=DateTime.Now;
            metodoEntrega.Eliminado = false;

            await repositorio.AddAsync(metodoEntrega);
            return await ObtenerMetodoEntregaDtoByIdAsync(metodoEntrega.Id);
        }

        public async Task<bool> EliminarMetodoEntregaById(string Id)
        {
            var metodoEntrega = await ObtenerMetodoEntregaByIdAsync(Id);
            await repositorio.DeleteAsync(metodoEntrega);
            return true;
        }

        public async Task<bool> ModificarMetodoEntregaAsync(AgregarMetodoEntregaDto metodoEntregaDto, string Id)
        {
            var metodoEntrega = await ObtenerMetodoEntregaByIdAsync(Id);
            metodoEntrega.Nombre = metodoEntregaDto.Nombre;
            metodoEntrega.Descripcion = metodoEntregaDto.Descripcion;
            metodoEntrega.CostoEntrega = metodoEntregaDto.CostoEntrega;
            metodoEntrega.FechaModificacion = DateTime.Now;

            await repositorio.UpdateAsync(metodoEntrega);
            return true;
        }

        public async Task<MetodoEntregaDto> ObtenerMetodoEntregaDtoByIdAsync(string Id)
        {
            var metodoEntrega = await repositorio.GetByIdAsync(Id);
            var metodoEntregaDto = Mapper.Map<MetodoEntregaDto>(metodoEntrega);
            return metodoEntregaDto;
        }

        public async Task<ICollection<MetodoEntregaDto>> ObtenerMetodosEntregaDtoAsync()
        {
            var consulta = await repositorio.GetAsync();
            var Lista = new List<MetodoEntregaDto>();
            foreach (var item in consulta)
            {
               Lista.Add(Mapper.Map<MetodoEntregaDto>(item));
            }
            return Lista;
        }

        public async Task<MetodoEntrega> ObtenerMetodoEntregaByIdAsync (string Id)
        {
            return await repositorio.GetByIdAsync(Id);
        }
    }
}
