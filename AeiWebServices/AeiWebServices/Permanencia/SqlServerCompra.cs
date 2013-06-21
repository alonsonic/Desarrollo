using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using AeiWebServices.Logica;

namespace AeiWebServices.Permanencia
{
    public class SqlServerCompra: DAOCompra
    {
        private SqlServerProducto daoProducto = new SqlServerProducto();
        private SqlServerDireccion daoDireccion = new SqlServerDireccion();
        private SqlServerMetodoPago daoMetodoPago = new SqlServerMetodoPago();


        public int cambiarCantidadProducto(int idProducto, int cantidad)
        {
            ConexionSqlServer conexion = new ConexionSqlServer();
            SqlDataReader tabla = conexion.consultar("select p.cantidad from producto p where p.id="+idProducto.ToString()+";");
            List<Tag> listaTag = new List<Tag>();
            Producto producto = new Producto();
            while (tabla != null && tabla.Read())
            {
                producto.Cantidad=int.Parse(tabla["CANTIDAD"].ToString());
            }
            conexion.cerrarConexion();
            int respuesta = -1;
            int cant = producto.Cantidad-cantidad;
            if (cantidad<=producto.Cantidad) 
                 respuesta=conexion.insertar("UPDATE Producto SET cantidad="+ cant.ToString() +" WHERE ID="+idProducto+"");
            conexion.cerrarConexion();
            return respuesta;
        }

        public int modificarMontoCarrito(Compra compra, float montoNuevo)
        {
            ConexionSqlServer conexion = new ConexionSqlServer();
            int respuesta = conexion.insertar("UPDATE COMPRA SET monto_total= " + montoNuevo.ToString() + " WHERE ID=" + compra.Id.ToString() + ";");
            conexion.cerrarConexion();
            return respuesta;
        }

        public List<DetalleCompra> buscarDetalleCompra(int idCompra)
        {
            ConexionSqlServer conexion = new ConexionSqlServer();
            SqlDataReader tabla = conexion.consultar("SELECT dc.* FROM DETALLE_COMPRA dc where dc.FK_COMPRA=" + idCompra.ToString() + ";");
            List<DetalleCompra> resultado = new List<DetalleCompra>();
            while (tabla!=null && tabla.Read())
            { 
                Producto producto = daoProducto.buscarPorCompra(int.Parse(tabla["ID"].ToString()));
                resultado.Add(new DetalleCompra(int.Parse(tabla["ID"].ToString()),float.Parse(tabla["MONTO"].ToString()), int.Parse(tabla["CANTIDAD"].ToString()), producto));
            }
            conexion.cerrarConexion();
            return resultado;
        }

        public Compra consultarCarrito(int idUsuario)
        {
            ConexionSqlServer conexion = new ConexionSqlServer();
            SqlDataReader tabla = conexion.consultar("select c.*, (SELECT CONVERT(VARCHAR(19), c.fecha_solicitud, 120)) as fechaSol, (SELECT CONVERT(VARCHAR(19), c.fecha_entrega, 120)) as fechaEnt from compra AS c where c.fk_usuario=" + idUsuario + " and c.estado='C'");
            while (tabla!=null && tabla.Read())
            {
                List<DetalleCompra> listaDetalleCompra = buscarDetalleCompra(int.Parse(tabla["ID"].ToString()));
                Compra resultado = new Compra(int.Parse(tabla["ID"].ToString()), float.Parse(tabla["MONTO_TOTAL"].ToString()),
                    DateTime.ParseExact(tabla["FECHASOL"].ToString(), "yyyy-MM-dd", null), 
                    DateTime.ParseExact(tabla["FECHAENT"].ToString(), "yyyy-MM-dd", null), tabla["ESTADO"].ToString(), null, null, null);
                resultado.Productos = buscarDetalleCompra(resultado.Id);
                conexion.cerrarConexion();
                return resultado;
            } 
            conexion.cerrarConexion();
            return null;
        }

