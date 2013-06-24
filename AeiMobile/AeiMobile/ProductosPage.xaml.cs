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
        private List<String> listaString= new List<string>();

        public ProductosPage(List<Producto> productos)
        {
            InitializeComponent();
            this.productos = productos;
            cargarProductos();
        }

        private void cargarProductos()
        {
            foreach (var producto in productos)
            {
                this.listaString.Add(producto.Nombre);                   
            }
        }
        
    }
}