using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Ecommerce.Dominio.Entidades.EntidadesBase
{
    public class EntidadBase
    {
        public bool Eliminado { get; set; } = false;
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
