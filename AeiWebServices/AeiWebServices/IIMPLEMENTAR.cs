using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AeiWebServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IIMPLEMENTAR" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IIMPLEMENTAR
    {
        [OperationContract]
        List<Producto> buscarListaProducto(string busqueda);

        //[OperationContract]
        //Usuario getUsuario(string email);


    }
}
