using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace AeiWebServices.Permanencia
{
    public class SqlServerDetalleCompra : DAODetalleCompra
    {
        private SqlServerCompra daoCompra = new SqlServerCompra();
        public DetalleCompra buscarEnMiCarrito(int idProducto, int idUsuario)
        {
            ConexionSqlServer conexion = new ConexionSqlServer();
            int respuesta = conexion.insertar("");
            SqlDataReader tabla = conexion.consultar("select dd.* from Detalle_Compra dd, Compra c where dd.fk_producto= " + idProducto.ToString() + " and c.fk_usuario= " + idUsuario + " and c.estado='C' and dd.fk_compra=c.id;");
            while (tabla != null && tabla.Read())
            {
                Producto producto = daoCompra.buscarPorCompra(int.Parse(tabla["ID"].ToString()));
                DetalleCompra resultado = new DetalleCompra(int.Parse(tabla["ID"].ToString()), float.Parse(tabla["MONTO"].ToString()), int.Parse(tabla["CANTIDAD"].ToString()), producto);
                conexion.cerrarConexion();
                return resultado;
            }
            conexion.cerrarConexion();
            return null;
        }
        public int cambiarCantidadProducto(DetalleCompra detalleCompra, int cantidad)
        {
            ConexionSqlServer conexion = new ConexionSqlServer();
            int respuesta = conexion.insertar("");
            conexion.cerrarConexion();
            return 0;
        }

        public int borrarDetalleCompra(Compra compra,DetalleCompra detalle)
        {
            ConexionSqlServer conexion = new ConexionSqlServer();
            int respuesta = conexion.insertar("DELETE INTO DETALLE_COMPRA WHERE ID=" + detalle.Id.ToString() + "");
            conexion.cerrarConexion();
            return respuesta;
        }
        public int agregarDetalleCompra(int idCompra, DetalleCompra detalleCompra)
        {
            ConexionSqlServer conexion = new ConexionSqlServer();
         //   if (compra.Direccion == null && compra.Pago == null) int respuesta= conexion.insertar("INSERT INTO Detalle_Compra (id,monto,cantidad,fk_compra,fk_producto) VALUES (NEXT VALUE FOR seq_detalle_compra," + detalleCompra.Monto.ToString() + "," + detalleCompra.Cantidad.ToString() + "," + idCompra.ToString() + "," + detalleCompra.Producto.Id.ToString() + ");");
            int respuesta = conexion.insertar("INSERT INTO Detalle_Compra (id,monto,cantidad,fk_compra,fk_producto) VALUES (NEXT VALUE FOR seq_detalle_compra," + detalleCompra.Monto.ToString() + "," + detalleCompra.Cantidad.ToString() + "," + idCompra.ToString() + "," + detalleCompra.Producto.Id.ToString() + ");");
            conexion.cerrarConexion();
            return respuesta;
        }
        
    }
}