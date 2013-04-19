using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;

namespace AeiWebServices.Permanencia
{
    public class SqlServerProducto: DAOProducto,DAOTag,DAOCategoria, DAOMetodoPago
    {
        private ConexionSqlServer conexion = new ConexionSqlServer();

        public int agregarMetodoPago(MetodoPago metodo, int idUsuario)
        {
            return conexion.insertar("INSERT INTO Metodo_Pago (id, numero,marca,fecha_vencimiento,fk_usuario) VALUES (NEXT VALUE FOR seq_metodo_pago," + metodo.Numero.ToString() + ",'" + metodo.Marca + "','" + metodo.FechaVencimiento.ToString("yyyy-MM-dd") + "'," + idUsuario + ")");
        }

        public List<MetodoPago> consultarAllMetodosPago(int idUsuario)
        {
            SqlDataReader tabla = conexion.consultar("select m.*, (SELECT CONVERT(VARCHAR(19), m.fecha_vencimiento, 120)) as fecha from Metodo_Pago AS m where fk_usuario=" + idUsuario.ToString() + ";");
            List<MetodoPago> lista = new List<MetodoPago>();
            while (tabla.Read())
            {
                lista.Add(new MetodoPago(int.Parse(tabla["ID"].ToString()), int.Parse(tabla["NUMERO"].ToString()), DateTime.ParseExact(tabla["FECHA"].ToString(), "yyyy-MM-dd", null), tabla["MARCA"].ToString()));
            }
            return lista;
        }

        public MetodoPago consultarMetodosPagoDeCompra(int idCompra)
        {
            MetodoPago resultado = null;
            SqlDataReader tabla = conexion.consultar("SELECT mp.* , (SELECT CONVERT(VARCHAR(19), mp.fecha_vencimiento, 120)) as fechaVenc FROM Metodo_Pago mp, COMPRA c WHERE c.fk_METODOPAGO = mp.ID AND C.ID =" + idCompra + "");
            while (tabla.Read())
            {
                resultado = new MetodoPago(int.Parse(tabla["ID"].ToString()), int.Parse(tabla["NUMERO"].ToString()), DateTime.ParseExact(tabla["FECHAVENC"].ToString(), "yyyy-MM-dd", null), tabla["MARCA"].ToString());
            }
            return resultado;

        }

        public int modificarMetodoPago(MetodoPago metodoModificado, int idMetodoActual, int idUsuario)
        {
            return conexion.insertar("UPDATE METODO_PAGO SET numero=" + metodoModificado.Numero.ToString() + ",marca='" + metodoModificado.Marca + "',fecha_vencimiento='" + metodoModificado.FechaVencimiento.ToString() + "' where id=" + idMetodoActual.ToString() + " and fk_usuario=" + idUsuario.ToString() + "");
        }

        public List<Tag> buscarTagPorProducto(int idproducto)
        {
            ConexionSqlServer conexion = new ConexionSqlServer();
            SqlDataReader tabla = conexion.consultar("select t.* from tag t, detalle_tag dt, producto p where t.id = dt.pk_tag AND p.id = dt.pk_producto and p.id =" + idproducto.ToString() + ";");
            List<Tag> listaresultado = new List<Tag>();
            while (tabla.Read())
            {
                listaresultado.Add(new Tag(int.Parse(tabla["ID"].ToString()), tabla["NOMBRE"].ToString()));

            }
            return listaresultado;
        }

        public List<Categoria> categorias()
        {
            SqlDataReader tabla = conexion.consultar("select * from categoria;");
            List<Categoria> listaresultado = new List<Categoria>();
            while (tabla.Read())
            {
                listaresultado.Add(new Categoria(int.Parse(tabla["ID"].ToString()), tabla["NOMBRE"].ToString()));

            }
            return listaresultado;
        }

        public Categoria buscarCategoriaPorProducto(int idProducto)
        {
            SqlDataReader tabla = conexion.consultar("select * from categoria c, producto p where p.fk_categoria = c.id AND p.id = " + idProducto + ";");

            while (tabla.Read())
            {
                Categoria resultado = new Categoria(int.Parse(tabla["ID"].ToString()), tabla["NOMBRE"].ToString());
                return resultado;
            }
            return null;
        }

        public int updateCantidad(int idProducto, int cantidadEnExistencia)
        {
            return conexion.insertar("UPDATE PRODUCTO SET CANTIDAD=" + cantidadEnExistencia + " WHERE ID=" + idProducto + ";");
        }

