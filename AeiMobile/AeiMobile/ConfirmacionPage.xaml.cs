using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using AeiMobile.ServicioAEI;

namespace AeiMobile
{
    public partial class ConfirmacionPage : PhoneApplicationPage
    {
        private int cantidadProducto = 1;
        private ServicioAEIClient servicioAei = new ServicioAEIClient();
        private DetalleCompra detalleCompra = new DetalleCompra();
        public static Producto producto;

        public ConfirmacionPage()
        {
            InitializeComponent();
        }
		
		private void botonMas_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            
			if (cantidadProducto < producto.Cantidad)
            {
                cantidadProducto++;
                textCantidad.Text = cantidadProducto.ToString();
            }
		}

		private void botonMenos_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			 if (cantidadProducto > 1)
            {
                cantidadProducto--;
                textCantidad.Text = cantidadProducto.ToString();
            }
		}

		private void botonComprar_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            detalleCompra.Cantidad = cantidadProducto;
            detalleCompra.Producto = producto;
            detalleCompra.Monto = producto.Precio;

            servicioAei.agregarCarritoAsync(BufferUsuario.Usuario, detalleCompra);
            
            servicioAei.agregarCarritoCompleted += (s, a) =>
            {
                BufferUsuario.Usuario = a.Result;
                MessageBox.Show("Se agrego el poducto a su carrito con exito");
                NavigationService.Navigate(new Uri("/StorePage.xaml", UriKind.Relative));
                return;
            };
            
		}

    }
}