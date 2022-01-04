using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Xamarin.Forms;
using System.Data.SqlClient;
using System.Data;
using RestApp.Servicio;
using RestApp.Modelo;

namespace RestApp.VistaModelo
{
    public class VMmesas
    {
        public void dibujarMesasPorSalon(Msalon parametros,ref DataTable dt)
        {
			try
			{
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrar_mesas_por_salon_ventas", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@id_salon", parametros.Id_salon);
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
        public void mostrar_mozo_por_mesa( ref DataTable dt)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrar_mozo_por_mesa", CONEXIONMAESTRA.conectar);
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
        public bool EditarEstadoMesaOcupado(Mmesas parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("EditarEstadoMesaOcupado", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Idmesa", parametros.Id_mesa);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Error", ex.StackTrace, "OK");
                return false;
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }
        public bool EditarEstadoMesaLibre(Mmesas parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("EditarEstadoMesaLibre", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Idmesa", parametros.Id_mesa);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Error", ex.StackTrace, "OK");
                return false;
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }

    }
}
