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
        public static List<Producto> productos;
        public static String busqueda;
        public static int origen; //1 con categoria, 0 sin categoria
        private List<String> listaString= new List<string>();
        int pagina=1;

        public ProductosPage()
        {
            InitializeComponent();
            cargarProductos();
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
            foreach (var producto in productos)
            {
                listBoxProductos.Items.Add(producto.Nombre);
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
            if (origen==0)
                cambiarPagina(2);  
        }

        private void nombreProducto_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            ArticuloPivotPage.producto = productos[this.listBoxProductos.SelectedIndex];
            NavigationService.Navigate(new Uri("/ArticuloPivotPage.xaml", UriKind.Relative));
            
        }
        
    }
}