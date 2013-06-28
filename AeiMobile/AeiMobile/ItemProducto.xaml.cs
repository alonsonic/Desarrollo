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
    public partial class ItemProducto : UserControl
    {
        private Producto producto;


        public ItemProducto(Producto producto)
        {
            InitializeComponent();
            boton.Content = producto.Nombre;
            this.producto = producto;
        }

        private void boton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Navegar hacia pantalla detalle del producto
            ArticuloPivotPage.producto = producto;
           (Application.Current.RootVisual as PhoneApplicationFrame).Navigate(new Uri("//ArticuloPivotPage.xaml", UriKind.Relative));
        }
    }
}
