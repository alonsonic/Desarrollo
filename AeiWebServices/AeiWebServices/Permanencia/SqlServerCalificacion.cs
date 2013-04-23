using AeiWebServices.Logica;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AeiWebServices.Permanencia
{
    public class SqlServerCalificacion : DAOCalificacion, DAOUsuario, DAODireccion, DAOMetodoPago, DAOCompra, DAODetalleCompra, DAOProducto, DAOTag, DAOCategoria
    {
        private ConexionSqlServer conexion = new ConexionSqlServer();

        public int agregarCalificacion(Calificacion calificacion, int idUsuario, int idProducto)
        {
            return conexion.insertar("INSERT INTO id, puntaje, comentario, usuario, fecha VALUES(NEXT VALUE FOR SEQ_CALIFICACION," + calificacion.Puntaje.ToString() + ",'" + calificacion.Comentario + "'," + idUsuario.ToString() + ",'" + DateTime.Today.ToString("yyyy-MM-dd") + "'); ");

        }

        public List<Calificacion> consultarCalificacionesPorProducto(int idProducto)
        {
            ConexionSqlServer conexion = new ConexionSqlServer();
            SqlDataReader tabla = conexion.consultar("SELECT c.*, (SELECT CONVERT(VARCHAR(19), c.fecha, 120)) as fechacali FROM CALIFICACION AS c WHERE fk_producto=" + idProducto.ToString() + ";");
            List<Calificacion> listaresultado = new List<Calificacion>();
            Usuario usuario = new Usuario();
            while (tabla.Read())
            {
                usuario = consultarUsuario(int.Parse(tabla["FK_USUARIO"].ToString()));
                listaresultado.Add(new Calificacion(int.Parse(tabla["ID"].ToString()), int.Parse(tabla["PUNTAJE"].ToString()), tabla["DETALLE"].ToString(), DateTime.ParseExact(tabla["FECHACALI"].ToString(), "yyyy-MM-dd", null), usuario));
            }
            return listaresultado;
        }        

        public List<Categoria> categorias()
        {
            ConexionSqlServer conexion = new ConexionSqlServer();
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
        public List<Producto> busquedaProductos(string busqueda)
        {
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
            return listaResultado;
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
            SqlDataReader tabla = conexion.consultar("SELECT * FROM PRODUCTO, CATEGORIA c WHERE NOMBRE LIKE '%" + nombre + "%' AND p.FK_CATEGORIA = c.ID AND c.NOMBRE LIKE '%" + nombreCategoria + "%'");
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
        public List<Producto> buscarPorTag(string nombreTag, string nombreCategoria)
        {
            SqlDataReader tabla = conexion.consultar("SELECT p.* FROM PRODUCTO p, tag t,Detalle_Tag dd,Categoria c  WHERE p.FK_CATEGORIA = c.ID AND dd.pk_producto=p.id AND t.id=dd.pk_tag AND T.NOMBRE LIKE '%" + nombreTag + " AND %'c.NOMBRE LIKE '%" + nombreCategoria + "%';");
            List<Tag> listaTag = new List<Tag>();
            List<Producto> listaProductos = new List<Producto>();
            while (tabla.Read())
            {
                listaTag = buscarTagPorProducto(int.Parse(tabla["ID"].ToString()));
                Categoria categoria = buscarCategoriaPorProducto(int.Parse(tabla["ID"].ToString()));
                listaProductos.Add(new Producto(int.Parse(tabla["ID"].ToString()), tabla["NOMBRE"].ToString(), tabla["DESCRIPCION"].ToString(),
                    float.Parse(tabla["PRECIO"].ToString()), tabla["IMAGENMINIATURA"].ToString(),tabla["IMAGENDETALLE"].ToString(), 
                    categoria,int.Parse(tabla["CANTIDAD"].ToString())));
            }
            return listaProductos;
        }
        public List<Tag> buscarTagPorProducto(int idproducto)
        {

            SqlDataReader tabla = conexion.consultar("select t.* from tag t, detalle_tag dt, producto p where t.id = dt.pk_tag AND p.id = dt.pk_producto AND p.id =" + idproducto.ToString() + ";");
            List<Tag> listaresultado = new List<Tag>();
            while (tabla.Read())
            {
                listaresultado.Add(new Tag(int.Parse(tabla["ID"].ToString()), tabla["NOMBRE"].ToString()));

            }
            return listaresultado;
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
                listaProductos.Add(new Producto(int.Parse(tabla["ID"].ToString()) , tabla["NOMBRE"].ToString(), tabla["DESCRIPCION"].ToString(), 
                    float.Parse(tabla["PRECIO"].ToString()), tabla["IMAGENMINIATURA"].ToString(), tabla["IMAGENDETALLE"].ToString(), categoria, 
                    int.Parse(tabla["CANTIDAD"].ToString())));
            }
            return listaProductos;
        }


        public List<Producto> buscarPorNombre(String nombre)
        {
            SqlDataReader tabla = conexion.consultar("SELECT * FROM PRODUCTO WHERE NOMBRE LIKE '%"+nombre+"%';");
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
        public List<Producto> buscarPorTag(String nombreTag)
        {
            SqlDataReader tabla = conexion.consultar("SELECT p.* FROM PRODUCTO p, tag t,Detalle_Tag dd  WHERE dd.pk_producto=p.id and t.id=dd.pk_tag AND T.NOMBRE LIKE '%" + nombreTag + "%';");
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

        public List<DetalleCompra> buscarDetalleCompra(int idCompra)
        {
            SqlDataReader tabla = conexion.consultar("SELECT dc.* FROM DETALLE_COMPRA dc where dc.FK_COMPRA="+idCompra.ToString()+";");
            List<DetalleCompra> resultado = new List<DetalleCompra>();
            while (tabla.Read())
            {
                Producto producto = buscarPorCompra(int.Parse(tabla["ID"].ToString()));
                resultado.Add(new DetalleCompra(float.Parse(tabla["MONTO"].ToString()), int.Parse(tabla["CANTIDAD"].ToString()), producto));
    
            }
            return resultado;
        }

        public Compra consultarCarrito(int idUsuario) 
        {
            SqlDataReader tabla = conexion.consultar("select c.*, (SELECT CONVERT(VARCHAR(19), c.fecha_solicitud, 120)) as fechaSol, (SELECT CONVERT(VARCHAR(19), c.fecha_entrega, 120)) as fechaEnt from compra AS c where c.fk_usuario="+idUsuario+" and c.estado='C'");
            while (tabla.Read())
            {
                List<DetalleCompra> listaDetalleCompra = buscarDetalleCompra(int.Parse(tabla["ID"].ToString()));
                Compra resultado = new Compra(int.Parse(tabla["ID"].ToString()), float.Parse(tabla["MONTO_TOTAL"].ToString()), 
                    DateTime.ParseExact(tabla["FECHASOL"].ToString(), "yyyy-MM-dd", null),
                    DateTime.ParseExact(tabla["FECHAENT"].ToString(), "yyyy-MM-dd", null), tabla["ESTADO"].ToString(), null, listaDetalleCompra, null);

                return resultado;

            }
            return null;
        }

        public List<Compra> consultarHistorialCompras(int idUsuario)
        {
            SqlDataReader tabla = conexion.consultar("select c.*, (SELECT CONVERT(VARCHAR(19), c.fecha_solicitud, 120)) as fechaSol, (SELECT CONVERT(VARCHAR(19), c.fecha_entrega, 120)) as fechaEnt from compra AS c where fk_usuario="+idUsuario+" and estado<>'C';");
            List<Compra> listaCompras = new List<Compra>();
            while (tabla.Read())
            {
                List<DetalleCompra> listaDetalleCompra = buscarDetalleCompra(int.Parse(tabla["ID"].ToString()));
                Direccion direccion = ConsultarDireccionDeCompra(int.Parse(tabla["ID"].ToString()));
                MetodoPago metodoPago = consultarMetodosPagoDeCompra(int.Parse(tabla["ID"].ToString()));
                listaCompras.Add( new Compra(int.Parse(tabla["ID"].ToString()), float.Parse(tabla["MONTO_TOTAL"].ToString()),
                    DateTime.ParseExact(tabla["FECHASOL"].ToString(), "yyyy-MM-dd", null),
                    DateTime.ParseExact(tabla["FECHAENT"].ToString(), "yyyy-MM-dd", null), tabla["ESTADO"].ToString(), metodoPago,
                    listaDetalleCompra, direccion));
            }
            return listaCompras;
        }

        public int agregarCompra(Compra compra)
        {
            return conexion.insertar("INSERT INTO Compra (id,monto_total, fecha_solicitud, fecha_entrega, estado,fk_metodopago,fk_det_direccion,fk_usuario) VALUES (NEXT VALUE FOR seq_compra," + compra.MontoTotal.ToString() + ",'" + compra.FechaSolicitud.ToString("yyyy-MM-dd") + "','" + compra.FechaEntrega.ToString("yyyy-MM-dd") + "','" + compra.Status + "'," + compra.Pago.Id.ToString() + ","+compra.Direccion.Id.ToString()+", null);");
        }

        public int modificarEstadoDeCompra(String Status, int idCompra)
        {
            return conexion.insertar("UPDATE COMPRA SET ESTADO='" + Status + "' WHERE ID=" + idCompra.ToString() + ";");
        }

        public int agregarMetodoPago(MetodoPago metodo, int idUsuario)
        {
            return conexion.insertar("INSERT INTO Metodo_Pago (id, numero,marca,fecha_vencimiento,fk_usuario) VALUES (NEXT VALUE FOR seq_metodo_pago," + metodo.Numero.ToString() + ",'" + metodo.Marca + "','" + metodo.FechaVencimiento.ToString("yyyy-MM-dd") + "'," + idUsuario+")");
        }
        
        public List<MetodoPago> consultarAllMetodosPago(int idUsuario)
        {
            SqlDataReader tabla = conexion.consultar("select m.*, (SELECT CONVERT(VARCHAR(19), m.fecha_vencimiento, 120)) as fecha from Metodo_Pago AS m where fk_usuario=" + idUsuario.ToString() + ";");
            List<MetodoPago> lista = new List<MetodoPago>();
            while (tabla.Read())
            {
                lista.Add(new MetodoPago(int.Parse(tabla["ID"].ToString()), tabla["NUMERO"].ToString(), DateTime.ParseExact(tabla["FECHA"].ToString(), "yyyy-MM-dd", null), tabla["MARCA"].ToString()));
            }
            return lista;
        }

        public MetodoPago consultarMetodosPagoDeCompra(int idCompra)
        {
            MetodoPago resultado = null;
            SqlDataReader tabla = conexion.consultar("SELECT mp.* , (SELECT CONVERT(VARCHAR(19), mp.fecha_vencimiento, 120)) as fechaVenc FROM Metodo_Pago mp, COMPRA c WHERE c.fk_METODOPAGO = mp.ID AND C.ID ="+idCompra+"");
            while (tabla.Read())
            {
                resultado = new MetodoPago(int.Parse(tabla["ID"].ToString()), tabla["NUMERO"].ToString(), DateTime.ParseExact(tabla["FECHAVENC"].ToString(), "yyyy-MM-dd", null), tabla["MARCA"].ToString());
            }
            return resultado;

        }

        public int modificarMetodoPago(MetodoPago metodoModificado, int idMetodoActual, int idUsuario) 
        {
            return conexion.insertar("UPDATE METODO_PAGO SET numero=" + metodoModificado.Numero.ToString() + ",marca='" + metodoModificado.Marca + "',fecha_vencimiento='" + metodoModificado.FechaVencimiento.ToString() + "' where id=" + idMetodoActual.ToString() + " and fk_usuario=" + idUsuario.ToString() + "");
        }

        public int AgregarDireccionUsuario(int idUsuario, int idDireccion, Direccion direccion)
        {
            return conexion.insertar("INSERT INTO Detalle_Direccion (id,descripcion,codigo_postal,status,fk_direccion, fk_usuario)  VALUES (NEXT VALUE FOR seq_detalle_direccion, '"+direccion.Descripcion+"',"+direccion.CodigoPostal.ToString()+",'"+direccion.Status+"',"+idDireccion.ToString()+","+idUsuario.ToString()+");");
        }
        
        public List<Direccion> ConsultarDireccion(int idUsuario)
        {
            SqlDataReader tabla = conexion.consultar("select c.id AS id, p.nombre AS pais, e.nombre AS estado, c.nombre AS ciudad, dd.codigo_postal AS codigo_postal, dd.descripcion AS descripcion, dd.status AS status from detalle_direccion dd, direccion c, direccion e, direccion p where p.id=e.fk_id AND e.id=c.fk_id AND c.id=dd.fk_direccion AND dd.fk_usuario=" + idUsuario.ToString() + ";");
            List<Direccion> lista = new List<Direccion>();
            while (tabla.Read())
            {
                lista.Add(new Direccion(int.Parse(tabla["ID"].ToString()), tabla["PAIS"].ToString(), tabla["ESTADO"].ToString(), tabla["CIUDAD"].ToString(), int.Parse(tabla["CODIGO_POSTAL"].ToString()), tabla["DESCRIPCION"].ToString(),tabla["STATUS"].ToString()));
            }
            return lista;
        }
        
        public Direccion ConsultarDireccionDeCompra(int idCompra)
        {
            Direccion resultado = null;
            SqlDataReader tabla = conexion.consultar("select c.id AS id, p.nombre AS pais, e.nombre AS estado, c.nombre AS ciudad, dd.codigo_postal AS codigo_postal, dd.descripcion AS descripcion, dd.status AS status, cp.id AS idcompra from detalle_direccion dd, direccion c, direccion e, direccion p, COMPRA cp where p.id=e.fk_id AND e.id=c.fk_id AND c.id=dd.fk_direccion AND cp.ID="+idCompra.ToString()+";");
            while (tabla.Read())
            {
                resultado = new Direccion(int.Parse(tabla["ID"].ToString()), tabla["PAIS"].ToString(), tabla["ESTADO"].ToString(), tabla["CIUDAD"].ToString(), int.Parse(tabla["CODIGO_POSTAL"].ToString()), tabla["DESCRIPCION"].ToString(), tabla["STATUS"].ToString());
            }
            return resultado;
        }

        public int modificarDireccion(int idDireccion, Direccion direccionModificada)
        {
            return 0;
        }

        public List<Direccion> consultarEstados()
        {
            SqlDataReader tabla = conexion.consultar("SELECT * FROM DIRECCION WHERE NIVEL = 'e';");
            List<Direccion> listaDireccion = new List<Direccion>();
            while (tabla.Read())
            {
                listaDireccion.Add(new Direccion(int.Parse(tabla["ID"].ToString()), null, tabla["NOMBRE"].ToString(), null, -1, null, null));
            }
            return listaDireccion;

        }

        public List<Direccion> consultarCiudad(int idEstado)
        {
            SqlDataReader tabla = conexion.consultar("SELECT e.NOMBRE as ESTADO , c.* FROM DIRECCION , DIRECCION c WHERE c.NIVEL = 'c' AND c.FKID = e.ID AND e.ID=" + idEstado.ToString() + ";");
            List<Direccion> listaDireccion = new List<Direccion>();
            while (tabla.Read())
            {
                listaDireccion.Add(new Direccion(int.Parse(tabla["ID"].ToString()), null, tabla["ESTADO"].ToString(), tabla["NOMBRE"].ToString(), -1, null, null));
            }
            return listaDireccion;

        }

        public Usuario consultarUsuario(string mail, int codigoActivacion)
        {
            SqlDataReader tabla = conexion.consultar("select u.*, (SELECT CONVERT(VARCHAR(19), u.fecha_nac, 120)) as fechaNac, (SELECT CONVERT(VARCHAR(19), u.fecha_ing, 120)) as fechaIng from usuario AS u where mail='"+mail+"'");
            while (tabla.Read())
            {
                List<Direccion> direccion = ConsultarDireccion(int.Parse(tabla["ID"].ToString()));
                List<MetodoPago> metodoPago = consultarAllMetodosPago(int.Parse(tabla["ID"].ToString()));
                Compra carrito = consultarCarrito(int.Parse(tabla["ID"].ToString()));
                List<Compra> compras = consultarHistorialCompras(int.Parse(tabla["ID"].ToString()));
                Usuario usuario = new Usuario(int.Parse(tabla["ID"].ToString()), tabla["NOMBRE"].ToString(), tabla["APELLIDO"].ToString(),
                    tabla["PASAPORTE"].ToString(), tabla["MAIL"].ToString(),
                    DateTime.ParseExact(tabla["FECHAING"].ToString(), "yyyy-MM-dd", null),
                    DateTime.ParseExact(tabla["FECHANAC"].ToString(), "yyyy-MM-dd", null),
                    tabla["STATUS"].ToString(), carrito, compras, direccion, metodoPago, codigoActivacion);
                return usuario;
            }
            return null;
        }

        public Usuario consultarUsuario(string mail)
        {
            SqlDataReader tabla = conexion.consultar("select u.*, (SELECT CONVERT(VARCHAR(19), u.fecha_nac, 120)) as fechaNac, (SELECT CONVERT(VARCHAR(19), u.fecha_ing, 120)) as fechaIng from usuario AS u where mail='" + mail + "'");
            while (tabla.Read())
            {
                List<Direccion> direccion = ConsultarDireccion(int.Parse(tabla["ID"].ToString()));
                List<MetodoPago> metodoPago = consultarAllMetodosPago(int.Parse(tabla["ID"].ToString()));
                Compra carrito = consultarCarrito(int.Parse(tabla["ID"].ToString()));
                List<Compra> compras = consultarHistorialCompras(int.Parse(tabla["ID"].ToString()));
                Usuario usuario = new Usuario(int.Parse(tabla["ID"].ToString()), tabla["NOMBRE"].ToString(), tabla["APELLIDO"].ToString(),
                    tabla["PASAPORTE"].ToString(), tabla["MAIL"].ToString(),
                    DateTime.ParseExact(tabla["FECHAING"].ToString(), "yyyy-MM-dd", null),
                    DateTime.ParseExact(tabla["FECHANAC"].ToString(), "yyyy-MM-dd", null),
                    tabla["STATUS"].ToString(), carrito, compras, direccion, metodoPago, 0);
                return usuario;
            }
            return null;
        }
        public Usuario consultarUsuario(int id)
        {
            SqlDataReader tabla = conexion.consultar("select u.*, (SELECT CONVERT(VARCHAR(19), u.fecha_nac, 120)) as fechaNac, (SELECT CONVERT(VARCHAR(19), u.fecha_ing, 120)) as fechaIng from usuario AS u where id='" + id.ToString() + "'");
            while (tabla.Read())
            {
                List<Direccion> direccion = ConsultarDireccion(int.Parse(tabla["ID"].ToString()));
                List<MetodoPago> metodoPago = consultarAllMetodosPago(int.Parse(tabla["ID"].ToString()));
                Compra carrito = consultarCarrito(int.Parse(tabla["ID"].ToString()));
                List<Compra> compras = consultarHistorialCompras(int.Parse(tabla["ID"].ToString()));
                Usuario usuario = new Usuario(int.Parse(tabla["ID"].ToString()), tabla["NOMBRE"].ToString(), tabla["APELLIDO"].ToString(),
                    tabla["PASAPORTE"].ToString(), tabla["MAIL"].ToString(),
                    DateTime.ParseExact(tabla["FECHAING"].ToString(), "yyyy-MM-dd", null),
                    DateTime.ParseExact(tabla["FECHANAC"].ToString(), "yyyy-MM-dd", null),
                    tabla["STATUS"].ToString(), carrito, compras, direccion, metodoPago, 0);
                return usuario;
            }
            return null;
        }

        public int modificarUsuario(Usuario usuarioModificado, int idUsuario)
        {
            return conexion.insertar("UPDATE USUARIO SET nombre='" + usuarioModificado.Nombre + "', apellido= '" + usuarioModificado.Apellido + "',  fecha_nac='" + usuarioModificado.FechaNacimiento.ToString() + "', fecha_ing= '" + usuarioModificado.FechaRegistro.ToString() + "', status= '"+usuarioModificado.Status+"', codigoActivacion= '"+usuarioModificado.CodigoActivacion+"' where id=" + idUsuario + ";");
        }

        public int agregarUsuario(Usuario usuario)
        {
            String fechaActual= DateTime.Now.ToString("yyyy-MM-dd");
            return conexion.insertar("INSERT INTO Usuario (id, pasaporte, nombre, apellido, fecha_nac, mail, fecha_ing, status, codigoActivacion) VALUES (NEXT VALUE FOR SEQ_usuario,'" + usuario.Pasaporte + "','" + usuario.Nombre + "', '" + usuario.Apellido + "','" + usuario.FechaNacimiento.ToString("yyyy-MM-dd") + "','"+usuario.Email+"','"+fechaActual.ToString()+"','I',NEXT VALUE FOR seq_codigo_activacion);");
        }
    }
}