using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AeiWebServices.Logica
{
    [ServiceContract]
    public interface IServicioDireccion
    {
        [OperationContract]
        List<Direccion> consultarEstados();

        [OperationContract]
        List<Direccion> consultarCiudad(int idEstado);

        [OperationContract]
        int agregarDireccionUsuario(int idUsuario, int idDireccion, string descripcion, int codigoPostal);

    }
}
