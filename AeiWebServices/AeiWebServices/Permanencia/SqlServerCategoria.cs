﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;

namespace AeiWebServices.Permanencia
{
    public class SqlServerCategoria: DAOCategoria
    {
        public List<Categoria> categorias()
        {    
            SqlDataReader tabla= ConexionSqlServer.consultar("select * from categoria;");
            List<Categoria> listaresultado= new List<Categoria>();
            while (tabla!=null && tabla.Read()) 
            {
                listaresultado.Add(new Categoria(int.Parse(tabla["ID"].ToString()),tabla["NOMBRE"].ToString()));
               
            }
            ConexionSqlServer.cerrarConexion();
            return listaresultado;
        }

        public Categoria buscarCategoriaPorProducto(int idProducto)
        {          
            SqlDataReader tabla = ConexionSqlServer.consultar("select * from categoria c, producto p where p.fk_categoria = c.id AND p.id = "+idProducto+";");
            
            while (tabla!=null && tabla.Read())
            {
                Categoria resultado = new Categoria(int.Parse(tabla["ID"].ToString()), tabla["NOMBRE"].ToString());
                ConexionSqlServer.cerrarConexion();
                return resultado;
            }
            ConexionSqlServer.cerrarConexion();
            return null;
        }

    
    }
}