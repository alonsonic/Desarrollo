using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AeiWebServices.Logica
{
    [ServiceContract]
    public interface IServicioBusqueda
    {
        [OperationContract]
        List<Producto> BusquedaProducto(string busqueda, int pagina, int numeroArticulo);
    }
}
