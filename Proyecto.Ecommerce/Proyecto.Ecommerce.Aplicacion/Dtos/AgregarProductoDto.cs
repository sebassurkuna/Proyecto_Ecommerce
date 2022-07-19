namespace Proyecto.Ecommerce.Aplicacion.Dtos
{
    public class AgregarProductoDto
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public long Precio { get; set; }
        public int Stock { get; set; }
        public string MarcaId { get; set; }
        public string TipoProductoId { get; set; }
    }
}
