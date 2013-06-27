using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using AeiMobile.ServicioAEI;
using System.Windows.Media.Imaging;

namespace AeiMobile
{
    public partial class ArticuloPivotPage : PhoneApplicationPage
    {

        public static Producto producto;

        public ArticuloPivotPage()
        {
            InitializeComponent();

            ServicioAEIClient servicio = new ServicioAEIClient();
            servicio.BusquedaProductoAsync("fifa", 1, 1);
            servicio.BusquedaProductoCompleted += (s, a) =>
            {

                List<Producto> listaProducto = a.Result;
                producto = listaProducto.First();
                cargarInformacionProducto();

            };
            //cargarInformacionProducto();
        }

        
        private void cargarInformacionProducto()
        {
            this.textPrecio.Text = producto.Precio.ToString() + " Bs";
            this.textCantidad.Text = "Cantidad: " + producto.Cantidad.ToString();
            this.textDescripcion.Text = producto.Descripcion;
            this.Title = producto.Nombre;
            cargarListaCalifiacion();
            //setImagenProducto();
        }

        private void cargarListaCalifiacion()
        {
            if(producto.Calificaciones != null && producto.Calificaciones.Count > 0)
            {
                for (int i = 0; i < producto.Calificaciones.Count; i++)
                {
                    this.listCalificacion.Items.Add(producto.Calificaciones[i].Usuario.Nombre + " " + producto.Calificaciones[i].Usuario.Apellido + ". \n Fecha: "+producto.Calificaciones[i].Fecha.ToString("dd-MM-yyyy")+
                            ".  Puntaje: " +producto.Calificaciones[i].Puntaje+ " estrella(s). \n Comentario: " + producto.Calificaciones[i].Comentario);
                }
            }
            else
            {
                this.listCalificacion.Items.Add("Aun no tenemos calificaciones para este producto.");
            }
            
        }

        public void setImagenProducto()
        {
            BitmapImage newImage = new BitmapImage();
            newImage.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            newImage.UriSource = new Uri(producto.ImagenDetalle);
            this.imagenProducto.Source = newImage;
            imagenProducto.UpdateLayout();
        }
    }
    
}