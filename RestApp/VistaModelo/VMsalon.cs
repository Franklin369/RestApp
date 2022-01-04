using RestApp.Servicio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Xamarin.Forms;

namespace RestApp.VistaModelo
{
   public  class VMsalon
    {
        public void dibujarsalones (ref DataTable dt)
        {
			try
			{
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("Select * from SALON Where Estado = 'ACTIVO'", CONEXIONMAESTRA.conectar);
                da.Fill(dt);
            }
			catch (Exception ex)
			{
                Application.Current.MainPage.DisplayAlert("Error", ex.StackTrace, "Ok");

            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }
    }
}
