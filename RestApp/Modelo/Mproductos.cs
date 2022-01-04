using System;
using System.Collections.Generic;
using System.Text;

namespace RestApp.Modelo
{
   public class Mproductos
    {
        public int Idproducto { get; set; }
        public int Idgrupo { get; set; }
        public string Descripcion { get; set; }
        public string Precio { get; set; }
        public string ColorHtml { get; set; }
    }
}
