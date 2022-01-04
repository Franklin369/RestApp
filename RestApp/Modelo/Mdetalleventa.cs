using System;
using System.Collections.Generic;
using System.Text;

namespace RestApp.Modelo
{
    public class Mdetalleventa
    {
        public int Iddetalleventa { get; set; }
        public int Idmesa { get; set; }
        public string Producto { get; set; }
        public double Importe { get; set; }
        public double Total { get; set; }

        public int idventa { get; set; }
        public int Id_producto { get; set; }
        public double cantidad { get; set; }
        public double preciounitario { get; set; }
        public string Estado { get; set; }
        public double Costo { get; set; }
        public double Ganancia { get; set; }
        public string Estado_de_pago { get; set; }
        public string Donde_se_consumira { get; set; }
    }
}
