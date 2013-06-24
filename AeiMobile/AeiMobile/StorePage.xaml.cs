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
        bool menuAbierto = false;
        public StorePage()
        {
            InitializeComponent();
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

        private void buttonDeporte_Click(object sender, RoutedEventArgs e)
        {
            ServicioAEIClient servicio = new ServicioAEIClient();
            List<Producto> resultado;
            //Llamamos el metodo del servicio
            servicio.BusquedaProductoConCategoriaAsync("deportes",this.textBuscador.Text);

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

        private void buttonMuñeca_Click(object sender, RoutedEventArgs e)
        {
            ServicioAEIClient servicio = new ServicioAEIClient();
            List<Producto> resultado;
            //Llamamos el metodo del servicio
            servicio.BusquedaProductoConCategoriaAsync("muñecas", this.textBuscador.Text);

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

        private void buttonJuegosMesa_Click(object sender, RoutedEventArgs e)
        {
            ServicioAEIClient servicio = new ServicioAEIClient();
            List<Producto> resultado;
            //Llamamos el metodo del servicio
            servicio.BusquedaProductoConCategoriaAsync("juegos de mesa", this.textBuscador.Text);

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

        private void buttonBloque_Click(object sender, RoutedEventArgs e)
        {
            ServicioAEIClient servicio = new ServicioAEIClient();
            List<Producto> resultado;
            //Llamamos el metodo del servicio
            servicio.BusquedaProductoConCategoriaAsync("bloques", this.textBuscador.Text);

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

        private void buttonFiguraAccion_Click(object sender, RoutedEventArgs e)
        {
            ServicioAEIClient servicio = new ServicioAEIClient();
            List<Producto> resultado;
            //Llamamos el metodo del servicio
            servicio.BusquedaProductoConCategoriaAsync("figuras de acción", this.textBuscador.Text);

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

        private void buttonNina_Click(object sender, RoutedEventArgs e)
        {
            ServicioAEIClient servicio = new ServicioAEIClient();
            List<Producto> resultado;
            //Llamamos el metodo del servicio
            servicio.BusquedaProductoConCategoriaAsync("juguetes para niñas", this.textBuscador.Text);

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

        private void buttonInfantil_Click(object sender, RoutedEventArgs e)
        {
            ServicioAEIClient servicio = new ServicioAEIClient();
            List<Producto> resultado;
            //Llamamos el metodo del servicio
            servicio.BusquedaProductoConCategoriaAsync("Juguetes Infantiles", this.textBuscador.Text);

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

        private void buttonAprendizaje_Click(object sender, RoutedEventArgs e)
        {
            ServicioAEIClient servicio = new ServicioAEIClient();
            List<Producto> resultado;
            //Llamamos el metodo del servicio
            servicio.BusquedaProductoConCategoriaAsync("aprendizaje", this.textBuscador.Text);

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

        private void buttonVideoJuego_Click(object sender, RoutedEventArgs e)
        {
            ServicioAEIClient servicio = new ServicioAEIClient();
            List<Producto> resultado;
            //Llamamos el metodo del servicio
            servicio.BusquedaProductoConCategoriaAsync("video juegos", this.textBuscador.Text);

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
    }
}