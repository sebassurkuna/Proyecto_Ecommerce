using Proyecto.Ecommerce.Dominio.Entidades.EntidadesBase;

namespace Proyecto.Ecommerce.Dominio.Entidades
{
    public class MetodoEntrega : EntidadBase
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public long CostoEntrega { get; set; }
    }
}
