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
    public partial class ProductosPage : PhoneApplicationPage
    {
        private bool menuAbierto = false;
        public static List<Producto> productos;
        public static String busqueda;
        public static int origen; //1 con categoria, 0 sin categoria
        private List<String> listaString= new List<string>();
        int pagina=1;
        double totalPaginas=0.0;

        public ProductosPage()
        {
            InitializeComponent();
            this.textoError.Visibility = Visibility.Collapsed;
            calcularPaginas();
            cargarProductos();
            Menu.Children.Add(new MenuControl());
        }
        private void calcularPaginas()
        {
            //Declaramos el servicio
            ServicioAEIClient servicio = new ServicioAEIClient();
            //Llamamos el metodo del servicio
            servicio.calcularPaginaPorBusquedaAsync(busqueda, 5);

            //Cuando se complete la llamada se disparara el evento
            servicio.calcularPaginaPorBusquedaCompleted += (s, a) =>
            {
                totalPaginas = a.Result;
                if (totalPaginas == 0.0) totalPaginas = 1.0;
            };
        }

        private void cambiarPagina(int operacion)
        {
            //Declaramos el servicio
            ServicioAEIClient servicio = new ServicioAEIClient();
            List<Producto> resultado;
            //Llamamos el metodo del servicio
            if (operacion == 1)
                servicio.BusquedaProductoAsync(busqueda, pagina-1, 5);
            else
                servicio.BusquedaProductoAsync(busqueda, pagina+1, 5);          
            

            //Cuando se complete la llamada se disparara el evento
            servicio.BusquedaProductoCompleted += (s, a) =>
            {
                resultado = a.Result;
                try
                {
                    if (productos[0].Id != resultado[0].Id)
                    {
                        productos = resultado;
                        if (operacion == 1) pagina--;
                        else pagina++;
                        this.textNumeroPagina.Text = pagina + "";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                cargarProductos();
            };
        }
        private void cargarProductos()
        {
            this.listBoxProductos.Items.Clear();
            if (productos != null)
            {
                for (int indexProducto = 0; indexProducto < productos.Count; indexProducto++)
                {
                    ItemProducto itemProducto = new ItemProducto(productos[indexProducto]);
                    listBoxProductos.Items.Add(itemProducto);
                }
            }
            else
            {
                this.textoError.Visibility = Visibility.Visible;
            }
        }

        private void buttonPagAnterior_Click(object sender, RoutedEventArgs e)
        {
            if (pagina != 1 && origen==0)
            {
                cambiarPagina(1);
            }
        }

        private void buttonPagSiguiente_Click(object sender, RoutedEventArgs e)
        {
            if (origen==0 && totalPaginas<pagina)
                cambiarPagina(2);  
        }

        private void nombreProducto_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            ArticuloPivotPage.producto = productos[this.listBoxProductos.SelectedIndex];
            NavigationService.Navigate(new Uri("/ArticuloPivotPage.xaml", UriKind.Relative));            
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