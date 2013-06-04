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
        SqlConnection miConexion = new SqlConnection(@"Data Source=alonso-laptop; Initial Catalog = AeiBD;  User Id=admin; Password=admin;");



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