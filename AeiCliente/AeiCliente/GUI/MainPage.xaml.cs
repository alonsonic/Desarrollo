using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using AeiCliente.ServicioUsuario;
using AeiCliente.ServicioProducto;
using AeiCliente.GUI;

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

namespace AeiCliente
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ServicioProductoClient servicioProducto = new ServicioProductoClient();
        ServicioUsuarioClient servicioUsuario = new ServicioUsuarioClient();
        
        
        public MainPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void botonCarrito_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            MessageDialog mensajeError = new MessageDialog("Debe iniciar sesión para llevar una lista de compras.");;

            if (BufferUsuario.isConectado())
                mensajeError.ShowAsync();
            else
            {
                mensajeError.ShowAsync();
            }
        }

        private void botonPerfil_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            MessageDialog mensajeError = new MessageDialog("Debe iniciar sesión para acceder a su perfil.");

            if (BufferUsuario.isConectado())
            {
                this.Frame.Navigate(typeof(PerfilPage));
            }
            else
            {
                mensajeError.ShowAsync();
            }
        }

        private void botonLupa_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ListaCompraPage));
        }

        private async void botonInicioSesion_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (botonInicioSesion.Content.Equals("Ingresar"))
            {
                OpenIdClient openId = new OpenIdClient();
                openId.clickOpenID(sender, e);
                if (BufferUsuario.Usuario != null)
                    botonInicioSesion.Content = "Salir";
            }
            else
            {
                BufferUsuario.Usuario = null;
                botonInicioSesion.Content = "Ingresar";
            }
        }

        private async void botonBloques_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ListaProducto.ListaProductos = await servicioProducto.BuscarProductoPorCategoriaAsync("figuras");
            ListaProducto.TextoBusqueda = "Bloques";
            this.Frame.Navigate(typeof(ListaProductoPage));
        }

        private async void botonVehiculos_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ListaProducto.ListaProductos = await servicioProducto.BuscarProductoPorCategoriaAsync("figuras");
            ListaProducto.TextoBusqueda = "Vehiculos";
            this.Frame.Navigate(typeof(ListaProductoPage));
        }

        private async void botonMunecas_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ListaProducto.ListaProductos = await servicioProducto.BuscarProductoPorCategoriaAsync("muñecas");
            ListaProducto.TextoBusqueda = "Muñecas";
            this.Frame.Navigate(typeof(ListaCompraPage));
        }

        private async void botonJuegosMesa_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ListaProducto.ListaProductos = await servicioProducto.BuscarProductoPorCategoriaAsync("juegos de mesa");
            ListaProducto.TextoBusqueda = "Juegos de Mesa";
            this.Frame.Navigate(typeof(ListaCompraPage));
        }
        
    }
}
