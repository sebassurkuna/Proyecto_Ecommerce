using Proyecto.Ecommerce.Dominio.Entidades.EntidadesBase;

namespace Proyecto.Ecommerce.Dominio.Entidades
{
    public class Cliente : EntidadBase 
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Contraseña { get; set; }
        public string NombreUsuario { get; set; }
        public int Edad { get; set; }
        public string NumeroCedula { get; set; }
        public string Email { get; set; }
    }
}
