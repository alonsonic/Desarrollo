using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeiWebServices.Permanencia
{
    interface DAOCompra
    {
        int agregarCompra(Compra compra, int idUsuario);
        int modificarEstadoDeCompra(String Status, int idCompra);
        Compra consultarCarrito(int idUsuario);
        List<Compra> consultarHistorialCompras(int idUsuario);
        List<Producto> busquedaProductos(string busqueda);
        List<Producto> busquedaProductos(string categoriaProducto, string busqueda);
    }
}
