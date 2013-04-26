using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace AeiWebServices
{
    public class ConexionSqlServer
    {
        public SqlConnection abrirConexion()
        {
            try
            {
                //creando la conexion
                SqlConnection miConexion = new SqlConnection(@"Data Source=LYANA-PC\SQLEXPRESS; Initial Catalog = AeiBD; Integrated Security=True;");
                //abriendo conexion
                miConexion.Open();
                return miConexion;
            }
            catch 
            {
                Console.Write("error");
                return null;
            }

        }
        public SqlConnection cerrarConexion()
        {
            try
            {
                //creando la conexion
                SqlConnection miConexion = new SqlConnection(@"Data Source=LYANA-PC\SQLEXPRESS; Initial Catalog = AeiBD; Integrated Security=True;");
                //abriendo conexion
                miConexion.Close();
                return miConexion;
            }
            catch
            {
                Console.Write("error");
                return null;
            }
        }
        public SqlDataReader consultar(string query)
        {
            SqlConnection miConexion = abrirConexion();
            if (miConexion != null)
            {
                try
                {
                    SqlCommand comando = new SqlCommand(query, miConexion);
                    comando.CommandType = CommandType.Text;
                    SqlDataReader tabla = null;
                    tabla = comando.ExecuteReader();
                   // miConexion.Close();
                    return tabla;

                }
                catch
                {
                    Console.Write("error");
                }
                miConexion.Close();
            }
            return null;
        }

        public int insertar(string query)
        {
            SqlConnection miConexion = abrirConexion();
            if (miConexion != null)
            {
                try
                {
                    SqlCommand comando = new SqlCommand(query, miConexion);
                    comando.CommandType = CommandType.Text;
                    SqlCommand commit = new SqlCommand("commit;", miConexion);
                    comando.CommandType = CommandType.Text;
                    return comando.ExecuteNonQuery();

                }
                catch
                {
                    Console.Write("error");
                }
                miConexion.Close();
            }
            return 0;
        }

       
    }
}