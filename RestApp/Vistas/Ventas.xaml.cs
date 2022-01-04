using RestApp.Modelo;
using RestApp.VistaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup.Services;
namespace RestApp.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Ventas : ContentPage
    {
        public Ventas()
        {
            InitializeComponent();
            mostrarGrupos();
            EliVentasIncompMovil();
            VerificarVentas();
        }
        protected override void OnAppearing()
        {
            if (estadoAutomatico == true)
            {
                InsertarVentas();
                Mostrardetalleventa();
                estadoAutomatico = false;
            }
        }
        public static bool estadoAutomatico = false;
        private void VerificarVentas()
        {
            VMventas funcion = new VMventas();
            Mventas parametros = new Mventas();
            parametros.Idmesa = idmesa;
            funcion.mostrarIdventaMesa(ref idventa, parametros);
            if (idventa > 0)
            {
                ventagenerada = "VENTA GENERADA";
                Mostrardetalleventa();
            }
            else
            {
                ventagenerada = "VENTA NUEVA";
            }
        }
        private void EliVentasIncompMovil()
        {
            var funcion = new VMventas();
            var parametros = new Mventas();
            parametros.Idmesa = idmesa;
            funcion.eliminarVenIncomMovil(parametros);
        }
        int idgrupo;
        public static int Idusuario;
        public static int idmesa;
        public static int idproducto;
        public static double precioventa;
        string ventagenerada;
        int idventa;
        double total = 0;
        int iddetalleventa;
        int contadorDventa = 0;
        private void btnBuscar_Clicked(object sender, EventArgs e)
        {
            estadoAutomatico = false;
            Navigation.PushAsync(new Buscadorproductos());
        }

        private void btnmesas_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void btnenviar_Clicked(object sender, EventArgs e)
        {
            if (total > 0)
            {
                Insertarsolicitud();
                EditarEstadoMesaOcupado();

                EditarEstadoVentasEspera();
              
                await DisplayAlert("Enviado", "Pedido enviado", "OK");
  EditardetalleventaAenviado();
                await Navigation.PopAsync();
            }
        }
        private void Insertarsolicitud()
        {
            var funcion = new VMventas();
            var parametros = new Mventas();
            parametros.Idventa = idventa;
            funcion.InsertarSolicitud(parametros);
        }
        private void EditardetalleventaAenviado()
        {
            var funcionmostrar = new VMdetalleventa();
            var parametrosmostrar = new Mdetalleventa();
            parametrosmostrar.idventa = idventa;
            parametrosmostrar.Idmesa = idmesa;
            var dt = funcionmostrar.MostrarDetalleVenta(parametrosmostrar);
            //*****
            var funcion = new VMdetalleventa();
            var parametros = new Mdetalleventa();
            foreach (var rdr in dt)
            {
                iddetalleventa = Convert.ToInt32(rdr.Iddetalleventa);
                parametros.Iddetalleventa = iddetalleventa;
                funcion.editarenviadoDV(parametros);
            }
        }
        private void EditarEstadoVentasEspera()
        {
            var funcion = new VMventas();
            var parametros = new Mventas();
            parametros.Idventa = idventa;
            funcion.EditarEstadoVentasEspera(parametros);
        }
        private void EditarEstadoMesaOcupado()
        {
            var funcion = new VMmesas();
            var parametros = new Mmesas();
            parametros.Id_mesa = idmesa;
            funcion.EditarEstadoMesaOcupado(parametros);
        }
        private void mostrarGrupos()
        {
            var funcion = new VMgrupos();
            var data = funcion.mostrarGrupos();
            Listagrupos.ItemsSource = data;
        }
        private void MostrarProductos()
        {
            var funcion = new VMproductos();
            var data = funcion.MostrarProductos(idgrupo);
            ListaProductos.ItemsSource = data;
        }


        private void btnGrupo_Clicked(object sender, EventArgs e)
        {
            idgrupo = Convert.ToInt32(((Button)sender).CommandParameter);
            MostrarProductos();
        }

        private void btnproducto_Clicked(object sender, EventArgs e)
        {
            string cadena = (((Button)sender).CommandParameter).ToString();
            string[] separadas = cadena.Split('|');
            idproducto = Convert.ToInt32(separadas[0]);
            precioventa = Convert.ToDouble(separadas[1]);


            InsertarVentas();
        }
        private void InsertarVentas()
        {
            if (ventagenerada == "VENTA NUEVA")
            {
                var funcion = new VMventas();
                var parametros = new Mventas();
                parametros.Idusuario = Idusuario;
                parametros.Idmesa = idmesa;
                if (funcion.Insertar_ventas(parametros) == true)
                {
                    VerificarVentas();
                }
            }
            if (ventagenerada == "VENTA GENERADA")
            {
                insertarDetalleventa();
            }


        }
        private void insertarDetalleventa()
        {
            var funcion = new VMdetalleventa();
            var parametros = new Mdetalleventa();
            parametros.idventa = idventa;
            parametros.Id_producto = idproducto;
            parametros.cantidad = 1;
            parametros.Estado = "ENVIADO";
            parametros.Estado_de_pago = "DEBE";
            parametros.Donde_se_consumira = "LOCAL";
            funcion.insertarDetalle_venta(parametros);
            Mostrardetalleventa();
        }
        private void Mostrardetalleventa()
        {
            var funcion = new VMdetalleventa();
            var parametros = new Mdetalleventa();

            parametros.idventa = idventa;
            parametros.Idmesa = idmesa;
            var data = funcion.MostrarDetalleVenta(parametros);
            listaDetalleVenta.ItemsSource = data;



            contadorDventa = data.Count;


            total = 0;
            foreach (var item in data)
            {
                total += item.Importe;
            }
            lblTotal.Text = total.ToString();
        }
        private void eliminarVenta()
        {
            var funcion = new VMventas();
            var parametros = new Mventas();
            parametros.Idventa = idventa;
            funcion.eliminarVenta(parametros);

        }
        private void LiberarMesa()
        {
            var funcion = new VMmesas();
            var parametros = new Mmesas();
            parametros.Id_mesa = idmesa;
            funcion.EditarEstadoMesaLibre(parametros);
        }
        private void btnBorrarDV1_Invoked(object sender, EventArgs e)
        {
            iddetalleventa = Convert.ToInt32(((SwipeItem)sender).CommandParameter);
            EliminarDetalleventa();
        }
        private void EliminarDetalleventa()
        {
            var funcion = new VMdetalleventa();
            var parametros = new Mdetalleventa();
            parametros.Iddetalleventa = iddetalleventa;
            funcion.eliminarDetalleventa(parametros);
            Mostrardetalleventa();

            if (contadorDventa == 0)
            {
                eliminarVenta();
                LiberarMesa();
                VerificarVentas();
            }

        }

        private void btnBorrarDV2_Invoked(object sender, EventArgs e)
        {
            iddetalleventa = Convert.ToInt32(((SwipeItem)sender).CommandParameter);
            EliminarDetalleventa();
        }
    }
}