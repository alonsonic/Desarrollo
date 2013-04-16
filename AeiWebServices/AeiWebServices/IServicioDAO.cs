using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AeiWebServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioDAO
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        int setCompra(Compra compra);

        [OperationContract]
        List<Categoria> getListaCategoria();
        // TODO: agregue aquí sus operaciones de servicio
    }
}
