using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using AeiWebServices.Logica;

namespace AeiWebServices.Permanencia
{
    public class SqlServerUsuario : DAOUsuario
    {
        private SqlServerDireccion daoDireccion = new SqlServerDireccion();
        private SqlServerMetodoPago daoMetodoPago = new SqlServerMetodoPago();
        private SqlServerCompra daoCompra = new SqlServerCompra();

        public Usuario consultarUsuario(string mail, int codigoActivacion)
        {
            ConexionSqlServer conexion = new ConexionSqlServer();
            SqlDataReader tabla = conexion.consultar("select u.*, (SELECT CONVERT(VARCHAR(19), u.fecha_nac, 120)) as fechaNac, (SELECT CONVERT(VARCHAR(19), u.fecha_ing, 120)) as fechaIng from usuario AS u where mail='"+mail+"'");
            while (tabla!=null && tabla.Read())
            {
                List<Direccion> direccion =daoDireccion.ConsultarDireccion(int.Parse(tabla["ID"].ToString()));
                List<MetodoPago> metodoPago =daoMetodoPago.consultarAllMetodosPago(int.Parse(tabla["ID"].ToString()));
                Compra carrito = daoCompra.consultarCarrito(int.Parse(tabla["ID"].ToString()));
                List<Compra> compras = daoCompra.consultarHistorialCompras(int.Parse(tabla["ID"].ToString()));
                if (compras != null)
                {
                    for (int index = 0; index < compras.Count; index++)
                    {
                        compras[index].Productos = daoCompra.buscarDetalleCompra(compras[index].Id);
                    }
                }
                Usuario usuario = new Usuario(int.Parse(tabla["ID"].ToString()), tabla["NOMBRE"].ToString(), tabla["APELLIDO"].ToString(),
                    tabla["PASAPORTE"].ToString(), tabla["MAIL"].ToString(),
                    DateTime.ParseExact(tabla["FECHAING"].ToString(), "yyyy-MM-dd", null),
                    DateTime.ParseExact(tabla["FECHANAC"].ToString(), "yyyy-MM-dd", null), 
                    tabla["STATUS"].ToString(), carrito, compras, direccion, metodoPago, codigoActivacion);
                conexion.cerrarConexion();
                return usuario;
            }
            conexion.cerrarConexion();
            return null;
        }

        public Usuario consultarUsuario(string mail)
        {
            ConexionSqlServer conexion = new ConexionSqlServer();
            SqlDataReader tabla = conexion.consultar("select u.*, (SELECT CONVERT(VARCHAR(19), u.fecha_nac, 120)) as fechaNac, (SELECT CONVERT(VARCHAR(19), u.fecha_ing, 120)) as fechaIng from usuario AS u where mail='" + mail + "'");
            while (tabla!=null && tabla.Read())
            {
                List<Direccion> direccion = this.daoDireccion.ConsultarDireccion(int.Parse(tabla["ID"].ToString()));
                List<MetodoPago> metodoPago = this.daoMetodoPago.consultarAllMetodosPago(int.Parse(tabla["ID"].ToString()));
                Compra carrito = this.daoCompra.consultarCarrito(int.Parse(tabla["ID"].ToString()));
                List<Compra> compras = this.daoCompra.consultarHistorialCompras(int.Parse(tabla["ID"].ToString()));
                if (compras != null)
                {
                    for (int index = 0; index < compras.Count; index++)
                    {
                        compras[index].Productos =this.daoCompra.buscarDetalleCompra(compras[index].Id);
                    }
                }
                Usuario usuario = new Usuario(int.Parse(tabla["ID"].ToString()), tabla["NOMBRE"].ToString(), tabla["APELLIDO"].ToString(),
                    tabla["PASAPORTE"].ToString(), tabla["MAIL"].ToString(),
                    DateTime.ParseExact(tabla["FECHAING"].ToString(), "yyyy-MM-dd", null),
                    DateTime.ParseExact(tabla["FECHANAC"].ToString(), "yyyy-MM-dd", null),
                    tabla["STATUS"].ToString(), carrito, compras, direccion, metodoPago, int.Parse(tabla["CODIGOACTIVACION"].ToString()));
                conexion.cerrarConexion();
                return usuario;
            }
            conexion.cerrarConexion();
            return null;
        }

