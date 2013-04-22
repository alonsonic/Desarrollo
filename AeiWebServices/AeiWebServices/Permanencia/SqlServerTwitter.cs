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
            return conexion.insertar("INSERT INTO Twitter (ScreenName, idUsuario, OauthTokenSecret, OauthToken) VALUES ('"+usuario.ScreenName+"','"+usuario.IdUsuario+"','"+usuario.OauthTokenSecret+"','"+usuario.OauthToken+"');");
        }

        public Twitter buscarUsuario(string screenName)
        {
            SqlDataReader tabla = conexion.consultar("select * from Twitter where ScreenName= '"+screenName+"';");
            Twitter twitter = new Twitter();
            while (tabla.Read())
            {
                twitter = new Twitter(tabla["IDUSUARIO"].ToString(), tabla["SCREENNAME"].ToString(), tabla["OauthTokenSecret"].ToString(), tabla["OauthToken"].ToString());
            }
            return twitter;
        }
    }
}