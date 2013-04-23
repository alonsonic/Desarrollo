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
using Windows.UI.Popups;

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

        private async void llenarComboCategoria()
        {
            ServicioProductoClient servicioProducto = new ServicioProductoClient();
            List<Categoria> listCategoria = await servicioProducto.BuscarTodasLasCategoriasAsync();
            comboCategoria.Items.Add("Todas");
            comboCategoria.SelectedIndex = 0;
            //hacer cilco con webservice
            for (int categoria = 0; categoria < listCategoria.Count(); categoria++)
            {
                comboCategoria.Items.Add(listCategoria.ElementAt(categoria).Nombre);
            }
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
            MessageDialog mensajeError = new MessageDialog("Su busqueda no retorno ningun resultado");
            ServicioProductoClient servicioProducto = new ServicioProductoClient();
            if (comboCategoria.SelectedIndex == 0)
                ListaProducto.ListaProductos = await servicioProducto.BusquedaProductoAsync(textBoxBusqueda.Text);
            else
                ListaProducto.ListaProductos = await servicioProducto.BusquedaProductoConCategoriaAsync(comboCategoria.SelectedItem.ToString(), textBoxBusqueda.Text);

            if (ListaProducto.ListaProductos == null)
            {
                mensajeError.ShowAsync();
            }
            else
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
