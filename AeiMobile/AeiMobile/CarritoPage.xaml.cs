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
    public partial class CarritoPage : PhoneApplicationPage
    {
        private bool menuAbierto = false;

        public CarritoPage()
        {
            InitializeComponent();
            cargarProductos();
            Menu.Children.Add(new MenuControl());
        }

        private void cargarProductos()
        {
            this.listBoxProductos.Items.Clear();
            for (int indexProducto = 0; indexProducto < BufferUsuario.Usuario.Carrito.Productos.Count; indexProducto++)
            {
                ItemProductoCarrito itemProducto = new ItemProductoCarrito(BufferUsuario.Usuario.Carrito.Productos[indexProducto].Producto, indexProducto);
                listBoxProductos.Items.Add(itemProducto);
            }
            

        }

        private void botonMenu_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (menuAbierto)
            {
                StoryMenuCerrar.Begin();
                menuAbierto = false;
            }
            else
            {
                StoryMenuAbrir.Begin();
                menuAbierto = true;
            }
        }


    }
}