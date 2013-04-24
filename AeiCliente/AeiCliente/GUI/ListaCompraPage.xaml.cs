using AeiCliente.ServicioAEI;
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

namespace AeiCliente
{

    public sealed partial class ListaCompraPage : Page
    {
        bool isCarrito = false;



        public ListaCompraPage()
        {
            this.InitializeComponent();
            cargarProductos();
        }
       
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            cargarProductos();
        }

        private void cargarProductos()
        {
            if (BufferUsuario.Usuario == null || BufferUsuario.Usuario.Carrito == null)
                return;

            for (int indexProducto = 0; indexProducto < BufferUsuario.Usuario.Carrito.Productos.Count; indexProducto++)
            {
                ItemCompra itemProducto = new ItemCompra(indexProducto, this, true);
                listaItemProducto.Items.Add(itemProducto);
            }

        }

    }

}
