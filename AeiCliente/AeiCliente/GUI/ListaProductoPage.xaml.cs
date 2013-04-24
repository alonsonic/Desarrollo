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
using Windows.UI.Popups;


namespace AeiCliente
{

    public sealed partial class ListaProductoPage : Page
    {

        public ListaProductoPage()
        {
            this.InitializeComponent();
            cargarProductos();
            llenarComboCategoria();
        }
       
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            cargarProductos();
            llenarComboCategoria();

        }

        private async void llenarComboCategoria()
        {
            ServicioAEIClient servicioProducto = new ServicioAEIClient();
            List<Categoria> listCategoria = await servicioProducto.BuscarTodasLasCategoriasAsync();
            comboCategoria.Items.Add("Todas");
            comboCategoria.SelectedIndex = 0;

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
                for (int indexProducto = 0; indexProducto < ListaProducto.ListaProductos.Count; indexProducto++)
                {
                    ItemProducto itemProducto = new ItemProducto(indexProducto, this);
                    listaItemProducto.Items.Add(itemProducto);
                }
            }

            textBoxBusqueda.Text = ListaProducto.TextoBusqueda;
        }

        private async void botonLupa_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            MessageDialog mensajeError = new MessageDialog("Su búsqueda no retornó ningún resultado.");
            ServicioAEIClient servicioProducto = new ServicioAEIClient();
            if (comboCategoria.SelectedIndex == 0)
                ListaProducto.ListaProductos = await servicioProducto.BusquedaProductoAsync(textBoxBusqueda.Text);
            else
                ListaProducto.ListaProductos = await servicioProducto.BusquedaProductoConCategoriaAsync(comboCategoria.SelectedItem.ToString(), textBoxBusqueda.Text);

            if (ListaProducto.ListaProductos.Count() == 0)
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
