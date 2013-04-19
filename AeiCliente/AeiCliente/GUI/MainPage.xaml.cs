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
using AeiCliente.ServiceReference2;
using AeiCliente.ServiceReference3;

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

namespace AeiCliente
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        IMPLEMENTARClient servicioWeb = new IMPLEMENTARClient();
        
        
        
        public MainPage()
        {
            this.InitializeComponent();
            prueba();
            
        }

        /// <summary>
        /// Se invoca cuando esta página se va a mostrar en un objeto Frame.
        /// </summary>
        /// <param name="e">Datos de evento que describen cómo se llegó a esta página. La propiedad Parameter
        /// se usa normalmente para configurar la página.</param>
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
            MessageDialog mensajeError = new MessageDialog("Debe iniciar sesión para acceder a su perfil."); ;

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
        	// AGREGAR EL INICIO DE SESION POR OPENID AQUI
            if (botonInicioSesion.Content.Equals("Ingresar"))
            {
                BufferUsuario.Usuario = await servicioWeb.buscarUsuarioAsync("alosnonic");
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
            ListaProducto.ListaProductos = await servicioWeb.buscarListaProductoAsync("bloques");
            ListaProducto.TextoBusqueda = "Bloques";
            this.Frame.Navigate(typeof(ListaCompraPage));
        }

        private async void botonVehiculos_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ListaProducto.ListaProductos = await servicioWeb.buscarListaProductoAsync("vehiculos");
            ListaProducto.TextoBusqueda = "Vehiculos";
            this.Frame.Navigate(typeof(ListaCompraPage));
        }

        private async void botonMunecas_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ListaProducto.ListaProductos = await servicioWeb.buscarListaProductoAsync("muñecas");
            ListaProducto.TextoBusqueda = "Muñecas";
            this.Frame.Navigate(typeof(ListaCompraPage));
        }

        private async void botonJuegosMesa_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ListaProducto.ListaProductos = await servicioWeb.buscarListaProductoAsync("juegos de mesa");
            ListaProducto.TextoBusqueda = "Juegos de Mesa";
            this.Frame.Navigate(typeof(ListaCompraPage));
        }
        private async void prueba()
        {
            ServicioDAOClient servicio = new ServicioDAOClient();
            int u = await servicio.setAgregarCompraAsync();
         
        }
    }
}
