using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;
namespace RestApp.Servicio
{
   public  class CONEXIONMAESTRA
    {
        public static string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "connection.txt");
        public static string text = File.ReadAllText(ruta);
        public static string conexion = text;
        public static SqlConnection conectar = new SqlConnection(conexion);

        public static void abrir()
        {
            if (conectar.State == ConnectionState.Closed)
            {
                conectar.Open();
            }
        }
        public static void cerrar()
        {
            if (conectar.State == ConnectionState.Open)
            {
                conectar.Close();
            }
        }
    }
}
