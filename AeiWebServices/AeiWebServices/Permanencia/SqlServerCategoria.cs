using System;
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
            ConexionSqlServer conexion = new ConexionSqlServer();
            SqlDataReader tabla= conexion.consultar("select * from categoria;");
            List<Categoria> listaresultado= new List<Categoria>();
            while (tabla.Read()) 
            {
                listaresultado.Add(new Categoria(int.Parse(tabla["ID"].ToString()),tabla["NOMBRE"].ToString()));
               
            }
            return listaresultado;
        }
    }
}