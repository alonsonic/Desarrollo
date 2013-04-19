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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace AeiCliente
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ListaCompraPage : Page
    {

        public ListaCompraPage()
        {
            this.InitializeComponent();
            cargarProductos();
        }

        private void cargarProductos()
        {
            if (ListaProducto.ListaProductos != null)
            {
                for (int indexProducto = 0 ; indexProducto < ListaProducto.ListaProductos.Count; indexProducto++)
                {
                    ItemCompra itemProducto = new ItemCompra(indexProducto,this);
                    listaItemProducto.Items.Add(itemProducto);
                }
            }
            
        }
       
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }

    }
}
