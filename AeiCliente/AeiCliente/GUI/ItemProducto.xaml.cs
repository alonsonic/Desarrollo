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
using AeiCliente.ServiceReference2;

 
// La plantilla de elemento Control de usuario está documentada en http://go.microsoft.com/fwlink/?LinkId=234236

namespace AeiCliente
{
    public sealed partial class ItemProducto : UserControl
    {

        public ItemProducto()
        {
            this.setImagenProducto("ms-appx:/App_Data/item.png.png");
            this.InitializeComponent();
        }

        public ItemProducto(int indexProducto)
        {
            this.InitializeComponent();

            Producto producto = ListaProducto.ListaProductos.ElementAt(indexProducto);
            textoNombreProducto.Text = producto.Nombre;
            //TODO: SETEAR LA IMAGEN
            //this.setImagenProducto("ms-appx:/App_Data/item.png.png");
        }

        public void setImagenProducto(String imageSource)
        {
            BitmapImage newImage = new BitmapImage();
            newImage.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            newImage.UriSource = new Uri(imageSource);
            this.imagenProducto.Source = newImage;
        }

        private void ButtonDetail_Click(object sender, RoutedEventArgs e)
        {
            //TODO
        }

    }
}
