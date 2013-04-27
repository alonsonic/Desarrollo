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
    public sealed partial class ItemHistorial : UserControl
    {

        private ServicioAEIClient servicioAei = new ServicioAEIClient();
        ListaCompraPage padre = null;
        DetalleCompra detalle = null;

        public ItemHistorial()
        {
            this.setImagenProducto("ms-appx:/App_Data/item.png.png");
            this.InitializeComponent();
        }

        public ItemHistorial(DetalleCompra detalle)
        {
            this.InitializeComponent();
            this.detalle = detalle;
            
            textoNombreProducto.Text = detalle.Cantidad + " " + detalle.Producto.Nombre;
            this.setImagenProducto("http://" + Constante.Ip + ":8080/" + detalle.Producto.ImagenDetalle);
        }

        public void setImagenProducto(String imageSource)
        {
            BitmapImage newImage = new BitmapImage();
            newImage.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            newImage.UriSource = new Uri(imageSource);
            this.imagenProducto.Source = newImage;
        }

        private void BotonCalificacion_Click(object sender, RoutedEventArgs e)
        {
            Popup popup = new Popup();
            CalificarPopup direcPopup = new CalificarPopup(popup,detalle.Producto);
            popup.Child = direcPopup;
            popup.IsOpen = true;
        }

    }
}
