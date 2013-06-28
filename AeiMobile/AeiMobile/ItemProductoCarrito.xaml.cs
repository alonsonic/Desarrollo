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
    public partial class ItemProductoCarrito : UserControl
    {
        private Producto producto;
        private int indexProducto;

        public ItemProductoCarrito(Producto producto, int indexProducto)
        {
            InitializeComponent();
            boton.Content = producto.Nombre;
            this.producto = producto;
            this.indexProducto = indexProducto;
        }

        private void botonBorrar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Borrar este producto del carrito del usuario
            ServicioAEIClient servicio = new ServicioAEIClient();

            servicio.borrarDetalleCarritoAsync(BufferUsuario.Usuario, BufferUsuario.Usuario.Carrito.Productos.ElementAt(indexProducto));
            servicio.ConsultarUsuarioCompleted += (s, a) =>
            {
                BufferUsuario.Usuario = a.Result;
                try
                {
                    //NavigationService.Navigate(new Uri("/StorePage.xaml", UriKind.Relative));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            };

        }
        private void actualizarUsuario()
        {
            //Declaramos el servicio
            ServicioAEIClient servicio = new ServicioAEIClient();

            //Llamamos el metodo del servicio
            servicio.ConsultarUsuarioAsync("alonsonic@gmail.com");

            //Cuando se complete la llamada se disparara el evento
            servicio.ConsultarUsuarioCompleted += (s, a) =>
            {
                BufferUsuario.Usuario = a.Result;
                try
                {
                    NavigationService navegador = null;
                    navegador.Navigate(new Uri("/StorePage.xaml", UriKind.Relative));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            };
        }
        private void boton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Navegar hacia el detalle del producto
            ArticuloPivotPage.producto = producto;
            (Application.Current.RootVisual as PhoneApplicationFrame).Navigate(new Uri("//ArticuloPivotPage.xaml", UriKind.Relative));
        }
    }
}
