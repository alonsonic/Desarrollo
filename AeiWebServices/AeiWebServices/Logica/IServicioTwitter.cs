using AeiWebServices.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AeiWebServices.Logica
{
    [ServiceContract]
    public interface IServicioTwitter
    {
        [OperationContract]
        Twitter getTwitter(string screenName);

        [OperationContract]
        int agregarTwitter(string idUsuario, string screenName, string OauthToken, string OauthTokenSecret);
    }
}
