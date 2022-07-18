using Proyecto.Ecommerce.Dominio.Entidades.EntidadesBase;

namespace Proyecto.Ecommerce.Dominio.Entidades
{
    public class Producto : EntidadBase
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public long Precio { get; set; }
        public int Stock { get; set; }
        public Marca? Marca { get; set; }
        public string MarcaId { get; set; }
        public TipoProducto? TipoProducto { get; set; }
        public string TipoProductoId { get; set; }
    }
}
