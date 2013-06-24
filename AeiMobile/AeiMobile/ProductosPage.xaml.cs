using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using AeiMobile.AeiServicio;


namespace AeiMobile
{
    public partial class ProductosPage : PhoneApplicationPage
    {
        public List<Producto> productos;

        public ProductosPage(List<Producto> productos)
        {
            InitializeComponent();
            this.productos = productos;
            cargarProductos();
        }

        private void cargarProductos()
        {
            List<string> p= new List<string>();
            //this.ListaProductos = p;
        }
    }
}