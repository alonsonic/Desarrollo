using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using AeiWebServices.Permanencia;

namespace AeiWebServices
{
    public class ConexionSqlServer
    {
        SqlConnection miConexion = new SqlConnection(@"Data Source=LYANA-PC\SQLEXPRESS; Initial Catalog = AEIBD; Integrated Security=True;");


        public SqlConnection abrirConexion()
        {
            try
            {
                miConexion.Open();
                return miConexion;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Log.LogInstanciar().Fatal("No se pudo conectar la Base de Datos");
                Console.WriteLine("error"); 
                return null;
            }

        }
        public SqlConnection cerrarConexion()
        {
            try
            {
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
            Log.LogInstanciar().Debug("Iniciando conexion para consulta en la base de datos");
            SqlConnection miConexion = abrirConexion();
            if (miConexion != null)
            {
                try
                {
                    SqlCommand comando = new SqlCommand(query, miConexion);
                    comando.CommandType = CommandType.Text;
                    SqlDataReader tabla = null;
                    tabla = comando.ExecuteReader();
                    return tabla;

                }
                catch
                {
                    Console.Write("error");
                    Log.LogInstanciar().Error("Comando de base de Datos incorrecto");
                }
                miConexion.Close();
                Log.LogInstanciar().Debug("Cerrando conexion en la base de datos");
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