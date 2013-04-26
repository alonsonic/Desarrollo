using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;

namespace AeiWebServices.Permanencia
{
    public class SqlServerTag: DAOTag
    {
        public List<Tag> buscarTagPorProducto(int idproducto)
        {
            ConexionSqlServer conexion = new ConexionSqlServer();
            SqlDataReader tabla = conexion.consultar("select t.* from tag t, detalle_tag dt, producto p where t.id = dt.pk_tag AND p.id = dt.pk_producto and p.id ="+idproducto.ToString()+";");
            List<Tag> listaresultado = new List<Tag>();
            while (tabla!=null && tabla.Read())
            {
                listaresultado.Add(new Tag(int.Parse(tabla["ID"].ToString()), tabla["NOMBRE"].ToString()));

            }
            conexion.cerrarConexion();
            return listaresultado;
        }
    }
}