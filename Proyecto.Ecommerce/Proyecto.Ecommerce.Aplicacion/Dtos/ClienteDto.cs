﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Ecommerce.Aplicacion.Dtos
{
    public class ClienteDto
    {
        public Guid? Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Contraseña { get; set; }
        public string NombreUsuario { get; set; }
        public int Edad { get; set; }
        public string NumeroCedula { get; set; }
        public string Email { get; set; }
    }
}
