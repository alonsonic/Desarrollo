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

        public ItemProductoCarrito(Producto producto)
        {
            InitializeComponent();
            boton.Content = producto.Nombre;
            this.producto = producto;
        }

        private void botonBorrar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Borrar este producto del carrito del usuario
        }

        private void boton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Navegar hacia el detalle del producto
        }
    }
}
