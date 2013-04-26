using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace AeiWebServices
{
    public static class ConexionSqlServer
    {

        private  static SqlConnection miConexion=new SqlConnection(@"Data Source=LYANA-PC\SQLEXPRESS; Initial Catalog = AeiBD; Integrated Security=True;");

        private static SqlConnection abrirConexion()
        {
            try
            {
                miConexion.Open();
                return miConexion;
            }
            catch 
            {
                Console.Write("error");
                return null;
            }

        }

        public static void cerrarConexion()
        {
            if (miConexion!=null)
                miConexion.Close();
        }
      
        public static SqlDataReader consultar(string query)
        {
            if (miConexion.State.ToString() == "Closed")
                abrirConexion();           
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
            return null;
        }

        public static int insertar(string query)
        {  
            if (miConexion != null) 
                abrirConexion();
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
            return 0;
        }

       
    }
}