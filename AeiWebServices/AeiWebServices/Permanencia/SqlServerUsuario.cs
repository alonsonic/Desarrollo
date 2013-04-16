using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace AeiWebServices.Permanencia
{
    public class SqlServerUsuario : DAOUsuario, DAODireccion, DAOMetodoPago, DAOCompra, DAODetalleCompra//, DAOProducto
    {
        private ConexionSqlServer conexion = new ConexionSqlServer();

        public Compra consultarCarrito(int idUsuario) 
        {
           // SqlDataReader tabla= conexion.consultar("select * from compra where fk_usuario="+idUsuario.ToString()+"and estado='C'"+");");
            return null;
        }

        public List<Compra> consultarHistorialCompras(int idUsuario)
        {
            return null;
        }

        public int agregarCompra(Compra compra)
        {
            return conexion.insertar("INSERT INTO Compra (id,monto_total, fecha_solicitud, fecha_entrega, estado,fk_metodopago,fk_det_direccion) VALUES (NEXT VALUE FOR seq_compra," + compra.MontoTotal.ToString() + ",'" + compra.FechaSolicitud.ToString("yyyy-MM-dd") + "','" + compra.FechaEntrega.ToString("yyyy-MM-dd") + "','" + compra.Status + "'," + compra.Pago.ToString() + "," + compra.Direccion.Id.ToString()+");");
        }

        public int modificarEstadoDeCompra(String Status, int idCompra)
        {
            return conexion.insertar("UPDATE COMPRA SET ESTADO='" + Status + "' WHERE ID=" + idCompra.ToString() + ";");
        }

        public int agregarMetodoPago(MetodoPago metodo, int idUsuario)
        {
            return conexion.insertar("INSERT INTO Metodo_Pago (id, numero,marca,fecha_vencimiento,fk_usuario) VALUES (NEXT VALUE FOR seq_metodo_pago," + metodo.Numero.ToString() + ",'" + metodo.Marca + "','" + metodo.FechaVencimiento.ToString("yyyy-MM-dd") + "'," + idUsuario);
        }

        public List<MetodoPago> consultarAllMetodosPago(int idUsuario)
        {
            SqlDataReader tabla = conexion.consultar("select * from Metodo_Pago where fk_usuario=" + idUsuario.ToString() + ";");
            List<MetodoPago> lista = new List<MetodoPago>();
            while (tabla.Read())
            {
                lista.Add(new MetodoPago(int.Parse(tabla["ID"].ToString()), int.Parse(tabla["NUMERO"].ToString()), DateTime.ParseExact(tabla["FECHAVENCIMIENTO"].ToString(), "yyyy-MM-dd", null), tabla["MARCA"].ToString()));
            }
            return lista;
        }

        public int modificarMetodoPago(MetodoPago metodoModificado, int idMetodoActual, int idUsuario) 
        {
            return conexion.insertar("UPDATE METODO_PAGO SET numero=" + metodoModificado.Numero.ToString() + ",marca='" + metodoModificado.Marca + "',fecha_vencimiento='" + metodoModificado.FechaVencimiento.ToString() + " where id=" + idMetodoActual.ToString() + " and fk_usuario=" + idUsuario.ToString() + "");
        }

        public int AgregarDireccionUsuario(int idUsuario, int idDireccion, Direccion direccion)
        {
            return conexion.insertar("INSERT INTO Detalle_Direccion (id,descripcion,codigo_postal,status,fk_direccion, fk_usuario)  VALUES (NEXT VALUE FOR seq_detalle_direccion, '"+direccion.Descripcion+"',"+direccion.CodigoPostal.ToString()+",'"+direccion.Status+"',"+idDireccion.ToString()+","+idUsuario.ToString()+");");
        }

        public List<Direccion> ConsultarDireccion(int idUsuario)
        {
            SqlDataReader tabla = conexion.consultar("select c.id AS id, p.nombre AS pais, e.nombre AS estado, c.nombre AS ciudad, dd.codigo_postal AS codigo_postal, dd.descripcion AS descripcion, dd.status AS status from detalle_direccion dd, direccion c, direccion e, direccion p where p.id=e.fk_id AND e.id=c.fk_id AND c.id=dd.pk_direecion AND dd.pk_usuario=" + idUsuario.ToString() + ";");
            List<Direccion> lista = new List<Direccion>();
            while (tabla.Read())
            {
                lista.Add(new Direccion(int.Parse(tabla["ID"].ToString()), tabla["PAIS"].ToString(), tabla["ESTADO"].ToString(), tabla["CIUDAD"].ToString(), int.Parse(tabla["CODIGO_POSTAL"].ToString()), tabla["DESCRIPCION"].ToString(),tabla["STATUS"].ToString()));
            }
            return lista;
        }

        public int modificarDireccion(int idDireccion, Direccion direccionModificada)
        {

            return 0;
        }

        public Usuario consultarUsuario(string mail)
        {
            SqlDataReader tabla = conexion.consultar("select * from usuario where mail='" + mail + "';");
            while (tabla.Read())
            {
                Usuario usuario = new Usuario(int.Parse(tabla["ID"].ToString()), tabla["NOMBRE"].ToString(), tabla["APELLIDO"].ToString(), tabla["PASAPORTE"].ToString(), tabla["EMAIL"].ToString(), DateTime.ParseExact(tabla["FECHA_ING"].ToString(), "yyyy-MM-dd", null), DateTime.ParseExact(tabla["FECHA_NAC"].ToString(), "yyyy-MM-dd", null), tabla["STATUS"].ToString(), null, null, null, null);
                usuario.Direcciones = ConsultarDireccion(usuario.Id);
               // usuario.Carrito
            }
            return null;
        }


        public Boolean modificarUsuario(Usuario usuarioModificado, int id)
        {

            return false;
        }
    }
}