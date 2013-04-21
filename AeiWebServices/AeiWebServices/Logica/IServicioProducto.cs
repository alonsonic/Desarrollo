using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AeiWebServices.Logica
{
    [ServiceContract]
    public interface IServicioProducto
    {
        [OperationContract]
        List<Producto> BuscarProductoPorCategoria(string nombre);

        [OperationContract]
        List<Producto> BusquedaProductoConCategoria(string categoriaProducto, string busqueda);

        [OperationContract]
        List<Producto> BusquedaProducto(string busqueda);

        [OperationContract]
        List<Categoria> BuscarTodasLasCategorias();

    }
}
