using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RestApp.Modelo;
using RestApp.Servicio;
using Xamarin.Forms;

namespace RestApp.VistaModelo
{
  public class VMventas
    {
        int idmovcajaRemota;
        private void ObtenerIdCajaremota()
        {
            var funcion = new VMmovcaja();
            funcion.mostrarCajaRemota(ref idmovcajaRemota);
        }
        public void mostrarIdventaMesa(ref int idventa,Mventas parametros)

        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("mostrarIdventaMesa", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_mesa", parametros.Idmesa);
                idventa =Convert.ToInt32( cmd.ExecuteScalar());

            }
            catch (Exception)
            {

                idventa = 0;   
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }

        }
        public bool Insertar_ventas(Mventas parametros)
        {
            try
            {
                ObtenerIdCajaremota();

                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("Insertar_ventas", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_usuario", parametros.Idusuario);
                cmd.Parameters.AddWithValue("@Nombrellevar", "-");
                cmd.Parameters.AddWithValue("@Idmovcaja", idmovcajaRemota);
                cmd.Parameters.AddWithValue("@Id_mesa", parametros.Idmesa);
                cmd.Parameters.AddWithValue("@Numero_personas", 1);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                return false;
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }
        public bool eliminarVenIncomMovil(Mventas parametros)
        {
            try
            {
           
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("eliminarVenIncomMovil", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Idmesa", parametros.Idmesa);
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
        public bool eliminarVenta(Mventas parametros)
        {
            try
            {

                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("eliminarVenta", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Idventa", parametros.Idventa);
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

        public bool EditarEstadoVentasEspera(Mventas parametros)
        {
            try
            {

                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("EditarEstadoVentasEspera", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idventa", parametros.Idventa);
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
        public void InsertarSolicitud(Mventas parametros)
        {
            try
            {

                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("InsertarSolicitud", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Idventa", parametros.Idventa);
                cmd.Parameters.AddWithValue("@Tipo", "MOVIL");
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Error", ex.StackTrace, "OK");
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }
    }
}
