using AeiCliente.ServicioAEI;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace AeiCliente
{
    public sealed partial class ListaCompraPage : Page
    {
        bool isCarrito = true;

        public ListaCompraPage()
        {
            this.InitializeComponent();
            cargarCarrito();
        }
       
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            cargarCarrito();
        }

        public void cargarCarrito()
        {
            listaItemProducto.Items.Clear();
            if (BufferUsuario.Usuario == null || BufferUsuario.Usuario.Carrito == null)
                return;

            for (int indexProducto = 0; indexProducto < BufferUsuario.Usuario.Carrito.Productos.Count; indexProducto++)
            {
                ItemCompra itemProducto = new ItemCompra(indexProducto, this, true);
                listaItemProducto.Items.Add(itemProducto);
            }
            textTotal.Text = "Total de la compra: " + BufferUsuario.Usuario.Carrito.MontoTotal + "Bs";
            
        }

        private void botonHome_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
        	this.Frame.Navigate(typeof(MainPage));
        }

        private void botonCompra_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

            if (BufferUsuario.Usuario.Carrito == null || BufferUsuario.Usuario.Carrito.Productos == null || BufferUsuario.Usuario.Carrito.Productos.Count() < 1)
            {
                new MessageDialog("Debe añadir algún producto a su carrito para finalizar su compra.").ShowAsync();
                return;
            }
            
            if (BufferUsuario.Usuario.Direcciones == null)
            {
                new MessageDialog("Debe añadir alguna dirección a su perfil para finalizar su compra.").ShowAsync();
                return;
            } 
            
            if (BufferUsuario.Usuario.MetodosPago == null)
            {
                new MessageDialog("Debe añadir algún método de pago a su perfil para finalizar su compra.").ShowAsync();
                return;
            }

            if (BufferUsuario.Usuario.Status.Equals("I "))
            {
                new MessageDialog("Debe activar su cuenta").ShowAsync();
                return;
            }

            Popup popup = new Popup();
            CheckoutPopup checkPopup = new CheckoutPopup(popup, this);
            popup.Child = checkPopup;
            popup.IsOpen = true;
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

        public void compraFinalizada()
        {
            this.Frame.Navigate(typeof(MainPage));
        }

    }

}
