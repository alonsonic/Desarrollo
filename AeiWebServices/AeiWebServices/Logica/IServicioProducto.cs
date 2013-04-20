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
    }
}
