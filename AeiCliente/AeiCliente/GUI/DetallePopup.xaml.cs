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

        public DetallePopup(Popup padre,int cantidadProductoMax)
        {
            this.cantidadProductoMax = cantidadProductoMax;
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

        private void botonAddCarrito_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            DetalleProductoPage.detalleCompra.Cantidad = cantidadProducto;
            popup.IsOpen = false;
        }
    }
}
