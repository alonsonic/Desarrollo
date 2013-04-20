using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using AeiWebServices.Permanencia;

namespace AeiWebServices.Logica
{
    public class ServiceUsuario : IServicioUsuario
    {

        public Usuario ConsultarUsuario(string mail)
        {
            return FabricaDAO.getUsuario(mail);
        }
    }
}
