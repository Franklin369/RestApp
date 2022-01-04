using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Xamarin.Forms;
using RestApp.Modelo;
using RestApp.Servicio;
namespace RestApp.VistaModelo
{
   public class VMproductos
    {
        public List<Mproductos> MostrarProductos(int Idgrupo)
        {
            var productos = new List<Mproductos>();
            try
            {
                DataTable dt = new DataTable();
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrar_Productos_por_grupo", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@id_grupo", Idgrupo);
                da.SelectCommand.Parameters.AddWithValue("@buscador", "");

                da.Fill(dt);
                foreach (DataRow rdr in dt.Rows)
                {
                    var parametros = new Mproductos();
                    parametros.Descripcion = rdr["Descripcion"].ToString();
                    parametros.Idproducto = Convert.ToInt32(rdr["Id_Producto1"]);
                    parametros.Precio = (rdr["Id_Producto1"]).ToString()+"|" + (rdr["Precio_de_venta"]).ToString();
                    parametros.ColorHtml = rdr["ColorHtml"].ToString();
                    productos.Add(parametros);
                }
                return productos;
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");

            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
            return null;
        }
        public List<Mproductos> buscarProductos(string buscador)
        {
            var productos = new List<Mproductos>();
            try
            {
                DataTable dt = new DataTable();
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("buscarProductos", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@buscador", buscador);
      

                da.Fill(dt);
                foreach (DataRow rdr in dt.Rows)
                {
                    var parametros = new Mproductos();
                    parametros.Descripcion = rdr["Descripcion"].ToString();
                    parametros.Idproducto = Convert.ToInt32(rdr["Id_Producto1"]);
                    parametros.Precio = (rdr["Id_Producto1"]).ToString() + "|" + (rdr["Precio_de_venta"]).ToString();
                    parametros.ColorHtml = rdr["ColorHtml"].ToString();
                    productos.Add(parametros);
                }
                return productos;
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");

            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
            return null;
        }

    }
}
