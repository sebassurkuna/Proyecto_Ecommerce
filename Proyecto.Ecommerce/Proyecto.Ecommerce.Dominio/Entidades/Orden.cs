using Proyecto.Ecommerce.Dominio.Entidades.EntidadesBase;

namespace Proyecto.Ecommerce.Dominio.Entidades
{
    public class Orden : EntidadBase
    {
        public Guid Id { get; set; }
        public Cliente? Cliente { get; set; }
        public Guid ClienteId { get; set; }
        public List<OrdenItems>? OrdenItems { get; set; }
        public MetodoEntrega? MetodoEntrega { get; set; }
        public string MetodoEntregaId { get; set; }
        public float SubTotal { get; set; }
        public int Iva { get; set; }
        public float Total { get; set; }
    }
}
