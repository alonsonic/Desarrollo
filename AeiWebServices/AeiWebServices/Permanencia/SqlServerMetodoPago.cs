using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;

namespace AeiWebServices.Permanencia
{
    public class SqlServerMetodoPago: DAOMetodoPago
    {
        public int agregarMetodoPago(MetodoPago metodo, int idUsuario)
        {
            ConexionSqlServer conexion = new ConexionSqlServer(); 
            int respuesta= conexion.insertar("INSERT INTO Metodo_Pago (id, numero,marca,fecha_vencimiento,fk_usuario) VALUES (NEXT VALUE FOR seq_metodo_pago," + metodo.Numero.ToString() + ",'" + metodo.Marca + "','" + metodo.FechaVencimiento.ToString("yyyy-MM-dd") + "'," + idUsuario + ")");
            conexion.cerrarConexion();
            return respuesta;
        }

        public List<MetodoPago> consultarAllMetodosPago(int idUsuario)
        {
            ConexionSqlServer conexion = new ConexionSqlServer();
            SqlDataReader tabla = conexion.consultar("select m.*, (SELECT CONVERT(VARCHAR(19), m.fecha_vencimiento, 120)) as fecha from Metodo_Pago AS m where fk_usuario=" + idUsuario.ToString() + ";");
            List<MetodoPago> lista = new List<MetodoPago>();
            while (tabla!=null && tabla.Read())
            {
                lista.Add(new MetodoPago(int.Parse(tabla["ID"].ToString()), tabla["NUMERO"].ToString(), DateTime.ParseExact(tabla["FECHA"].ToString(), "yyyy-MM-dd", null), tabla["MARCA"].ToString()));
            }
            conexion.cerrarConexion();
            return lista;
        }

        public MetodoPago consultarMetodosPagoDeCompra(int idCompra)
        {
            ConexionSqlServer conexion = new ConexionSqlServer();
            MetodoPago resultado = null;
            SqlDataReader tabla = conexion.consultar("SELECT mp.* , (SELECT CONVERT(VARCHAR(19), mp.fecha_vencimiento, 120)) as fechaVenc FROM Metodo_Pago mp, COMPRA c WHERE c.fk_METODOPAGO = mp.ID AND C.ID =" + idCompra + "");
            while (tabla!=null && tabla.Read())
            {
                resultado = new MetodoPago(int.Parse(tabla["ID"].ToString()), tabla["NUMERO"].ToString(), DateTime.ParseExact(tabla["FECHAVENC"].ToString(), "yyyy-MM-dd", null), tabla["MARCA"].ToString());
            }
            conexion.cerrarConexion();
            return resultado;

        }

        public int modificarMetodoPago(MetodoPago metodoModificado, int idMetodoActual, int idUsuario)
        {
            ConexionSqlServer conexion = new ConexionSqlServer(); 
            int respuesta= conexion.insertar("UPDATE METODO_PAGO SET numero=" + metodoModificado.Numero.ToString() + ",marca='" + metodoModificado.Marca + "',fecha_vencimiento='" + metodoModificado.FechaVencimiento.ToString() + "' where id=" + idMetodoActual.ToString() + " and fk_usuario=" + idUsuario.ToString() + "");
            conexion.cerrarConexion();
            return respuesta;
        }
    }
}