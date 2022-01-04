using RestApp.Modelo;
using RestApp.Servicio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace RestApp.VistaModelo
{
    public class VMusuarios
    {
        public void dibujarUsuarios(ref DataTable dt)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("Select * from Usuarios where Estado='ACTIVO' and Rol<>'Cliente'", CONEXIONMAESTRA.conectar);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }
        public void validarUsuario(Musuarios parametros, ref int id)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("validarUsuario", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@password",parametros.Password);
                cmd.Parameters.AddWithValue("@login", parametros.Login);
                id = Convert.ToInt32(cmd.ExecuteScalar());


            }
            catch (Exception ex)
            {
                id = 0;

            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }
        public void ComprobarConexion(ref int Id)
        {
            try
            {
                string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "connection.txt");
                string text = File.ReadAllText(ruta);
                string conexion = text;
                SqlConnection conectar = new SqlConnection(conexion);

                conectar.Open();
                SqlCommand da = new SqlCommand("Select Top 1 IdUsuario from Usuarios", conectar);
                Id = Convert.ToInt32(da.ExecuteScalar());
                conectar.Close();
            }
            catch (Exception)
            {
                Id = 0;


            }
            
        }
    }
}