        public Usuario consultarUsuario(int id)
        {
            ConexionSqlServer conexion = new ConexionSqlServer();
            SqlDataReader tabla = conexion.consultar("select u.*, (SELECT CONVERT(VARCHAR(19), u.fecha_nac, 120)) as fechaNac, (SELECT CONVERT(VARCHAR(19), u.fecha_ing, 120)) as fechaIng from usuario AS u where id='" + id.ToString() + "'");
            while (tabla!=null && tabla.Read())
            {
                List<Direccion> direccion = this.daoDireccion.ConsultarDireccion(int.Parse(tabla["ID"].ToString()));
                List<MetodoPago> metodoPago = this.daoMetodoPago.consultarAllMetodosPago(int.Parse(tabla["ID"].ToString()));
                Compra carrito = this.daoCompra.consultarCarrito(int.Parse(tabla["ID"].ToString()));
                List<Compra> compras = this.daoCompra.consultarHistorialCompras(int.Parse(tabla["ID"].ToString()));
                if (compras != null)
                {
                    for (int index = 0; index < compras.Count; index++)
                    {
                        compras[index].Productos = this.daoCompra.buscarDetalleCompra(compras[index].Id);
                    }
                }
                Usuario usuario = new Usuario(int.Parse(tabla["ID"].ToString()), tabla["NOMBRE"].ToString(), tabla["APELLIDO"].ToString(),
                    tabla["PASAPORTE"].ToString(), tabla["MAIL"].ToString(),
                    DateTime.ParseExact(tabla["FECHAING"].ToString(), "yyyy-MM-dd", null),
                    DateTime.ParseExact(tabla["FECHANAC"].ToString(), "yyyy-MM-dd", null),
                    tabla["STATUS"].ToString(), carrito, compras, direccion, metodoPago, int.Parse(tabla["CODIGOACTIVACION"].ToString()));
                conexion.cerrarConexion();
                return usuario;
            }
            conexion.cerrarConexion();
            return null;
        }
        public int modificarUsuario(Usuario usuarioModificado, int idUsuario)
        {
            ConexionSqlServer conexion = new ConexionSqlServer();
            int respuesta= conexion.insertar("UPDATE USUARIO SET nombre='" + usuarioModificado.Nombre + "', apellido= '" + usuarioModificado.Apellido + "',  fecha_nac='" + usuarioModificado.FechaNacimiento.ToString() + "', fecha_ing= '" + usuarioModificado.FechaRegistro.ToString() + "', status= '"+usuarioModificado.Status+"', codigoActivacion= '"+usuarioModificado.CodigoActivacion+"' where id=" + idUsuario + ";");
            conexion.cerrarConexion();
            return respuesta;
        }

        public int agregarUsuario(Usuario usuario)
        {
            ConexionSqlServer conexion = new ConexionSqlServer();
            String fechaActual= DateTime.Now.ToString("yyyy-MM-dd");
            int respuesta = conexion.insertar("INSERT INTO Usuario (id, pasaporte, nombre, apellido, fecha_nac, mail, fecha_ing, status, codigoActivacion) VALUES (NEXT VALUE FOR SEQ_usuario,'" + usuario.Pasaporte + "','" + usuario.Nombre + "', '" + usuario.Apellido + "','" + usuario.FechaNacimiento.ToString("yyyy-MM-dd") + "','" + usuario.Email + "','" + fechaActual.ToString() + "','I',NEXT VALUE FOR seq_codigo_activacion);");
            conexion.cerrarConexion();
            return respuesta;
        }
    }
}