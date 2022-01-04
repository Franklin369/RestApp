using RestApp.Modelo;
using RestApp.VistaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RestApp.Servicio;
using Xamarin.Essentials;

namespace RestApp.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MarcarContraseña : ContentPage
    {
        public MarcarContraseña()
        {
            InitializeComponent();
           

        }
        protected override void OnAppearing()
        {
            var tamaños = DeviceDisplay.MainDisplayInfo;
            var ancho = tamaños.Width;
            var alto = tamaños.Height;

            var izquierda = ((ancho * alto) * 300) / 3145728;
            var derecha = ((ancho * alto) * 300) / 3145728;
            var arriba = ((ancho * alto) * 20) / 3145728;
            var abajo = ((ancho * alto) * 20) / 3145728;
            var tamañoLetraBtnInicial = ((ancho * alto) * 20) / 3145728;
            var tamañoLetraBtnBorrar = ((ancho * alto) * 17) / 3145728;

            Panelbotones.Margin = new Thickness(izquierda, arriba, derecha, abajo);
            btnIniciar.FontSize = tamañoLetraBtnInicial;
            btnborrar.FontSize = tamañoLetraBtnBorrar;
        }
        public static string login;
        public int idusuario;
        private void btn7_Clicked(object sender, EventArgs e)
        {
            txtContraseña.Text += 7;
        }

        private void btn8_Clicked(object sender, EventArgs e)
        {
            txtContraseña.Text += 8;

        }

        private void btn9_Clicked(object sender, EventArgs e)
        {
            txtContraseña.Text += 9;

        }

        private void btn4_Clicked(object sender, EventArgs e)
        {
            txtContraseña.Text += 4;

        }

        private void btn5_Clicked(object sender, EventArgs e)
        {
            txtContraseña.Text += 5;

        }

        private void btn6_Clicked(object sender, EventArgs e)
        {
            txtContraseña.Text += 6;

        }

        private void btn1_Clicked(object sender, EventArgs e)
        {
            txtContraseña.Text += 1;

        }

        private void btn2_Clicked(object sender, EventArgs e)
        {
            txtContraseña.Text += 2;

        }

        private void btn3_Clicked(object sender, EventArgs e)
        {
            txtContraseña.Text += 3;

        }

        private void btnborrar_Clicked(object sender, EventArgs e)
        {
            txtContraseña.Text = "";

        }

        private void btn0_Clicked(object sender, EventArgs e)
        {
            txtContraseña.Text += 0;
        }

        private void btniniciar_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Error", "Datos incorrectos", "Ok");
        }

        private void btnBorrarCaract_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Error", "Datos incorrectos", "Ok");

        }

        private void txtContraseña_TextChanged(object sender, TextChangedEventArgs e)
        {
            validarContraseña();
        }
        private void validarContraseña()
        {
            Musuarios parametros = new Musuarios();
            VMusuarios funcion = new VMusuarios();
            parametros.Password =Bases.Encriptar(txtContraseña.Text);
            parametros.Login = login;
            funcion.validarUsuario(parametros, ref idusuario);

            if (idusuario >0)
            {
                Mesas.idusuario = idusuario;
                Application.Current.MainPage = new NavigationPage(new Mesas());
            }
        }
    }
}