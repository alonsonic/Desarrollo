using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AeiWebServices.Dominio
{
    [DataContract]
    public class Twitter
    {
        private string screenName;
        private string oauthToken;
        private string idUsuario;
        private string oauthTokenSecret;

        [DataMember]
        public string ScreenName
        {
            get { return screenName; }
            set { screenName = value; }
        }

        [DataMember]
        public string IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }

        [DataMember]
        public string OauthTokenSecret
        {
            get { return oauthTokenSecret; }
            set { oauthTokenSecret = value; }
        }

        [DataMember]
        public string OauthToken
        {
            get { return oauthToken; }
            set { oauthToken = value; }
        }

        public Twitter()
        { }
        public Twitter(string idUsuario, string screenName, string oauthToken, string oauthTokenSecret)
        {
            this.screenName = screenName;
            this.oauthToken = oauthToken;
            this.oauthTokenSecret = oauthTokenSecret;
            this.idUsuario = idUsuario;
        }
        
    }
}