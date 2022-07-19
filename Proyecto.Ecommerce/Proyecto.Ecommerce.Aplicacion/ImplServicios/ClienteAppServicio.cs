using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Proyecto.Ecommerce.Aplicacion.Dtos;
using Proyecto.Ecommerce.Aplicacion.Servicios;
using Proyecto.Ecommerce.Dominio.Entidades;
using Proyecto.Ecommerce.Dominio.Repositorio;

namespace Proyecto.Ecommerce.Aplicacion.ImplServicios
{
    public class ClienteAppServicio : IClienteAppServicio
    {
        private readonly IRepositorioGenerico<Cliente> repositorio;
        public IMapper Mapper { get; }

        public ClienteAppServicio(IRepositorioGenerico<Cliente> repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            Mapper = mapper;
        }
        

        public async Task<ClienteDto> AgregarClienteAsync(ClienteDto clienteDto)
        {
            var cliente = Mapper.Map<Cliente>(clienteDto);
            cliente.Id=Guid.NewGuid();
            cliente.FechaCreacion=DateTime.Now;
            cliente.Eliminado = false;

            await repositorio.AddAsync(cliente);
            return await ObtenerClienteDtoByIdAsync(cliente.Id);
        }

        public async Task<bool> EliminarClienteById(Guid Id)
        {
            var cliente = await ObtenerClienteByIdAsync(Id);
            await repositorio.DeleteAsync(cliente);
            return true;
        }

        public async Task<bool> ModificarClienteAsync(ClienteDto clienteDto, Guid Id)
        {
            var cliente = await ObtenerClienteByIdAsync(Id);
            cliente.Nombre = clienteDto.Nombre;
            cliente.Apellido = clienteDto.Apellido;
            cliente.Contraseña = clienteDto.Contraseña;
            cliente.NombreUsuario = clienteDto.NombreUsuario;
            cliente.NumeroCedula = clienteDto.NumeroCedula;
            cliente.Edad = clienteDto.Edad;
            cliente.Email = clienteDto.Email;
            cliente.FechaModificacion=DateTime.Now;

            await repositorio.UpdateAsync(cliente);
            return true;
        }

        public async Task<ClienteDto> ObtenerClienteDtoByIdAsync(Guid Id)
        {
            var cliente = await repositorio.GetByIdAsync(Id);
            var clienteDto = Mapper.Map<ClienteDto>(cliente);
            return clienteDto;
        }

        public async Task<ICollection<ClienteDto>> ObtenerClientesDtoAsync()
        {
            var consulta = await repositorio.GetAsync();
            var Lista = new List<ClienteDto>();
            foreach (var item in consulta)
            {
               Lista.Add(Mapper.Map<ClienteDto>(item));
            }
            return Lista;
        }

        public async Task<Cliente> ObtenerClienteByIdAsync (Guid Id)
        {
            return await repositorio.GetByIdAsync(Id);
        }

        #region Metodo paginacion y busqueda 
        //Método que permite obtener una lista paginada y con criterios de busqueda
        public async Task<ICollection<ClienteDto>> GetPaginacion(int limit, int offset, string nombre, string cedula)
        {
            //Se obtiene un  objeto de tipo IQueriable para usar consultas con LINQ
            var consulta = repositorio.GetQueryable();

            //Creiterios de busqueda
            var listaPaginada= consulta;
            if (string.IsNullOrEmpty(cedula))
            {
                 listaPaginada = consulta.Where(x => x.Nombre.Contains(nombre));
            }
            else
            {
                listaPaginada = consulta.Where(x => x.Nombre.Contains(nombre) || x.NumeroCedula.Contains(cedula));
            }

            //Paginacion
            if (limit <= 0)
            {
                throw new ArgumentException("El límite de la paginacion debe ser mayor a 0");
            }

            listaPaginada = listaPaginada.Skip(offset).Take(limit);

            //Ordenamiento
            listaPaginada = listaPaginada.OrderBy(x => x.Nombre);

            //Ejecutar la busqueda
            var lista = await listaPaginada.ToListAsync();

            //Inicializar lista de ProductoDto
            var listaDto = new List<ClienteDto>();
            foreach (var item in lista)
            {
                //Mapear de Cliente--->ClienteDto
                var cliente = Mapper.Map<ClienteDto>(item);

                //Agragar a lista
                listaDto.Add(cliente);
            }
            return listaDto;
        }
        #endregion
    }
}
