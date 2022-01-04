using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RestApp.VistaModelo;
using System.Data;
using RestApp.Modelo;

namespace RestApp.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Mesas : ContentPage
    {
        public Mesas()
        {
            InitializeComponent();
            dibujarSalones();
           
        }
        int idsalon=0;
        DataTable dtmozos = new DataTable();
        public static int idusuario;
        int idmesa;
        protected override void OnAppearing()
        {
            dibujarMesasPorSalon();
        }
        public void dibujarSalones()
        {
            DataTable dt = new DataTable();
            VMsalon funcion = new VMsalon();
            funcion.dibujarsalones(ref dt);
            foreach (DataRow rdr in dt.Rows)
            {
                Button b = new Button();
                b.Text = rdr["Salon"].ToString();
                b.CommandParameter = rdr["Id_salon"].ToString();
                b.HeightRequest = 50;
                b.WidthRequest = 150;
                b.BackgroundColor = Color.FromRgb(39, 20, 2);
                b.BorderWidth = 2;
                b.CornerRadius = 5;
                b.BorderColor= Color.FromRgb(248, 133, 18);
                b.TextColor = Color.White;
                PanelSalones.Children.Add(b);
                b.Clicked += B_Clicked;
            }
        }
        
        private void B_Clicked(object sender, EventArgs e)
        {
            idsalon = Convert.ToInt32(((Button)sender).CommandParameter);
            dibujarMesasPorSalon();
        }
        private void mostrarMozoxMesa()
        {
            var funcion = new VMmesas();
             dtmozos = new DataTable();
            funcion.mostrar_mozo_por_mesa(ref dtmozos);
        }
        public void dibujarMesasPorSalon()
        {
            mostrarMozoxMesa();
            PanelMesas.Children.Clear();
            DataTable dt = new DataTable();
            Msalon parametros = new Msalon();
            VMmesas funcion = new VMmesas();
            parametros.Id_salon = idsalon;
            funcion.dibujarMesasPorSalon(parametros, ref dt);

            foreach (DataRow rdr in dt.Rows)
            {
                string estado;
                Button b = new Button();
                Button LabelMozo = new Button();
                Frame contRedondeado = new Frame();
                StackLayout contStack = new StackLayout();

                contRedondeado.HeightRequest = 200;
                contRedondeado.WidthRequest = 200;
                contRedondeado.HasShadow = false;
                contRedondeado.CornerRadius = 12;
                contStack.HeightRequest = 200;
                contStack.WidthRequest = 200;
                contStack.BackgroundColor = Color.Transparent;

                b.Text = rdr["Mesa"].ToString();
               
                b.FontSize = 20;
                b.FontAttributes = FontAttributes.Bold;
                b.CommandParameter = rdr["Id_mesa"].ToString();
                b.BackgroundColor = Color.Transparent;
                b.VerticalOptions = LayoutOptions.CenterAndExpand;
                LabelMozo.HeightRequest = 50;
                LabelMozo.WidthRequest = 50;
                LabelMozo.FontSize = 20;
                LabelMozo.Background = Color.Transparent;
                LabelMozo.TextColor = Color.White;
                LabelMozo.FontAttributes = FontAttributes.Bold;
                estado = rdr["Estado_de_Disponibilidad"].ToString();
                contStack.Children.Add(b);
                if (estado == "LIBRE")
                {
                    contRedondeado.BackgroundColor = Color.FromRgb(197, 255, 145);
                    b.TextColor = Color.Black;
                    contStack.Children.Add(b);
                }
                else
                {
                    foreach (DataRow row in dtmozos.Rows)
                    {
                        string mesa = Convert.ToString(row["Mesa"]);
                        string usuario = Convert.ToString(row["Login"]);
                        if (mesa == b.Text)
                        {
                            LabelMozo.Text = usuario;
                        }
                    }
                    contRedondeado.BackgroundColor = Color.FromRgb(255, 45, 54);
                    b.TextColor = Color.White;
                    
                    contStack.Children.Add(LabelMozo);
                }
                contRedondeado.Content = contStack;
                //Frame frameBoton = new Frame();
                //frameBoton.Content = b;
                //frameBoton.Margin = 5;
                //frameBoton.Padding = -5;
                //frameBoton.HeightRequest = b.HeightRequest;
                //frameBoton.WidthRequest = b.WidthRequest;
                //frameBoton.CornerRadius = 5;
                //frameBoton.HasShadow = true;
                PanelMesas.Children.Add(contRedondeado);
                b.Clicked += B_Clicked1;
            }
        }

        private void B_Clicked1(object sender, EventArgs e)
        {
            idmesa = Convert.ToInt32(((Button)sender).CommandParameter);
            Ventas.Idusuario = idusuario;
            Ventas.idmesa = idmesa;
            Navigation.PushAsync(new Ventas());
        }
    }
}