        public List<Producto> consultarProductos()
        {
            SqlDataReader tabla = conexion.consultar("SELECT * FROM PRODUCTO;");
            List<Tag> listaTag = new List<Tag>();
            List<Producto> listaProductos = new List<Producto>();
            while (tabla.Read())
            {
                listaTag = buscarTagPorProducto(int.Parse(tabla["ID"].ToString()));
                Categoria categoria = buscarCategoriaPorProducto(int.Parse(tabla["ID"].ToString()));
                listaProductos.Add(new Producto(int.Parse(tabla["ID"].ToString()), tabla["NOMBRE"].ToString(), tabla["DESCRIPCION"].ToString(),
                    float.Parse(tabla["PRECIO"].ToString()), tabla["IMAGENMINIATURA"].ToString(), tabla["IMAGENDETALLE"].ToString(), categoria,
                    int.Parse(tabla["CANTIDAD"].ToString())));
            }
            return listaProductos;
        }


        public List<Producto> buscarPorNombre(String nombre)
        {
            SqlDataReader tabla = conexion.consultar("SELECT * FROM PRODUCTO WHERE NOMBRE LIKE '%" + nombre + "%';");
            List<Tag> listaTag = new List<Tag>();
            List<Producto> listaProductos = new List<Producto>();
            while (tabla.Read())
            {
                listaTag = buscarTagPorProducto(int.Parse(tabla["ID"].ToString()));
                Categoria categoria = buscarCategoriaPorProducto(int.Parse(tabla["ID"].ToString()));
                listaProductos.Add(new Producto(int.Parse(tabla["ID"].ToString()), tabla["NOMBRE"].ToString(), tabla["DESCRIPCION"].ToString(),
                    float.Parse(tabla["PRECIO"].ToString()), tabla["IMAGENMINIATURA"].ToString(), tabla["IMAGENDETALLE"].ToString(), categoria,
                    int.Parse(tabla["CANTIDAD"].ToString())));
            }
            return listaProductos;
        }


        public List<Producto> buscarPorCategoria(String nombreCategoria)
        {
            SqlDataReader tabla = conexion.consultar("SELECT p.* FROM PRODUCTO p, CATEGORIA c WHERE p.FK_CATEGORIA = c.ID AND c.NOMBRE LIKE '%" + nombreCategoria + "%';");
            List<Tag> listaTag = new List<Tag>();
            List<Producto> listaProductos = new List<Producto>();
            while (tabla.Read())
            {
                listaTag = buscarTagPorProducto(int.Parse(tabla["ID"].ToString()));
                Categoria categoria = buscarCategoriaPorProducto(int.Parse(tabla["ID"].ToString()));
                listaProductos.Add(new Producto(int.Parse(tabla["ID"].ToString()), tabla["NOMBRE"].ToString(), tabla["DESCRIPCION"].ToString(),
                    float.Parse(tabla["PRECIO"].ToString()), tabla["IMAGENMINIATURA"].ToString(), tabla["IMAGENDETALLE"].ToString(), categoria,
                    int.Parse(tabla["CANTIDAD"].ToString())));
            }
            return listaProductos;
        }

        public Producto buscarPorCompra(int idDetalleCompra)
        {
            SqlDataReader tabla = conexion.consultar("SELECT p.* FROM COMPRA c, PRODUCTO p, DETALLE_COMPRA dc WHERE p.ID = dc.FK_PRODUCTO AND C.id = dc.FK_COMPRA AND dc.id=" + idDetalleCompra.ToString() + ";");
            List<Tag> listaTag = new List<Tag>();
            while (tabla.Read())
            {
                listaTag = buscarTagPorProducto(int.Parse(tabla["ID"].ToString()));
                Categoria categoria = buscarCategoriaPorProducto(int.Parse(tabla["ID"].ToString()));
                Producto resultado = new Producto(int.Parse(tabla["ID"].ToString()), tabla["NOMBRE"].ToString(), tabla["DESCRIPCION"].ToString(),
                    float.Parse(tabla["PRECIO"].ToString()), tabla["IMAGENMINIATURA"].ToString(), tabla["IMAGENDETALLE"].ToString(), categoria,
                    int.Parse(tabla["CANTIDAD"].ToString()));

                return resultado;
            }

            return null;
        }

        public int agregarCalificacion(int idProducto, Calificacion calificacion)
        {
            return conexion.insertar("INSERT INTO Calificacion ( ID, DETALLE, PUNTAJE, FK_USUARIO, FK_PRODUCTO, FECHA) VALUES (NEXT VALUE FOR SEQ_CALIFICACION,'" + calificacion.Comentario + "', " + calificacion.Puntaje.ToString() + ", " + calificacion.Usuario.Id.ToString() + ", " + idProducto.ToString() + ", '" + DateTime.Today.ToString("yyyy-MM-dd") + "');");
        }


    }
}