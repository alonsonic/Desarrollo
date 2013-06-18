using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using AeiWebServices.Logica;

namespace AeiWebServices.Permanencia
{
    public class SqlServerProducto: DAOProducto
    {
        private SqlServerTag daoTag = new SqlServerTag();
        private SqlServerCategoria daoCategotia = new SqlServerCategoria();
        
        private Boolean validarRango(int pagina, int limite)
        {
            double d = (double)limite / (double)pagina;
            double resultado = Math.Round(d);
            if (resultado < pagina) return false;
            return true;
        }
        private List<Producto> enviarResultado(List<Producto> busqueda, int pagina, int numeroArticulo)
        {
            int limite = busqueda.Count;
            int fin = (pagina * numeroArticulo);
            int inicio = (pagina -1) * numeroArticulo;
            List<Producto> resultado=null;
            if (validarRango(pagina, limite))
            {
                if (fin > limite) resultado = busqueda.GetRange(inicio, numeroArticulo - (fin - limite));
                else resultado = busqueda.GetRange(inicio, numeroArticulo);
                return resultado;
            }
            return null;
        }

        public List<Producto> busquedaProductos(string busqueda, int pagina, int numeroArticulo)
        {
            if (pagina != 0 && numeroArticulo != 0)
            {

                xmlLog log = new xmlLog();
                log.escribir(busqueda, "Entrada");
                char[] separadores = { ' ', ',', '.', ':' };
                string[] tags = busqueda.Split(separadores);
                List<Producto> listaNombre = new List<Producto>();
                List<Producto> listaCategoria = new List<Producto>();
                List<Producto> listaTag = new List<Producto>();
                for (int index = 0; index < tags.Length; index++)
                {
                    listaNombre = listaNombre.Concat(buscarPorNombre(tags[index])).ToList();
                    listaCategoria = listaCategoria.Concat(buscarPorCategoria(tags[index])).ToList();
                    listaTag = listaTag.Concat(buscarPorTag(tags[index])).ToList();
                    listaNombre = listaNombre.Distinct(new Comparer()).ToList();
                    listaCategoria = listaCategoria.Distinct(new Comparer()).ToList();
                    listaTag = listaTag.Distinct(new Comparer()).ToList();
                }
                List<Producto> listaResultado = listaCategoria.Concat(listaNombre).ToList();
                listaResultado = listaResultado.Concat(listaTag).ToList();
                listaResultado = listaResultado.Distinct(new Comparer()).ToList();
                log.escribir(busqueda, "Salida");
                return enviarResultado(listaResultado, pagina, numeroArticulo);
            }
            return null;
        }

        public List<Producto> busquedaProductos(string categoriaProducto, string busqueda)
        {
            char[] separadores = { ' ', ',', '.', ':' };
            string[] tags = busqueda.Split(separadores);
            List<Producto> listaNombre = new List<Producto>();
            List<Producto> listaTag = new List<Producto>();
            for (int index = 0; index < tags.Length; index++)
            {
                listaNombre = listaNombre.Concat(buscarPorNombre(tags[index], categoriaProducto)).ToList();
                listaTag = listaTag.Concat(buscarPorTag(tags[index], categoriaProducto)).ToList();
                listaNombre = listaNombre.Distinct(new Comparer()).ToList();
                listaTag = listaTag.Distinct(new Comparer()).ToList();
            }
            List<Producto> listaResultado = listaNombre.Concat(listaTag).ToList();
            listaResultado = listaResultado.Distinct(new Comparer()).ToList();
            return listaResultado;

        }

        public List<Producto> buscarPorNombre(string nombre, string nombreCategoria)
        {
            ConexionSqlServer conexion = new ConexionSqlServer();
            SqlDataReader tabla = conexion.consultar("SELECT * FROM PRODUCTO p, CATEGORIA c WHERE p.NOMBRE LIKE '%" + nombre + "%' AND p.FK_CATEGORIA = c.ID AND c.NOMBRE LIKE '%" + nombreCategoria + "%'");
            List<Tag> listaTag = new List<Tag>();
            List<Producto> listaProductos = new List<Producto>();
            if (tabla != null)
            {
                while (tabla!=null && tabla.Read())
                {
                    listaTag = this.daoTag.buscarTagPorProducto(int.Parse(tabla["ID"].ToString()));
                    Categoria categoria = this.daoCategotia.buscarCategoriaPorProducto(int.Parse(tabla["ID"].ToString()));
                    listaProductos.Add(new Producto(int.Parse(tabla["ID"].ToString()), tabla["NOMBRE"].ToString(), tabla["DESCRIPCION"].ToString(),
                        float.Parse(tabla["PRECIO"].ToString()), tabla["IMAGENMINIATURA"].ToString(), tabla["IMAGENDETALLE"].ToString(), categoria,
                        int.Parse(tabla["CANTIDAD"].ToString())));
                }
            }
            conexion.cerrarConexion();
            return listaProductos;
        }

