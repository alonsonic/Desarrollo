using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace AeiWebServices.Permanencia
{
    public class SqlServerDetalleCompra : DAODetalleCompra, DAOTag, DAOCategoria, DAOMetodoPago
    {

        public int agregarDetalleCompra(int idCompra, DetalleCompra detalleCompra)
        {
         //   if (compra.Direccion == null && compra.Pago == null) int respuesta= ConexionSqlServer.insertar("INSERT INTO Detalle_Compra (id,monto,cantidad,fk_compra,fk_producto) VALUES (NEXT VALUE FOR seq_detalle_compra," + detalleCompra.Monto.ToString() + "," + detalleCompra.Cantidad.ToString() + "," + idCompra.ToString() + "," + detalleCompra.Producto.Id.ToString() + ");");
            int respuesta = ConexionSqlServer.insertar("INSERT INTO Detalle_Compra (id,monto,cantidad,fk_compra,fk_producto) VALUES (NEXT VALUE FOR seq_detalle_compra," + detalleCompra.Monto.ToString() + "," + detalleCompra.Cantidad.ToString() + "," + idCompra.ToString() + "," + detalleCompra.Producto.Id.ToString() + ");");
            ConexionSqlServer.cerrarConexion();
            return respuesta;
        }
        
        public int agregarMetodoPago(MetodoPago metodo, int idUsuario)
        {
            int respuesta = ConexionSqlServer.insertar("INSERT INTO Metodo_Pago (id, numero,marca,fecha_vencimiento,fk_usuario) VALUES (NEXT VALUE FOR seq_metodo_pago," + metodo.Numero.ToString() + ",'" + metodo.Marca + "','" + metodo.FechaVencimiento.ToString("yyyy-MM-dd") + "'," + idUsuario + ")");
            ConexionSqlServer.cerrarConexion();
            return respuesta;
        }

        public List<MetodoPago> consultarAllMetodosPago(int idUsuario)
        {
            SqlDataReader tabla = ConexionSqlServer.consultar("select m.*, (SELECT CONVERT(VARCHAR(19), m.fecha_vencimiento, 120)) as fecha from Metodo_Pago AS m where fk_usuario=" + idUsuario.ToString() + ";");
            List<MetodoPago> lista = new List<MetodoPago>();
            while (tabla!=null && tabla.Read())
            {
                lista.Add(new MetodoPago(int.Parse(tabla["ID"].ToString()), tabla["NUMERO"].ToString(), DateTime.ParseExact(tabla["FECHA"].ToString(), "yyyy-MM-dd", null), tabla["MARCA"].ToString()));
            }
            ConexionSqlServer.cerrarConexion();
            return lista;
        }

        public MetodoPago consultarMetodosPagoDeCompra(int idCompra)
        {
            MetodoPago resultado = null;
            SqlDataReader tabla = ConexionSqlServer.consultar("SELECT mp.* , (SELECT CONVERT(VARCHAR(19), mp.fecha_vencimiento, 120)) as fechaVenc FROM Metodo_Pago mp, COMPRA c WHERE c.fk_METODOPAGO = mp.ID AND C.ID =" + idCompra + "");
            while (tabla!=null && tabla.Read())
            {
                resultado = new MetodoPago(int.Parse(tabla["ID"].ToString()), tabla["NUMERO"].ToString(), DateTime.ParseExact(tabla["FECHAVENC"].ToString(), "yyyy-MM-dd", null), tabla["MARCA"].ToString());
            }
            return resultado;

        }

        public int modificarMetodoPago(MetodoPago metodoModificado, int idMetodoActual, int idUsuario)
        {
            int respuesta= ConexionSqlServer.insertar("UPDATE METODO_PAGO SET numero=" + metodoModificado.Numero.ToString() + ",marca='" + metodoModificado.Marca + "',fecha_vencimiento='" + metodoModificado.FechaVencimiento.ToString() + "' where id=" + idMetodoActual.ToString() + " and fk_usuario=" + idUsuario.ToString() + "");
            ConexionSqlServer.cerrarConexion();
            return respuesta;
        }

        public List<Tag> buscarTagPorProducto(int idproducto)
        {
             
            SqlDataReader tabla = ConexionSqlServer.consultar("select t.* from tag t, detalle_tag dt, producto p where t.id = dt.pk_tag AND p.id = dt.pk_producto and p.id =" + idproducto.ToString() + ";");
            List<Tag> listaresultado = new List<Tag>();
            while (tabla!=null && tabla.Read())
            {
                listaresultado.Add(new Tag(int.Parse(tabla["ID"].ToString()), tabla["NOMBRE"].ToString()));

            }
            ConexionSqlServer.cerrarConexion();
            return listaresultado;
        }

        public List<Categoria> categorias()
        {
            SqlDataReader tabla = ConexionSqlServer.consultar("select * from categoria;");
            List<Categoria> listaresultado = new List<Categoria>();
            while (tabla!=null && tabla.Read())
            {
                listaresultado.Add(new Categoria(int.Parse(tabla["ID"].ToString()), tabla["NOMBRE"].ToString()));

            }
            ConexionSqlServer.cerrarConexion();
            return listaresultado;
        }

        public Categoria buscarCategoriaPorProducto(int idProducto)
        {
            SqlDataReader tabla = ConexionSqlServer.consultar("select * from categoria c, producto p where p.fk_categoria = c.id AND p.id = " + idProducto + ";");

            while (tabla!=null && tabla.Read())
            {
                Categoria resultado = new Categoria(int.Parse(tabla["ID"].ToString()), tabla["NOMBRE"].ToString());
                ConexionSqlServer.cerrarConexion();
                return resultado;
            }
            ConexionSqlServer.cerrarConexion();
            return null;
        }

        public int updateCantidad(int idProducto, int cantidadEnExistencia)
        {
            int respuesta = ConexionSqlServer.insertar("UPDATE PRODUCTO SET CANTIDAD=" + cantidadEnExistencia + " WHERE ID=" + idProducto + ";");
            ConexionSqlServer.cerrarConexion();
            return respuesta;
        }

        public List<Producto> consultarProductos()
        {
            SqlDataReader tabla = ConexionSqlServer.consultar("SELECT * FROM PRODUCTO;");
            List<Tag> listaTag = new List<Tag>();
            List<Producto> listaProductos = new List<Producto>();
            if (tabla != null)
            {
                while (tabla != null && tabla.Read())
                {
                    Producto producto = new Producto(int.Parse(tabla["ID"].ToString()), tabla["NOMBRE"].ToString(), tabla["DESCRIPCION"].ToString(),
                        float.Parse(tabla["PRECIO"].ToString()), tabla["IMAGENMINIATURA"].ToString(), tabla["IMAGENDETALLE"].ToString(), null,
                        int.Parse(tabla["CANTIDAD"].ToString()));
                    producto.Etiquetas = buscarTagPorProducto(int.Parse(tabla["ID"].ToString()));
                    producto.Categoria = buscarCategoriaPorProducto(int.Parse(tabla["ID"].ToString()));
                    listaProductos.Add(producto);
                }
            }
            ConexionSqlServer.cerrarConexion();
            return listaProductos;
        }


        public List<Producto> buscarPorNombre(String nombre)
        {
            SqlDataReader tabla = ConexionSqlServer.consultar("SELECT * FROM PRODUCTO WHERE NOMBRE LIKE '%" + nombre + "%';");
            List<Tag> listaTag = new List<Tag>();
            List<Producto> listaProductos = new List<Producto>();
            while (tabla != null && tabla.Read())
            {
                Producto producto = new Producto(int.Parse(tabla["ID"].ToString()), tabla["NOMBRE"].ToString(), tabla["DESCRIPCION"].ToString(),
                    float.Parse(tabla["PRECIO"].ToString()), tabla["IMAGENMINIATURA"].ToString(), tabla["IMAGENDETALLE"].ToString(), null,
                    int.Parse(tabla["CANTIDAD"].ToString()));
                producto.Etiquetas = buscarTagPorProducto(producto.Id);
                producto.Categoria = buscarCategoriaPorProducto(producto.Id);
                listaProductos.Add(producto);
            }
            ConexionSqlServer.cerrarConexion();
            return listaProductos;
        }


        public List<Producto> buscarPorCategoria(String nombreCategoria)
        {
            SqlDataReader tabla = ConexionSqlServer.consultar("SELECT p.* FROM PRODUCTO p, CATEGORIA c WHERE p.FK_CATEGORIA = c.ID AND c.NOMBRE LIKE '%" + nombreCategoria + "%';");
            List<Tag> listaTag = new List<Tag>();
            List<Producto> listaProductos = new List<Producto>();
            while (tabla != null && tabla.Read())
            {
                Producto producto = new Producto(int.Parse(tabla["ID"].ToString()), tabla["NOMBRE"].ToString(), tabla["DESCRIPCION"].ToString(),
                    float.Parse(tabla["PRECIO"].ToString()), tabla["IMAGENMINIATURA"].ToString(), tabla["IMAGENDETALLE"].ToString(), null,
                    int.Parse(tabla["CANTIDAD"].ToString()));
                producto.Etiquetas = buscarTagPorProducto(producto.Id);
                producto.Categoria = buscarCategoriaPorProducto(producto.Id);
                listaProductos.Add(producto);
            }
            ConexionSqlServer.cerrarConexion();
            return listaProductos;
        }

        public Producto buscarPorCompra(int idDetalleCompra)
        {
            SqlDataReader tabla = ConexionSqlServer.consultar("SELECT p.* FROM COMPRA c, PRODUCTO p, DETALLE_COMPRA dc WHERE p.ID = dc.FK_PRODUCTO AND C.id = dc.FK_COMPRA AND dc.id=" + idDetalleCompra.ToString() + ";");
            List<Tag> listaTag = new List<Tag>();
            while (tabla != null && tabla.Read())
            {
                Producto resultado = new Producto(int.Parse(tabla["ID"].ToString()), tabla["NOMBRE"].ToString(), tabla["DESCRIPCION"].ToString(),
                    float.Parse(tabla["PRECIO"].ToString()), tabla["IMAGENMINIATURA"].ToString(), tabla["IMAGENDETALLE"].ToString(), null,
                    int.Parse(tabla["CANTIDAD"].ToString()));
                listaTag = buscarTagPorProducto(int.Parse(tabla["ID"].ToString()));
                Categoria categoria = buscarCategoriaPorProducto(int.Parse(tabla["ID"].ToString()));
                ConexionSqlServer.cerrarConexion();
                return resultado;
            }
            ConexionSqlServer.cerrarConexion();
            return null;
        }

        public int agregarCalificacion(int idProducto, Calificacion calificacion)
        {
            int respuesta = ConexionSqlServer.insertar("INSERT INTO Calificacion ( ID, DETALLE, PUNTAJE, FK_USUARIO, FK_PRODUCTO, FECHA) VALUES (NEXT VALUE FOR SEQ_CALIFICACION,'" + calificacion.Comentario + "', " + calificacion.Puntaje.ToString() + ", " + calificacion.Usuario.Id.ToString() + ", " + idProducto.ToString() + ", '" + DateTime.Today.ToString("yyyy-MM-dd") + "');");
            ConexionSqlServer.cerrarConexion();
            return respuesta;
        }

        public List<DetalleCompra> buscarDetalleCompra(int idCompra)
        {
            SqlDataReader tabla = ConexionSqlServer.consultar("SELECT dc.* FROM DETALLE_COMPRA dc where dc.FK_COMPRA=" + idCompra.ToString() + ";");
            List<DetalleCompra> resultado = new List<DetalleCompra>();
            while (tabla!=null && tabla.Read())
            {
                DetalleCompra detalleCompra = new DetalleCompra(int.Parse(tabla["ID"].ToString()), float.Parse(tabla["MONTO"].ToString()), int.Parse(tabla["CANTIDAD"].ToString()), null);
                detalleCompra.Producto = buscarPorCompra(detalleCompra.Id);
                resultado.Add(detalleCompra);
            }
            ConexionSqlServer.cerrarConexion();
            return resultado;
        }
    }
}