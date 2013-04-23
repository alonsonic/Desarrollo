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
using AeiCliente.ServicioProducto;
using Windows.UI.Popups;

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

namespace AeiCliente
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class DetalleProductoPage : Page
    {
		bool comentariosVisible = false;
        Producto producto = null;
		
        public DetalleProductoPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Se invoca cuando esta página se va a mostrar en un objeto Frame.
        /// </summary>
        /// <param name="e">Datos de evento que describen cómo se llegó a esta página. La propiedad Parameter
        /// se usa normalmente para configurar la página.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            producto = e.Parameter as Producto;
            textNombre.Text = producto.Nombre;
            textDescripcion.Text = producto.Descripcion;
            textPrecio.Text = "Precio " + producto.Precio.ToString() + " Bs";
            textCantidad.Text = "FALTA CANTIDAD";
        }

        private void botonMostrarComentario_Click(object sender, RoutedEventArgs e)
        {
			if(comentariosVisible)
			{
				OcultarComentarios.Begin();
				comentariosVisible = false;
			}
			else
			{
				mostrarComentarios.Begin();
        		comentariosVisible = true;
			}
		}

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
        	this.Frame.Navigate(typeof(ListaCompraPage));
        }

        private void botonComprar_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            MessageDialog mensajeError = new MessageDialog("Debe iniciar sesión para realizar compras.");

            if (BufferUsuario.isConectado())
            {
                BufferUsuario.comprar(producto, 100, 20);
            }
            else
            {
                mensajeError.ShowAsync();
            }
        }
	}
}
