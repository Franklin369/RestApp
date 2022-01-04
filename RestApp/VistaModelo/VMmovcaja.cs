using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using RestApp.Servicio;
namespace RestApp.VistaModelo
{
  public class VMmovcaja
    {
        public void mostrarCajaRemota(ref int idmov)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand da = new SqlCommand("mostrarMovCajaremota", CONEXIONMAESTRA.conectar);
                idmov = Convert.ToInt32(da.ExecuteScalar());
            }
            catch (Exception ex)
            {
                idmov = 0;
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }
    }
}
