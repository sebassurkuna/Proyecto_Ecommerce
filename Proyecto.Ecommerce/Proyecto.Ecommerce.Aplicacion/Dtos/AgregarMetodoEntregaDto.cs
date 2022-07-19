using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Ecommerce.Aplicacion.Dtos
{
    public class AgregarMetodoEntregaDto
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public long CostoEntrega { get; set; }
    }
}
