﻿using System;
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

namespace AeiMobile
{
    public partial class ArticuloPivotPage : PhoneApplicationPage
    {
        private Producto producto;

        public ArticuloPivotPage(Producto producto)
        {
            InitializeComponent();
            this.producto = producto;
            cargarInformacionProducto();
        }

        private void cargarInformacionProducto()
        {
            this.textPrecio.Text = producto.Precio.ToString() + " Bs";
            this.textCantidad.Text = "Cantidad: " + producto.Cantidad.ToString();
            this.textDescripcion.Text = producto.Descripcion;
            cargarListaCalifiacion();
        }

        private void cargarListaCalifiacion()
        {
            if(producto.Calificaciones.Count > 0)
            {
                for (int i = 0; i < producto.Calificaciones.Count; i++)
                {
                    this.listCalificacion.Items.Add(producto.Calificaciones[i].Usuario.Nombre + " " + producto.Calificaciones[i].Usuario.Apellido + ". \n Fecha: "+producto.Calificaciones[i].Fecha.ToString("dd-MM-yyyy")+
                            ".  Puntaje: " +producto.Calificaciones[i].Puntaje+ " estrella(s). \n Comentario: " + producto.Calificaciones[i].Comentario);
                }
            }
            else
            {
               this.listCalificacion.Items.Add("\n \n Aun no tenemos calificaciones para este producto.");
            }
            
        }
    }
}