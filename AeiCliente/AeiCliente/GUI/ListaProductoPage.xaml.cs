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
using AeiCliente.ServicioProducto;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace AeiCliente
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ListaProductoPage : Page
    {

        public ListaProductoPage()
        {
            this.InitializeComponent();
            cargarProductos();
            llenarComboCategoria();
        }

        private void llenarComboCategoria()
        {
            comboCategoria.Items.Add("Todas");
            comboCategoria.SelectedIndex = 1;
            //hacer cilco con webservice
            comboCategoria.Items.Add("Bloques");
            comboCategoria.Items.Add("Vehiculos");
            comboCategoria.Items.Add("Muñecas");
            comboCategoria.Items.Add("Juegos de Mesa");
        }



        private void cargarProductos()
        {
            listaItemProducto.Items.Clear();
            if (ListaProducto.ListaProductos != null)
            {
                for (int indexProducto = 0 ; indexProducto < ListaProducto.ListaProductos.Count; indexProducto++)
                {
                    ItemProducto itemProducto = new ItemProducto(indexProducto,this);
                    listaItemProducto.Items.Add(itemProducto);
                }
            }
            
            textBoxBusqueda.Text = ListaProducto.TextoBusqueda;
        }
       
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }

        private async void botonLupa_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ServicioProductoClient servicioProducto = new ServicioProductoClient();
            ListaProducto.ListaProductos = await servicioProducto.BusquedaProductoAsync(comboCategoria.SelectedItem.ToString(), textBoxBusqueda.Text);
            cargarProductos();
        }

        private void botonPerfil_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
        	// TODO: Agregar implementación de controlador de eventos aquí.
        }

        private void botonCarrito_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
        	// TODO: Agregar implementación de controlador de eventos aquí.
        }

    }
}
