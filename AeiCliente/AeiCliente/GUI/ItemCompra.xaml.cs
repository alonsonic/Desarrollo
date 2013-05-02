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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using AeiCliente.ServicioAEI;
using AeiCliente.GUI;

 
// La plantilla de elemento Control de usuario está documentada en http://go.microsoft.com/fwlink/?LinkId=234236

namespace AeiCliente
{
    public sealed partial class ItemCompra : UserControl
    {

        private ServicioAEIClient servicioAei = new ServicioAEIClient();
        Producto producto = null;
        ListaCompraPage padre = null;
        bool isCompra = true;
        int indexProducto;
        int indexDetalle;
        DetalleCompra detalle = null;

        public ItemCompra()
        {
            this.setImagenProducto("ms-appx:/App_Data/item.png.png");
            this.InitializeComponent();
        }

        public ItemCompra(int indexProducto, ListaCompraPage padre, bool isCarrito)
        {
            this.InitializeComponent();
            this.padre = padre;
            this.indexProducto = indexProducto;

            if(isCarrito)
            {
                producto = BufferUsuario.Usuario.Carrito.Productos.ElementAt(indexProducto).Producto;
                detalle = BufferUsuario.Usuario.Carrito.Productos.ElementAt(indexProducto);
            }


            textoNombreProducto.Text = detalle.Cantidad + " " + producto.Nombre;
            this.setImagenProducto("http://" + Constante.Ip + ":8080/" + producto.ImagenDetalle);
        }

        public void setImagenProducto(String imageSource)
        {
            BitmapImage newImage = new BitmapImage();
            newImage.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            newImage.UriSource = new Uri(imageSource);
            this.imagenProducto.Source = newImage;
        }

        private void botonDetalle_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            DetalleProductoPage.isCompra = true;
            padre.Frame.Navigate(typeof(DetalleProductoPage), producto);
        }

        private async void botonEliminar_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            BufferUsuario.Usuario = await servicioAei.ConsultarUsuarioAsync(BufferUsuario.Usuario.Email);
            BufferUsuario.Usuario = await servicioAei.borrarDetalleCarritoAsync(BufferUsuario.Usuario, BufferUsuario.Usuario.Carrito.Productos.ElementAt(indexProducto));
            padre.cargarCarrito();
        }

    }
}
