using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AeiWebServices.Logica
{
    [ServiceContract]
    public interface IServicioUsuario
    {
        [OperationContract]
        Usuario ConsultarUsuario(string mail);

        [OperationContract]
        Usuario agregarUsuario(string nombre, string apellido, string pasaporte, string mail, string fechaNacimiento);

     }
}
