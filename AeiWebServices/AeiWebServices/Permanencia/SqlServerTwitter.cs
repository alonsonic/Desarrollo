﻿using AeiWebServices.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AeiWebServices.Permanencia
{
    public class SqlServerTwitter: DAOTwitter
    {

        public int agregarUsuario(Twitter usuario)
        {
            int respuesta= ConexionSqlServer.insertar("INSERT INTO Twitter (ScreenName, idUsuario, OauthTokenSecret, OauthToken) VALUES ('"+usuario.ScreenName+"','"+usuario.IdUsuario+"','"+usuario.OauthTokenSecret+"','"+usuario.OauthToken+"');");
            ConexionSqlServer.cerrarConexion();
            return respuesta;
        }

        public Twitter buscarUsuario(string screenName)
        {
            SqlDataReader tabla = ConexionSqlServer.consultar("select * from Twitter where ScreenName= '"+screenName+"';");
            Twitter twitter = new Twitter();
            while (tabla!=null && tabla.Read())
            {
                twitter = new Twitter(tabla["IDUSUARIO"].ToString(), tabla["SCREENNAME"].ToString(), tabla["OauthToken"].ToString(), tabla["OauthTokenSecret"].ToString());
            }
            ConexionSqlServer.cerrarConexion();
            return twitter;
        }
    }
}