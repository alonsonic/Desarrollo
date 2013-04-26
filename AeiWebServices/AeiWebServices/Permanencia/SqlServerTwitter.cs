using AeiWebServices.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AeiWebServices.Permanencia
{
    public class SqlServerTwitter: DAOTwitter
    {
        private ConexionSqlServer conexion = new ConexionSqlServer();

        public int agregarUsuario(Twitter usuario)
        {
<<<<<<< HEAD
            int respuesta= ConexionSqlServer.insertar("INSERT INTO Twitter (ScreenName, idUsuario, OauthTokenSecret, OauthToken) VALUES ('"+usuario.ScreenName+"','"+usuario.IdUsuario+"','"+usuario.OauthTokenSecret+"','"+usuario.OauthToken+"');");
             
            return respuesta;
=======
            return conexion.insertar("INSERT INTO Twitter (ScreenName, idUsuario, OauthTokenSecret, OauthToken) VALUES ('"+usuario.ScreenName+"','"+usuario.IdUsuario+"','"+usuario.OauthTokenSecret+"','"+usuario.OauthToken+"');");
>>>>>>> parent of 985a267... cambiando la conexion a estatica
        }

        public Twitter buscarUsuario(string screenName)
        {
            SqlDataReader tabla = conexion.consultar("select * from Twitter where ScreenName= '"+screenName+"';");
            Twitter twitter = new Twitter();
            while (tabla!=null && tabla.Read())
            {
                twitter = new Twitter(tabla["IDUSUARIO"].ToString(), tabla["SCREENNAME"].ToString(), tabla["OauthToken"].ToString(), tabla["OauthTokenSecret"].ToString());
            }
<<<<<<< HEAD
             
=======
>>>>>>> parent of 985a267... cambiando la conexion a estatica
            return twitter;
        }
    }
}