using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RestApp.VistaModelo;
using System.IO;

namespace RestApp.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            dibujarUsuarios();
        }
        public string login;
        public void dibujarUsuarios()
        {
            DataTable dt = new DataTable();
            VMusuarios funcion = new VMusuarios();
            funcion.dibujarUsuarios(ref dt);
            foreach (DataRow rdr in dt.Rows )
            {
                Label l = new Label();
                StackLayout p = new StackLayout();
                ImageButton pt = new ImageButton();

                l.Text = rdr["Login"].ToString();
                l.HeightRequest = 25;
                l.FontAttributes = FontAttributes.Bold;
                l.BackgroundColor = Color.Transparent;
                l.TextColor = Color.White;
                l.HorizontalTextAlignment = TextAlignment.Center;
                l.VerticalTextAlignment = TextAlignment.Center;
             
                p.HeightRequest = 167;
                p.WidthRequest = 155;
                p.BackgroundColor = Color.FromRgb(37, 37, 37);

                pt.Source = null;
                byte[] bi = (Byte[])rdr["Icono"];
                MemoryStream ms = new MemoryStream(bi);
                pt.Source = ImageSource.FromStream(() => ms);
                pt.HeightRequest = 140;
                pt.WidthRequest = 140;
                pt.CommandParameter = rdr["Login"].ToString();
                 
                Frame frameImagenButton = new Frame();
                frameImagenButton.Content = pt;
                frameImagenButton.Margin = 0;
                frameImagenButton.Padding =-16;
                frameImagenButton.HeightRequest = pt.HeightRequest;
                frameImagenButton.WidthRequest = pt.WidthRequest;
                frameImagenButton.HasShadow = false;
                frameImagenButton.CornerRadius = 70;


                frameImagenButton.VerticalOptions = LayoutOptions.Center;
                frameImagenButton.HorizontalOptions = LayoutOptions.Center;


               

                p.Children.Add(l);
                p.Children.Add(frameImagenButton);
                Frame frameStackLayout = new Frame();
                frameStackLayout.Content = p;
                frameStackLayout.Margin = 10;
                frameStackLayout.Padding = 5;
                frameStackLayout.HeightRequest = p.HeightRequest;
                frameStackLayout.WidthRequest = p.WidthRequest;
                frameStackLayout.HasShadow = true;
                frameStackLayout.CornerRadius = 40;
                frameStackLayout.VerticalOptions = LayoutOptions.Center;
                frameStackLayout.HorizontalOptions = LayoutOptions.Center;
                frameStackLayout.BackgroundColor = p.BackgroundColor;

                PanelUsuarios.Children.Add(frameStackLayout);
                pt.Clicked += Pt_Clicked;
            }
        }

        private void Pt_Clicked(object sender, EventArgs e)
        {
            login = ((ImageButton)sender).CommandParameter.ToString();
            MarcarContraseña.login = login;
            Navigation.PushAsync(new MarcarContraseña());
            
        }
    }
}