        public List<Producto> buscarPorTag(string nombreTag, string nombreCategoria)
        {
            ConexionSqlServer conexion = new ConexionSqlServer();
            SqlDataReader tabla = conexion.consultar("SELECT p.* FROM PRODUCTO p, tag t,Detalle_Tag dd,Categoria c  WHERE p.FK_CATEGORIA = c.ID AND dd.pk_producto=p.id AND t.id=dd.pk_tag AND T.NOMBRE LIKE '%" + nombreTag + " AND %'c.NOMBRE LIKE '%" + nombreCategoria + "%';");
            List<Tag> listaTag = new List<Tag>();
            List<Producto> listaProductos = new List<Producto>();
            if (tabla != null)
            {
                while (tabla!=null && tabla.Read())
                {
                    listaTag = this.daoTag.buscarTagPorProducto(int.Parse(tabla["ID"].ToString()));
                    Categoria categoria = this.daoCategotia.buscarCategoriaPorProducto(int.Parse(tabla["ID"].ToString()));
                    listaProductos.Add(new Producto(int.Parse(tabla["ID"].ToString()), tabla["NOMBRE"].ToString(), tabla["DESCRIPCION"].ToString(),
                        float.Parse(tabla["PRECIO"].ToString()), tabla["IMAGENMINIATURA"].ToString(), tabla["IMAGENDETALLE"].ToString(), categoria,
                        int.Parse(tabla["CANTIDAD"].ToString())));
                }
            }
            conexion.cerrarConexion();
            return listaProductos;
        }

        
        public int updateCantidad(int idProducto, int cantidadEnExistencia)
        {
            ConexionSqlServer conexion = new ConexionSqlServer();
            int respuesta= conexion.insertar("UPDATE PRODUCTO SET CANTIDAD=" + cantidadEnExistencia + " WHERE ID=" + idProducto + ";");
            conexion.cerrarConexion();
            return respuesta;
 
        }

        public List<Producto> consultarProductos(int pagina, int numeroArticulo)
        {
            ConexionSqlServer conexion = new ConexionSqlServer();
            SqlDataReader tabla = conexion.consultar("SELECT * FROM PRODUCTO;");
            List<Tag> listaTag = new List<Tag>();
            List<Producto> listaProductos = new List<Producto>();
            if (tabla != null)
            {
                while (tabla!=null && tabla.Read())
                {
                    listaTag = this.daoTag.buscarTagPorProducto(int.Parse(tabla["ID"].ToString()));
                    Categoria categoria = this.daoCategotia.buscarCategoriaPorProducto(int.Parse(tabla["ID"].ToString()));
                    listaProductos.Add(new Producto(int.Parse(tabla["ID"].ToString()), tabla["NOMBRE"].ToString(), tabla["DESCRIPCION"].ToString(),
                        float.Parse(tabla["PRECIO"].ToString()), tabla["IMAGENMINIATURA"].ToString(), tabla["IMAGENDETALLE"].ToString(), categoria,
                        int.Parse(tabla["CANTIDAD"].ToString())));
                }
            }
            conexion.cerrarConexion();
            return enviarResultado(listaProductos, pagina, numeroArticulo);
        }


        public List<Producto> buscarPorNombre(String nombre)
        {
            ConexionSqlServer conexion = new ConexionSqlServer();
            SqlDataReader tabla = conexion.consultar("SELECT * FROM PRODUCTO WHERE NOMBRE LIKE '%" + nombre + "%';");
            List<Tag> listaTag = new List<Tag>();
            List<Producto> listaProductos = new List<Producto>();
            while (tabla!=null && tabla.Read())
            {
                listaTag = this.daoTag.buscarTagPorProducto(int.Parse(tabla["ID"].ToString()));
                Categoria categoria = this.daoCategotia.buscarCategoriaPorProducto(int.Parse(tabla["ID"].ToString()));
                listaProductos.Add(new Producto(int.Parse(tabla["ID"].ToString()), tabla["NOMBRE"].ToString(), tabla["DESCRIPCION"].ToString(),
                    float.Parse(tabla["PRECIO"].ToString()), tabla["IMAGENMINIATURA"].ToString(), tabla["IMAGENDETALLE"].ToString(), categoria,
                    int.Parse(tabla["CANTIDAD"].ToString())));
            }
            conexion.cerrarConexion();
            return listaProductos;
        }


