using Proyecto.Ecommerce.Dominio.Entidades.EntidadesBase;


namespace Proyecto.Ecommerce.Dominio.Entidades
{
    public class OrdenItems : EntidadBase
    {
        public Guid Id { get; set; }
        public Producto Producto { get; set; }
        public Guid ProductoId { get; set; }
        public int CantidadProducto { get; set; }
    }
}
