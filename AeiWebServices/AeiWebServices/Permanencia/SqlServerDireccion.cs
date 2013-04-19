﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;

namespace AeiWebServices.Permanencia
{
    public class SqlServerDireccion: DAODireccion
    {
        private ConexionSqlServer conexion = new ConexionSqlServer();

        public int AgregarDireccionUsuario(int idUsuario, int idDireccion, Direccion direccion)
        {
            return conexion.insertar("INSERT INTO Detalle_Direccion (id,descripcion,codigo_postal,status,fk_direccion, fk_usuario)  VALUES (NEXT VALUE FOR seq_detalle_direccion, '" + direccion.Descripcion + "'," + direccion.CodigoPostal.ToString() + ",'" + direccion.Status + "'," + idDireccion.ToString() + "," + idUsuario.ToString() + ");");
        }

        public List<Direccion> ConsultarDireccion(int idUsuario)
        {
            SqlDataReader tabla = conexion.consultar("select c.id AS id, p.nombre AS pais, e.nombre AS estado, c.nombre AS ciudad, dd.codigo_postal AS codigo_postal, dd.descripcion AS descripcion, dd.status AS status from detalle_direccion dd, direccion c, direccion e, direccion p where p.id=e.fk_id AND e.id=c.fk_id AND c.id=dd.fk_direccion AND dd.fk_usuario=" + idUsuario.ToString() + ";");
            List<Direccion> lista = new List<Direccion>();
            while (tabla.Read())
            {
                lista.Add(new Direccion(int.Parse(tabla["ID"].ToString()), tabla["PAIS"].ToString(), tabla["ESTADO"].ToString(), tabla["CIUDAD"].ToString(), int.Parse(tabla["CODIGO_POSTAL"].ToString()), tabla["DESCRIPCION"].ToString(), tabla["STATUS"].ToString()));
            }
            return lista;
        }

        public Direccion ConsultarDireccionDeCompra(int idCompra)
        {
            Direccion resultado = null;
            SqlDataReader tabla = conexion.consultar("select c.id AS id, p.nombre AS pais, e.nombre AS estado, c.nombre AS ciudad, dd.codigo_postal AS codigo_postal, dd.descripcion AS descripcion, dd.status AS status, cp.id AS idcompra from detalle_direccion dd, direccion c, direccion e, direccion p, COMPRA cp where p.id=e.fk_id AND e.id=c.fk_id AND c.id=dd.fk_direccion AND cp.ID=" + idCompra.ToString() + ";");
            while (tabla.Read())
            {
                resultado = new Direccion(int.Parse(tabla["ID"].ToString()), tabla["PAIS"].ToString(), tabla["ESTADO"].ToString(), tabla["CIUDAD"].ToString(), int.Parse(tabla["CODIGO_POSTAL"].ToString()), tabla["DESCRIPCION"].ToString(), tabla["STATUS"].ToString());
            }
            return resultado;
        }

        public int modificarDireccion(int idDireccion, Direccion direccionModificada)
        {
            return 0;
        }
    }
}