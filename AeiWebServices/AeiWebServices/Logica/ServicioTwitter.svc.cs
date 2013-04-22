using AeiWebServices.Dominio;
using AeiWebServices.Permanencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AeiWebServices.Logica
{
    
    public class ServicioTwitter : IServicioTwitter
    {
        public Twitter getTwitter (string screenName) 
        {
            return FabricaDAO.getUsuarioTwitter(screenName);
        }

        public int agregarTwitter(string idUsuario, string screenName, string OauthToken,string OauthTokenSecret)
        {
            Twitter nuevoUsuario= new Twitter(idUsuario,screenName,OauthToken,OauthTokenSecret);
            return FabricaDAO.setAgregarTwitter(nuevoUsuario);
        }

    }
}
