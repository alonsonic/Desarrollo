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

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

namespace AeiCliente
{

    public sealed partial class DetalleProductoPage : Page
    {
		bool comentariosVisible = false;
        public static Producto producto = null;
        public static bool isCompra = false;
        ServicioAEIClient servicioAei = new ServicioAEIClient();
        public static DetalleCompra detalleCompra = new DetalleCompra();

        public DetalleProductoPage()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            producto = e.Parameter as Producto;
            textNombre.Text = producto.Nombre;
            textDescripcion.Text = producto.Descripcion;
            textPrecio.Text = "Precio " + producto.Precio.ToString() + " Bs";
            if (producto.Cantidad == 1) textCantidad.Text = producto.Cantidad.ToString() + " unidad disponible";
            else textCantidad.Text = producto.Cantidad.ToString()+" unidades disponibles";
            producto.Calificaciones = await servicioAei.buscarCalificacionProductoAsync(producto.Id);
            //cargarComentarios();
        }

        private async void cargarComentarios()
        {
            List<Calificacion> listaCalificacion = producto.Calificaciones;
            if (listaCalificacion != null)
            {
                for (int indexCalificacion = 0; indexCalificacion < listaCalificacion.Count; indexCalificacion++)
                {
                    this.textComentarios.Text = this.textComentarios.Text + "\n \n" + listaCalificacion[indexCalificacion].Usuario.Nombre + " " + listaCalificacion[indexCalificacion].Usuario.Apellido + "\n" + listaCalificacion[indexCalificacion].Comentario;
                }
            }
            else this.textComentarios.Text = "\n \n Aun no tenemos calificaciones para este producto.";
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
            if(isCompra)
                this.Frame.Navigate(typeof(ListaCompraPage));
            else
                this.Frame.Navigate(typeof(ListaProductoPage));
        }

        private async void botonComprar_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            MessageDialog mensajeError = new MessageDialog("Debe iniciar sesión para realizar compras.","Inicie Sesión");

            if (BufferUsuario.isConectado())
            {
                Popup popup = new Popup();
                DetallePopup direcPopup = new DetallePopup(popup, producto.Cantidad);
                popup.Child = direcPopup;
                popup.IsOpen = true;

                detalleCompra.Producto = producto;
                detalleCompra.Monto = producto.Precio * detalleCompra.Cantidad;
                //LLamar al servicio para guardar la compra y que me retorne mi usuario
                BufferUsuario.Usuario = await servicioAei.agregarCarritoAsync(BufferUsuario.Usuario, detalleCompra);
                BufferUsuario.Usuario = await servicioAei.borrarDetalleCarritoAsync(BufferUsuario.Usuario, detalleCompra);
                var xs = BufferUsuario.Usuario.Carrito.Productos;
            }
            else
                mensajeError.ShowAsync();
        }
	}
}
