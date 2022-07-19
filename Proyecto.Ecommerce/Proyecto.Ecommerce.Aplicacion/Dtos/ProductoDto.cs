using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Ecommerce.Aplicacion.Dtos
{
    public class ProductoDto
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public long Precio { get; set; }
        public int Stock { get; set; }
        public string MarcaId { get; set; }
        public string NombreMarca { get; set; }
        public string TipoProductoId { get; set; }
        public string NombreTipoProducto { get; set; }
    }
}
