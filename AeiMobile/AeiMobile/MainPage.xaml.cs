using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using AeiMobile.ServicioAEI;

namespace AeiMobile
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void  Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //Declaramos el servicio
            ServicioAEIClient servicio = new ServicioAEIClient();
            Usuario usuario;

            //Llamamos el metodo del servicio
            servicio.ConsultarUsuarioAsync("alonsonic@gmail.com");

            //Cuando se complete la llamada se disparara el evento
            servicio.ConsultarUsuarioCompleted += (s, a) =>
            {
                usuario = a.Result;
                try
                {
                    NavigationService.Navigate(new Uri("/StorePage.xaml", UriKind.Relative));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            };
        }
    }
}