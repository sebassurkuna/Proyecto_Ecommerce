using AutoMapper;
using FluentValidation;
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
        private readonly IValidator<ClienteDto> validator;

        public IMapper Mapper { get; }

        public ClienteAppServicio(IRepositorioGenerico<Cliente> repositorio, IMapper mapper, IValidator<ClienteDto> validator)
        {
            this.repositorio = repositorio;
            Mapper = mapper;
            this.validator = validator;
        }

        #region Metodo Agregar Cliente
        //Método para agregar Cliente
        public async Task<ClienteDto> AgregarClienteAsync(ClienteDto clienteDto)
        {
            //Validar
            validator.ValidateAndThrow(clienteDto);
            //Mapeo de ClienteDto--->Cliente
            var cliente = Mapper.Map<Cliente>(clienteDto);
            //Completar los datos de Cliente
            cliente.Id=Guid.NewGuid();
            cliente.FechaCreacion=DateTime.Now;
            cliente.Eliminado = false;

            //Agregar Cliente
            await repositorio.AddAsync(cliente);
            return await ObtenerClienteDtoByIdAsync(cliente.Id);
        }
        #endregion

        #region Metodo Eliminar Cliente
        //Metodo que permite eliminar una Cliente por el Id
        public async Task<bool> EliminarClienteById(Guid Id)
        {
            //Obtener el objeto Cliente por Id
            var cliente = await ObtenerClienteByIdAsync(Id);
            //Eliminar Cliente
            await repositorio.DeleteAsync(cliente);
            return true;
        }
        #endregion

        #region Metodo Modificar Cliente
        //Metodo que permite modificar los datos de Cliente
        public async Task<bool> ModificarClienteAsync(ClienteDto clienteDto, Guid Id)
        {
            //Validar
            validator.ValidateAndThrow(clienteDto);
            //Obtener el objeto Cliente por Id
            var cliente = await ObtenerClienteByIdAsync(Id);
            //Modificar valores de objeto
            cliente.Nombre = clienteDto.Nombre;
            cliente.Apellido = clienteDto.Apellido;
            cliente.Contraseña = clienteDto.Contraseña;
            cliente.NombreUsuario = clienteDto.NombreUsuario;
            cliente.NumeroCedula = clienteDto.NumeroCedula;
            cliente.Edad = clienteDto.Edad;
            cliente.Email = clienteDto.Email;
            cliente.FechaModificacion=DateTime.Now;

            //Modificar objeto
            await repositorio.UpdateAsync(cliente);
            return true;
        }
        #endregion

        #region Metodo Obtener Cliente por Id 
        //Metodo que permite obtener una ClienteDto por Id
        public async Task<ClienteDto> ObtenerClienteDtoByIdAsync(Guid Id)
        {
            //Obtener el objeto Cliente por Id
            var cliente = await repositorio.GetByIdAsync(Id);
            //Mapear de Cliente--->ClienteDto
            var clienteDto = Mapper.Map<ClienteDto>(cliente);
            return clienteDto;
        }
        #endregion

        #region Metodo Obtener Lista de Cliente
        //Metodo que permite obtener la lista completa de la tabla Cientes
        //en objetos de tipo ClienteDto
        public async Task<ICollection<ClienteDto>> ObtenerClientesDtoAsync()
        {
            //Obtener la lista de objetos Cliente
            var consulta = await repositorio.GetAsync();
            //Inicializar la lista de Cliente
            var Lista = new List<ClienteDto>();
            //Mapear de Cliente--->ClienteDto
            foreach (var item in consulta)
            {
               Lista.Add(Mapper.Map<ClienteDto>(item));
            }
            return Lista;
        }
        #endregion

        #region Metodo publico
        public async Task<Cliente> ObtenerClienteByIdAsync (Guid Id)
        {
            return await repositorio.GetByIdAsync(Id);
        }
        #endregion

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
