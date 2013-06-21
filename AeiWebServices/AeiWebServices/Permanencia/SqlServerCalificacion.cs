using AeiWebServices.Logica;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AeiWebServices.Permanencia
{
    public class SqlServerCalificacion : DAOCalificacion
    {
        private SqlServerUsuario daoUsuario = new SqlServerUsuario();

        public int agregarCalificacion(Calificacion calificacion, int idUsuario, int idProducto)
        {
            if (calificacion == null)
                return 0;
            ConexionSqlServer conexion = new ConexionSqlServer();
            int respuesta = conexion.insertar("INSERT INTO calificacion (id, puntaje, detalle,  fk_usuario,fk_producto, fecha) VALUES(NEXT VALUE FOR SEQ_CALIFICACION," + calificacion.Puntaje.ToString() + ",'" + calificacion.Comentario + "'," + idUsuario.ToString() + "," + idProducto.ToString() + ",'" + DateTime.Now.ToString("yyyy-MM-dd") + "'); ");
            conexion.cerrarConexion();
            return respuesta;
        }

        public List<Calificacion> consultarCalificacionesPorProducto(int idProducto)
        {
            ConexionSqlServer conexion = new ConexionSqlServer();
            SqlDataReader tabla = conexion.consultar("SELECT c.*, (SELECT CONVERT(VARCHAR(19), c.fecha, 120)) as fechacali FROM CALIFICACION AS c WHERE fk_producto=" + idProducto.ToString() + ";");
            List<Calificacion> listaresultado = new List<Calificacion>();
            Usuario usuario = new Usuario();
            while (tabla != null && tabla.Read())
            {
                usuario = daoUsuario.consultarUsuario(int.Parse(tabla["FK_USUARIO"].ToString()));
                listaresultado.Add(new Calificacion(int.Parse(tabla["ID"].ToString()), int.Parse(tabla["PUNTAJE"].ToString()), tabla["DETALLE"].ToString(), DateTime.ParseExact(tabla["FECHACALI"].ToString(), "yyyy-MM-dd", null), usuario));
            }
            conexion.cerrarConexion();
            return listaresultado;
        }
    
    }
}