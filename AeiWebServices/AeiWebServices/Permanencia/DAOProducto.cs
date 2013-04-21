using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeiWebServices.Permanencia
{
    interface DAOProducto
    {
        int updateCantidad(int idProducto, int cantidadEnExistencia);
        List<Producto> consultarProductos();
        List<Producto> buscarPorNombre(String nombre);
        List<Producto> buscarPorNombre(String nombre, String categoria);
        List<Producto> buscarPorCategoria(String nombreCategoria);
        List<Producto> buscarPorTag(String nombreTag);
        List<Producto> buscarPorTag(String nombreTag, String categoria);
        Producto buscarPorCompra(int idCompra);
        int agregarCalificacion(int idProducto, Calificacion calificacion);
    }
}
