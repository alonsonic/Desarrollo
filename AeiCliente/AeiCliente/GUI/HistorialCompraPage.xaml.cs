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
    public sealed partial class HistorialCompraPage : Page
    {
        int indexCompra = 0;

        public HistorialCompraPage()
        {
            this.InitializeComponent();
        }
        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            int indexCompra = (int) e.Parameter;
            cargarCompra();
        }

        public void cargarCompra()
        {
            listaItemProducto.Items.Clear();
            string totalCompra;
            string fechaSolicitud;
            string fechaEntrega;
            string status;

            if (BufferUsuario.Usuario == null && BufferUsuario.Usuario.Compras.ElementAt(indexCompra) != null)
                return;

            Compra compra = BufferUsuario.Usuario.Compras.ElementAt(indexCompra);
            for (int indexProducto = 0; indexProducto < compra.Productos.Count; indexProducto++)
            {
                ItemHistorial itemProducto = new ItemHistorial(compra.Productos.ElementAt(indexCompra));
                listaItemProducto.Items.Add(itemProducto);
            }

            totalCompra = compra.MontoTotal.ToString();

            if(compra.FechaSolicitud == null)
            {
                fechaSolicitud = "---";
            }

            else
            {
                fechaSolicitud = compra.FechaSolicitud.ToString("yyyy-MM-dd");
            }

            if(compra.FechaEntrega == null)
            {
                fechaEntrega = "---";
            }
            else
            {
                fechaEntrega = compra.FechaEntrega.ToString("yyyy-MM-dd");
            }

            if (compra.Status.Equals("P"))
                status = "Entregado";
            else
                status = "Por entregar";
                
            textDescripcion.Text = "Total de la compra: " + totalCompra + " Bs   Fecha de solicitud: "+fechaSolicitud + " Fecha de entrega: "+fechaEntrega+
                                    " Status: " + status + @"  Dirección: " + compra.Direccion.Estado + ", " +compra.Direccion.Ciudad + ", " + compra.Direccion.Descripcion;
        }

        private void botonHome_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
        	this.Frame.Navigate(typeof(MainPage));
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

    }

}
