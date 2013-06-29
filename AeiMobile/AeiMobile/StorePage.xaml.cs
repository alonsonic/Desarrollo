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
    public partial class StorePage : PhoneApplicationPage
    {
        private bool menuAbierto = false;
        public StorePage()
        {
            InitializeComponent();
            this.textBuscador.Text = "";
            Menu.Children.Add(new MenuControl());
        }

        private void prueba_Click(object sender, System.Windows.RoutedEventArgs e)
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

        private void buttonBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(this.textBuscador.Text)==false)
            {
                //Declaramos el servicio
                ServicioAEIClient servicio = new ServicioAEIClient();
                List<Producto> resultado;
                //Llamamos el metodo del servicio
                servicio.BusquedaProductoAsync(this.textBuscador.Text, 1, 5);

                //Cuando se complete la llamada se disparara el evento
                servicio.BusquedaProductoCompleted += (s, a) =>
                {
                    resultado = a.Result;
                    try
                    {
                        ProductosPage.busqueda = this.textBuscador.Text;
                        ProductosPage.productos = resultado;
                        ProductosPage.origen = 0;
                        NavigationService.Navigate(new Uri("/ProductosPage.xaml", UriKind.Relative));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                };
                
            }

        }
        private void busqueda_categoria(string calificacion)
        {
            ServicioAEIClient servicio = new ServicioAEIClient();
            List<Producto> resultado;
            //Llamamos el metodo del servicio
            servicio.BusquedaProductoConCategoriaAsync(calificacion, this.textBuscador.Text);

            //Cuando se complete la llamada se disparara el evento
            servicio.BusquedaProductoConCategoriaCompleted += (s, a) =>
            {
                resultado = a.Result;
                try
                {
                    ProductosPage.busqueda = this.textBuscador.Text;
                    ProductosPage.productos = resultado;
                    ProductosPage.origen = 1;
                    NavigationService.Navigate(new Uri("/ProductosPage.xaml", UriKind.Relative));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            };
        }

        private void buttonDeporte_Click(object sender, RoutedEventArgs e)
        {
            busqueda_categoria("deportes");
        }

        private void buttonMuñeca_Click(object sender, RoutedEventArgs e)
        {
            busqueda_categoria("muñecas");
        }

        private void buttonJuegosMesa_Click(object sender, RoutedEventArgs e)
        {
            busqueda_categoria("juegos de mesa");
        }

        private void buttonBloque_Click(object sender, RoutedEventArgs e)
        {
            busqueda_categoria("bloques");

        }

        private void buttonFiguraAccion_Click(object sender, RoutedEventArgs e)
        {
            busqueda_categoria("figuras de");
        }

        private void buttonNina_Click(object sender, RoutedEventArgs e)
        {
            busqueda_categoria("juguetes para niñas");
        }

        private void buttonInfantil_Click(object sender, RoutedEventArgs e)
        {
            busqueda_categoria("Juguetes Infantiles");

        }

        private void buttonAprendizaje_Click(object sender, RoutedEventArgs e)
        {
            busqueda_categoria("aprendizaje");
        }

        private void buttonVideoJuego_Click(object sender, RoutedEventArgs e)
        {
            busqueda_categoria("video juegos");
        }

        private void buttonFiguraAccion_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}