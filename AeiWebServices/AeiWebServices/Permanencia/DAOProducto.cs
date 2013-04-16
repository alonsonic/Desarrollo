using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeiWebServices.Permanencia
{
    interface DAOProducto
    {
        int updateCantidad(Producto producto, int cantidadVendida);
        List<Producto> consultarTodos();
        List<Producto> buscarPorNombre(String nombre);
        List<Producto> buscarPorCategoria(String categoria);
        List<Producto> buscarPorTag(List<Tag> tags, String categoria);
        int agregarCalificacion(Producto producto, Calificacion calificacion);
    }
}
