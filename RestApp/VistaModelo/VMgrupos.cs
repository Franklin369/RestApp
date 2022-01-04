using RestApp.Modelo;
using RestApp.Servicio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Xamarin.Forms;

namespace RestApp.VistaModelo
{
    public  class VMgrupos
    {
        public List <Mgrupos> mostrarGrupos()
        {
            var grupos = new List<Mgrupos>();
            try
            {
                DataTable dt = new DataTable();
                CONEXIONMAESTRA.abrir();
                var da = new SqlDataAdapter("mostrarGruposProd", CONEXIONMAESTRA.conectar);
                da.Fill(dt);
                foreach (DataRow rdr in dt.Rows)
                {
                    var parametros = new Mgrupos();
                    parametros.Grupo = rdr["Grupo"].ToString();
                    parametros.Idgrupo =Convert.ToInt32( rdr["Idline"]);
                    parametros.ColorHtml = rdr["ColorHtml"].ToString();
                    grupos.Add(parametros);

                }
                return grupos;
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Error", ex.StackTrace, "OK");

               
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
            return null;
        }

    }
}
