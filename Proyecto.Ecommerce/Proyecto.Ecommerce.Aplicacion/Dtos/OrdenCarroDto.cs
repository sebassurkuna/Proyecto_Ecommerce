using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Ecommerce.Aplicacion.Dtos
{
    public class OrdenCarroDto
    {
        public List<OrdenItemsDto> OrdenItemsDtos { get; set; }
        public ClienteDto Cliente { get; set; }
        public MetodoEntregaDto MetodoEntrega { get; set; }
        public float SubTotal { get; set; }
        public int Iva { get; set; }
        public float Total { get; set; }
    }
}