        public List<Producto> buscarPorCategoria(String nombreCategoria)
        {
            ConexionSqlServer conexion = new ConexionSqlServer();
            SqlDataReader tabla = conexion.consultar("SELECT p.* FROM PRODUCTO p, CATEGORIA c WHERE p.cantidad!=0 AND p.FK_CATEGORIA = c.ID AND c.NOMBRE LIKE '%" + nombreCategoria + "%';");
            List<Tag> listaTag = new List<Tag>();
            List<Producto> listaProductos = new List<Producto>();
            while (tabla!=null && tabla.Read())
            {
                listaTag = this.daoTag.buscarTagPorProducto(int.Parse(tabla["ID"].ToString()));
                Categoria categoria = this.daoCategotia.buscarCategoriaPorProducto(int.Parse(tabla["ID"].ToString()));
                listaProductos.Add(new Producto(int.Parse(tabla["ID"].ToString()), tabla["NOMBRE"].ToString(), tabla["DESCRIPCION"].ToString(),
                    float.Parse(tabla["PRECIO"].ToString()), tabla["IMAGENMINIATURA"].ToString(), tabla["IMAGENDETALLE"].ToString(), categoria,
                    int.Parse(tabla["CANTIDAD"].ToString())));
            }
            conexion.cerrarConexion();
            return listaProductos;
        }

        public List<Producto> buscarPorTag(String nombreTag)
        {
            ConexionSqlServer conexion = new ConexionSqlServer();
            SqlDataReader tabla = conexion.consultar("SELECT p.* FROM PRODUCTO p, tag t,Detalle_Tag dd  WHERE dd.pk_producto=p.id and t.id=dd.pk_tag AND T.NOMBRE LIKE '%" + nombreTag + "%';");
            List<Tag> listaTag = new List<Tag>();
            List<Producto> listaProductos = new List<Producto>();
            while (tabla != null && tabla.Read())
            {
                listaTag = this.daoTag.buscarTagPorProducto(int.Parse(tabla["ID"].ToString()));
                Categoria categoria = this.daoCategotia.buscarCategoriaPorProducto(int.Parse(tabla["ID"].ToString()));
                listaProductos.Add(new Producto(int.Parse(tabla["ID"].ToString()), tabla["NOMBRE"].ToString(), tabla["DESCRIPCION"].ToString(),
                    float.Parse(tabla["PRECIO"].ToString()), tabla["IMAGENMINIATURA"].ToString(), tabla["IMAGENDETALLE"].ToString(), categoria,
                    int.Parse(tabla["CANTIDAD"].ToString())));
            }
            conexion.cerrarConexion();
            return listaProductos;
        }

        public Producto buscarPorCompra(int idDetalleCompra)
        {
            ConexionSqlServer conexion = new ConexionSqlServer();
            SqlDataReader tabla = conexion.consultar("SELECT p.* FROM COMPRA c, PRODUCTO p, DETALLE_COMPRA dc WHERE p.ID = dc.FK_PRODUCTO AND C.id = dc.FK_COMPRA AND dc.id=" + idDetalleCompra.ToString() + ";");
            List<Tag> listaTag = new List<Tag>();
            while (tabla!=null && tabla.Read())
            {
                listaTag = this.daoTag.buscarTagPorProducto(int.Parse(tabla["ID"].ToString()));
                Categoria categoria = this.daoCategotia.buscarCategoriaPorProducto(int.Parse(tabla["ID"].ToString()));
                Producto resultado = new Producto(int.Parse(tabla["ID"].ToString()), tabla["NOMBRE"].ToString(), tabla["DESCRIPCION"].ToString(),
                    float.Parse(tabla["PRECIO"].ToString()), tabla["IMAGENMINIATURA"].ToString(), tabla["IMAGENDETALLE"].ToString(), categoria,
                    int.Parse(tabla["CANTIDAD"].ToString()));
                conexion.cerrarConexion();
                return resultado;
            }
            conexion.cerrarConexion();
            return null;
        }

    }
}