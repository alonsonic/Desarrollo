using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AeiWebServices.Permanencia
{
    public class SqlServerCalificacion: DAOCalificacion
    {
        private ConexionSqlServer conexion = new ConexionSqlServer();
        public int agregarCalificacion(Calificacion calificacion, int idUsuario, int idProducto)
        {
            return conexion.insertar("INSERT INTO id, puntaje, comentario, usuario, fecha VALUES(NEXT VALUE FOR SEQ_CALIFICACION,"+calificacion.Puntaje.ToString()+",'"+calificacion.Comentario+"',"+idUsuario.ToString()+",'"+DateTime.Today.ToString("yyyy-MM-dd")+"'); "); 

        }

        public List<Calificacion> consultarCalificacionesPorProducto(int idProducto)
        {
            ConexionSqlServer conexion = new ConexionSqlServer();
            SqlDataReader tabla = conexion.consultar("SELECT * FROM CALIFICACION WHERE ID ="+idProducto.ToString()+";");
            List<Calificacion> listaresultado = new List<Calificacion>();
            while (tabla.Read())
            {         
                //listaresultado.Add(new Calificacion(int.Parse(tabla["ID"].ToString()), int.Parse(tabla["PUNTAJE"].ToString()), tabla[""] ));
                //                                     int id, int puntaje, string comentario, DateTime fecha, Usuario usuario
            }
            return listaresultado;

        }
    }
}