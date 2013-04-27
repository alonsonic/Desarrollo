using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using AeiCliente.ServicioAEI;
using Windows.UI.Popups;

namespace AeiCliente
{
    public sealed partial class DetallePopup : UserControl
    {
        private Popup popup = null;
        private int cantidadProducto = 1;
        private int cantidadProductoMax = 0;
        private ServicioAEIClient servicioAei = new ServicioAEIClient();
        private DetalleCompra detalleCompra = new DetalleCompra();
        private Producto producto;

        public DetallePopup(Popup padre, Producto producto)
        {
            this.producto = producto;
            this.cantidadProductoMax = producto.Cantidad;
            if (padre == null) throw new ArgumentNullException("Debe asignar un Popup al controlador");
            this.popup = padre;
            this.InitializeComponent();
            textCantidad.Text = cantidadProducto.ToString();
        }
		
		private void botonMenosClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (cantidadProducto > 1)
            {
                cantidadProducto--;
                textCantidad.Text = cantidadProducto.ToString();
            }
        }
		
		private void botonMasClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (cantidadProducto < cantidadProductoMax)
            {
                cantidadProducto++;
                textCantidad.Text = cantidadProducto.ToString();
            }
        }

        public int CantidadProducto
        {
            get { return cantidadProducto; }
            set { cantidadProducto = value; }
        }

        private async void botonAddCarrito_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            detalleCompra.Cantidad = cantidadProducto;
            detalleCompra.Producto = producto;
            detalleCompra.Monto = producto.Precio;

            BufferUsuario.Usuario = await servicioAei.agregarCarritoAsync(BufferUsuario.Usuario, detalleCompra);
            MessageDialog mensajeError = new MessageDialog("Se agrego el poducto a su carrito con exito!");
            mensajeError.ShowAsync();
            popup.IsOpen = false;
        }

        private void botonBack_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
        	// TODO: Agregar implementación de controlador de eventos aquí.popup.IsOpen = false;
        }
    }
}
