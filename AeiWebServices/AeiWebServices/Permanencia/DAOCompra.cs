using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeiWebServices.Permanencia
{
    interface DAOCompra
    {
        int modificarMontoCarrito(Compra compra, float montoNuevo);
        int agregarCompra(Compra compra, int idUsuario);
        int modificarEstadoDeCompra(Compra compra);
        int modificarEstadoDeCompra(int idCompra);
        Compra consultarCarrito(int idUsuario);
        List<Compra> consultarHistorialCompras(int idUsuario);
        List<Producto> busquedaProductos(string busqueda);
        List<Producto> busquedaProductos(string categoriaProducto, string busqueda);
        int cambiarCantidadProducto(int idProducto, int cantidad);
    }
}
