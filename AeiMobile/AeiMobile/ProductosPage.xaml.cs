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
        List<Producto> productos;
        public ProductosPage(List<Producto> productos)
        {
            InitializeComponent();
            this.productos = productos;
            cargarProductos();
        }

        private void cargarProductos()
        {

        }
    }
}