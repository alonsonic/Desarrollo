using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AeiCliente.ServicioAEI;

namespace AeiCliente
{
    public static class ListaProducto
    {

        private static List<Producto> listaProductos = null;
        private static string textoBusqueda = "";

        public static string TextoBusqueda
        {
            get { return ListaProducto.textoBusqueda; }
            set { ListaProducto.textoBusqueda = value; }
        }

        public static List<Producto> ListaProductos
        {
            get { return ListaProducto.listaProductos; }
            set { ListaProducto.listaProductos = value; }
        }

    }
}
