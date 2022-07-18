using Proyecto.Ecommerce.Dominio.Entidades;

namespace Proyecto.Ecommerce.Aplicacion.Servicios
{
    public interface IMarcaAppServicio
    {
        Task<ICollection<Marca>> ObtenerMarcasAsync();
        Task<Marca> ObtenerMarcaByIdAsync(string Id);
        Task<Marca> AgregarMarcaAsync(Marca marca);
        Task<Marca> ModificarMarcaAsync(Marca marca);
        Task<bool> EliminarMarcaById(string Id);
    }
}
