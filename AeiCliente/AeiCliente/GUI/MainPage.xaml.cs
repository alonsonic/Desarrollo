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
using AeiCliente.ServicioAEI;
using AeiCliente.GUI;

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

namespace AeiCliente
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ServicioAEIClient servicio = new ServicioAEIClient();
        
        
        public MainPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void validarStatusUsuario()
        {
            if (BufferUsuario.Usuario.Status.Equals("I"))
            {
                Popup popup = new Popup();
                CodigoConfirPopup direcPopup = new CodigoConfirPopup(popup);
                popup.Child = direcPopup;
                popup.IsOpen = true;
            }
        }

        private void botonCarrito_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            MessageDialog mensajeError = new MessageDialog("Debe iniciar sesión para llevar una lista de compras.");

            if (BufferUsuario.isConectado())
                this.Frame.Navigate(typeof(ListaCompraPage));
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
           this.Frame.Navigate(typeof(ListaProductoPage));
        }

        private async void botonInicioSesion_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (botonInicioSesion.Content.Equals("Ingresar"))
            {
                Popup popup = new Popup();
                RegistroUsuarioPopup direcPopup = new RegistroUsuarioPopup(popup, sender);
                popup.Child = direcPopup;
                popup.IsOpen = true;

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
            ListaProducto.ListaProductos = await servicio.BuscarProductoPorCategoriaAsync("figuras");
            this.Frame.Navigate(typeof(ListaProductoPage));
        }

        private async void botonVehiculos_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ListaProducto.ListaProductos = await servicio.BuscarProductoPorCategoriaAsync("vehiculos");
            this.Frame.Navigate(typeof(ListaProductoPage));
        }

        private async void botonMunecas_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ListaProducto.ListaProductos = await servicio.BuscarProductoPorCategoriaAsync("muñecas");
            this.Frame.Navigate(typeof(ListaProductoPage));
        }

        private async void botonJuegosMesa_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ListaProducto.ListaProductos = await servicio.BuscarProductoPorCategoriaAsync("juegos de mesa");
            this.Frame.Navigate(typeof(ListaProductoPage));
        }

        private async void botonAccion_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ListaProducto.ListaProductos = await servicio.BuscarProductoPorCategoriaAsync("figuras de acción");
            this.Frame.Navigate(typeof(ListaProductoPage));
        }

        private async void botonInfantiles_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ListaProducto.ListaProductos = await servicio.BuscarProductoPorCategoriaAsync("juegos infantiles");
            this.Frame.Navigate(typeof(ListaProductoPage));
        }

        private async void botonAprendizaje_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ListaProducto.ListaProductos = await servicio.BuscarProductoPorCategoriaAsync("aprendizaje");
            this.Frame.Navigate(typeof(ListaProductoPage));
        }

        private async void botonDeportes_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ListaProducto.ListaProductos = await servicio.BuscarProductoPorCategoriaAsync("deportes");
            this.Frame.Navigate(typeof(ListaProductoPage));
        }

        private async void botonNinas_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ListaProducto.ListaProductos = await servicio.BuscarProductoPorCategoriaAsync("juguetes para niñas");
            this.Frame.Navigate(typeof(ListaProductoPage));
        }

        private async void botonVideoJuegos_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ListaProducto.ListaProductos = await servicio.BuscarProductoPorCategoriaAsync("video juegos");
            this.Frame.Navigate(typeof(ListaProductoPage));
        }
        
    }
}
