using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Ecommerce.Aplicacion.Dtos
{
    public class OrdenDto
    {
        public Guid ClienteId { get; set; }
        public string NombreCliente { get; set; }
        public string MetodoEntregaId { get; set; }
        public string NombreMetodoEntrega { get; set; }
        public float SubTotal { get; set; }
        public int Iva { get; set; }
        public float Total { get; set; }
    }
}
