using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Ecommerce.Aplicacion.Dtos
{
    public class OrdenItemsDto
    {
        public Guid ProductoId { get; set; }
        public string NombreProducto { get; set; }
        public int CantidadProducto { get; set; }
    }
}
