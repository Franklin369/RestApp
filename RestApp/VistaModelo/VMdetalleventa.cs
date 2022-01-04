using System;

using System.Collections.Generic;
using System.Text;
using RestApp.Modelo;
using System.Data;
using System.Data.SqlClient;
using Xamarin.Forms;
using RestApp.Servicio;
namespace RestApp.VistaModelo
{
    public class VMdetalleventa
    {
        public bool insertarDetalle_venta(Mdetalleventa parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarDetalle_venta", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idventa", parametros.idventa);
                cmd.Parameters.AddWithValue("@Id_producto", parametros.Id_producto);
                cmd.Parameters.AddWithValue("@cantidad", parametros.cantidad);
                cmd.Parameters.AddWithValue("@Estado_de_pago", parametros.Estado_de_pago);
                cmd.Parameters.AddWithValue("@Donde_se_consumira", parametros.Donde_se_consumira);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception )
            {
                return false;
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }
        public List<Mdetalleventa> MostrarDetalleVenta(Mdetalleventa parametrospedir)
        {
            var productos = new List<Mdetalleventa>();
            try
            {
                var dt = new DataTable();
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrarDetalleVenta", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Id_mesa", parametrospedir.Idmesa);
                da.SelectCommand.Parameters.AddWithValue("@Idventa", parametrospedir.idventa);

                da.Fill(dt);
                foreach (DataRow rdr in dt.Rows)
                {
                    var parametros = new Mdetalleventa();
                    parametros.Producto = rdr["Producto"].ToString();
                    parametros.Iddetalleventa = Convert.ToInt32(rdr["iddetalle_venta"]);
                    parametros.Importe = Convert.ToDouble(rdr["Importe"]);
                    parametros.Total += Convert.ToDouble(rdr["Importe"]);
                    parametros.cantidad = Convert.ToDouble(rdr["Cant"]);
                    parametros.preciounitario = Convert.ToDouble(rdr["P_Unit"]);
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
        public bool eliminarDetalleventa(Mdetalleventa parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("eliminarDetalleventa", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Iddetalle", parametros.Iddetalleventa);   
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }
        public bool editarenviadoDV(Mdetalleventa parametros)
        {
            try
            {

                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("editarAenviado", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Iddetalleventa", parametros.Iddetalleventa);
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
