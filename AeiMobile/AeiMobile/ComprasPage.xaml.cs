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
    public partial class ComprasPage : PhoneApplicationPage
    {
        public static List<Producto> compras;

        public ComprasPage()
        {
            InitializeComponent();
            cargarProductos();
        }

        private void cargarProductos()
        {
            this.listBoxCompra.Items.Clear();
            foreach (var producto in compras)
            {
                listBoxCompra.Items.Add(producto.Nombre);
            }
        }
    }
}