using System;
using System.Collections.Generic;
using System.Text;

namespace RestApp.Modelo
{
   public  class Musuarios
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public byte[] Icono { get; set; }
        public string Correo { get; set; }
        public string Rol { get; set; }
        public string Estado { get; set; }

    }
}