        public List<Compra> consultarHistorialCompras(int idUsuario)
        {
            ConexionSqlServer conexion = new ConexionSqlServer();
            SqlDataReader tabla = conexion.consultar("select c.*, (SELECT CONVERT(VARCHAR(19), c.fecha_solicitud, 120)) as fechaSol, (SELECT CONVERT(VARCHAR(19), c.fecha_entrega, 120)) as fechaEnt from compra AS c where fk_usuario=" + idUsuario + " and estado<>'C';");
            List<Compra> listaCompras = new List<Compra>();
            while (tabla!=null && tabla.Read())
            {
                List<DetalleCompra> listaDetalleCompra = buscarDetalleCompra(int.Parse(tabla["ID"].ToString()));
                Direccion direccion = daoDireccion.ConsultarDireccionDeCompra(int.Parse(tabla["ID"].ToString()));
                MetodoPago metodoPago = daoMetodoPago.consultarMetodosPagoDeCompra(int.Parse(tabla["ID"].ToString()));
                listaCompras.Add(new Compra(int.Parse(tabla["ID"].ToString()), float.Parse(tabla["MONTO_TOTAL"].ToString()),
                    DateTime.ParseExact(tabla["FECHASOL"].ToString(), "yyyy-MM-dd", null),
                    DateTime.ParseExact(tabla["FECHAENT"].ToString(), "yyyy-MM-dd", null), tabla["ESTADO"].ToString(), metodoPago,
                    listaDetalleCompra, direccion));
            }
            conexion.cerrarConexion();
            return listaCompras;
        }

        public int agregarCompra(Compra compra, int idUsuario)
        {
            ConexionSqlServer conexion = new ConexionSqlServer();
            int respuesta = 0;
            if (compra.Direccion == null && compra.Pago == null) respuesta= conexion.insertar("INSERT INTO Compra (id,monto_total, fecha_solicitud, fecha_entrega, estado,fk_metodopago,fk_det_direccion,fk_usuario) VALUES (NEXT VALUE FOR seq_compra," + compra.MontoTotal.ToString() + ",'" + compra.FechaSolicitud.ToString("yyyy-MM-dd") + "','" + compra.FechaEntrega.ToString("yyyy-MM-dd") + "','" + compra.Status + "',null,null," + idUsuario.ToString() + ");");
            else respuesta= conexion.insertar("INSERT INTO Compra (id,monto_total, fecha_solicitud, fecha_entrega, estado,fk_metodopago,fk_det_direccion,fk_usuario) VALUES (NEXT VALUE FOR seq_compra," + compra.MontoTotal.ToString() + ",'" + compra.FechaSolicitud.ToString("yyyy-MM-dd") + "','" + compra.FechaEntrega.ToString("yyyy-MM-dd") + "','" + compra.Status + "'," + compra.Pago.Id.ToString() + "," + compra.Direccion.Id.ToString() + ","+idUsuario.ToString()+");");
            conexion.cerrarConexion();
            return respuesta;
        }

        public int modificarEstadoDeCompra(Compra compra)
        {
            ConexionSqlServer conexion = new ConexionSqlServer();
            int respuesta = conexion.insertar("UPDATE COMPRA SET FECHA_SOLICITUD= '" + compra.FechaSolicitud.ToString("yyyy-MM-dd") + "' AND ESTADO= '" + compra.Status + "' AND FK_METODOPAGO " + compra.Pago.Id.ToString() + " AND FK_DET_DIRECCION= " + compra.Direccion.Id.ToString() + " WHERE ID=" + compra.Id.ToString() + ";");
            conexion.cerrarConexion();
            return respuesta;
        }

        public int modificarEstadoDeCompra(int idCompra)
        {
            ConexionSqlServer conexion = new ConexionSqlServer();
            int respuesta = conexion.insertar("UPDATE COMPRA SET ESTADO= 'E' WHERE ID=" + idCompra.ToString() + ";");
            conexion.cerrarConexion();
            return respuesta;
        }


    }
}