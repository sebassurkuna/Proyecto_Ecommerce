using AutoMapper;
using Proyecto.Ecommerce.Aplicacion.Dtos;
using Proyecto.Ecommerce.Dominio.Entidades;

namespace Proyecto.Ecommerce.Aplicacion.PerfilAutommaper
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<Cliente, ClienteDto>();
            CreateMap<ClienteDto, Cliente>();

            CreateMap<Marca, MarcaDto>();
            CreateMap<MarcaDto, Marca>();
            CreateMap<AgregarMarcaDto, Marca>();

            CreateMap<MetodoEntrega, MetodoEntregaDto>();
            CreateMap<MetodoEntregaDto, MetodoEntrega>();
            CreateMap<AgregarMetodoEntregaDto, MetodoEntrega>();

            CreateMap<Orden, OrdenDto>();
            CreateMap<OrdenDto, Orden>();
            CreateMap<AgregarOrdenDto, Orden>();
            CreateMap<Orden, OrdenCarroDto>();

            CreateMap<OrdenItems, OrdenItemsDto>();
            CreateMap<OrdenItemsDto, OrdenItems>();
            CreateMap<AgregarOrdenItemsDto, OrdenItems>();

            CreateMap<Producto, ProductoDto>();
            CreateMap<ProductoDto, Producto>();
            CreateMap<AgregarProductoDto, Producto>();
            CreateMap<Producto, AgregarProductoDto>();

            CreateMap<TipoProducto, TipoProductoDto>();
            CreateMap<TipoProductoDto, TipoProducto>();
            CreateMap<AgregarTipoProductoDto, TipoProducto>();
        }
    }
}
