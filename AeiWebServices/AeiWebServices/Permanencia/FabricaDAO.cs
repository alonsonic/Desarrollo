using AeiWebServices.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AeiWebServices.Permanencia
{
    public static class FabricaDAO
    {
        static public int setEliminarDetalleCarrito(int idDetalleCompra)
        {
            SqlServerDetalleCompra resultado = new SqlServerDetalleCompra();
            int respuesta = resultado.borrarDetalleCompra(idDetalleCompra);
            ConexionSqlServer.cerrarConexion();
            return respuesta;
        }
        static public List<Direccion> getListaDireccion(int idUsuario)
        {
            SqlServerDireccion resultado = new SqlServerDireccion();
            List<Direccion> direccion = resultado.ConsultarDireccion(idUsuario);
            ConexionSqlServer.cerrarConexion();
            return direccion;
        }

        static public List<DetalleCompra> getListaProductos(int idCompra)
        {
            SqlServerDetalleCompra resultado = new SqlServerDetalleCompra();
            List<DetalleCompra> detalleCompra= resultado.buscarDetalleCompra(idCompra);
            ConexionSqlServer.cerrarConexion();
            return detalleCompra;
        }
        static public Compra getCarrito(int idUsuario)
        {
            SqlServerCompra resultado = new SqlServerCompra();
            Compra compra= resultado.consultarCarrito(idUsuario);
            ConexionSqlServer.cerrarConexion();
            return compra;
        }
        static public int setAgregarDetalleCompra(int idCompra, DetalleCompra detalleCompra)
        {
            SqlServerDetalleCompra resultado = new SqlServerDetalleCompra();
            int respuesta= resultado.agregarDetalleCompra(idCompra, detalleCompra);
            ConexionSqlServer.cerrarConexion();
            return respuesta;
        }
        static public List<Calificacion> getCalificaciones(int idProducto)
        {
            SqlServerCalificacion resultado = new SqlServerCalificacion();
            List<Calificacion> calificacion= resultado.consultarCalificacionesPorProducto(idProducto);
            ConexionSqlServer.cerrarConexion();
            return calificacion;
        }
        static public Twitter getUsuarioTwitter(string screenName)
        {
            SqlServerTwitter resultado = new SqlServerTwitter();
            ConexionSqlServer.cerrarConexion();
            return resultado.buscarUsuario(screenName);
        }
        static public int setAgregarTwitter(Twitter usuario)
        {
            SqlServerTwitter resultado = new SqlServerTwitter();
            int respuesta= resultado.agregarUsuario(usuario);
            ConexionSqlServer.cerrarConexion();
            return respuesta;
        }
        static public int setNuevoUsuario(Usuario usuario)
        {
            SqlServerUsuario resultado = new SqlServerUsuario();
            int respuesta= resultado.agregarUsuario(usuario);
            ConexionSqlServer.cerrarConexion();
            return respuesta;
        }

        static public List<Producto> getBusquedaProducto(string busqueda)
        {
            SqlServerProducto lista = new SqlServerProducto();
            List<Producto> producto= lista.busquedaProductos(busqueda);
            ConexionSqlServer.cerrarConexion();
            return producto;
        }
        static public List<Producto> getBusquedaProductoConCategoria(string categoriaProducto, string busqueda)
        {
            SqlServerProducto lista = new SqlServerProducto();
            List<Producto> producto= lista.busquedaProductos(categoriaProducto, busqueda);
            ConexionSqlServer.cerrarConexion();
            return producto;
        }
        static public List<Categoria> getListaCategoria()
        {
            SqlServerCategoria lista = new SqlServerCategoria();
            List<Categoria> categoria= lista.categorias();
            ConexionSqlServer.cerrarConexion();
            return categoria;
        }

        static public int setCompra(Compra compra, int idUsuario)
        {
            SqlServerCompra resultado = new SqlServerCompra();
            int respuesta= resultado.agregarCompra(compra, idUsuario);
            ConexionSqlServer.cerrarConexion();
            return respuesta;
        }

        static public Categoria buscarProductoPorCategoria(int idProducto)
        {
            SqlServerCategoria resultado = new SqlServerCategoria();
            Categoria categoria = resultado.buscarCategoriaPorProducto(idProducto);
            ConexionSqlServer.cerrarConexion();
            return categoria;
        }

        static public List<Tag> buscarTagPorProducto(int idproducto)
        {
            SqlServerTag lista = new SqlServerTag();
            List<Tag> tags= lista.buscarTagPorProducto(idproducto);
            ConexionSqlServer.cerrarConexion();
            return tags;
        }

        static public int setCantidadProducto(int idProducto, int cantidadEnExistencia)
        {
            SqlServerProducto resultado = new SqlServerProducto();
            int respuesta= resultado.updateCantidad(idProducto, cantidadEnExistencia);
            ConexionSqlServer.cerrarConexion();
            return respuesta;
        }

        static public List<Producto> getProductos()
        {
            SqlServerProducto lista = new SqlServerProducto();
            List<Producto> producto= lista.consultarProductos();
            ConexionSqlServer.cerrarConexion();
            return producto;
        }

        static public List<Producto> getProductoPorNombre(String nombre)
        {
            SqlServerProducto lista = new SqlServerProducto();
            List<Producto> producto= lista.buscarPorNombre(nombre);
            ConexionSqlServer.cerrarConexion();
            return producto;
        }

        static public List<Producto> getProductoPorCategoria(String nombreCategoria)
        {
            SqlServerProducto lista = new SqlServerProducto();
            List<Producto> producto= lista.buscarPorCategoria(nombreCategoria);
            ConexionSqlServer.cerrarConexion();
            return producto;
        }

        static public Producto getProductoPorDetalleCompra(int idDetalleCompra)
        {
            SqlServerProducto resultado = new SqlServerProducto();
            Producto producto= resultado.buscarPorCompra(idDetalleCompra);
            ConexionSqlServer.cerrarConexion();
            return producto;
        }

        static public int setCalificacion(int idProducto, int idUsuario, Calificacion calificacion)
        {
            SqlServerCalificacion resultado = new SqlServerCalificacion();
            int respuesta= resultado.agregarCalificacion(calificacion, idUsuario, idProducto);
            ConexionSqlServer.cerrarConexion();
            return respuesta;
        }
        static public int setAgregarCompra(Compra compra, int idUsuario)
        {
            SqlServerCompra resultado = new SqlServerCompra();
            int respuesta= resultado.agregarCompra(compra, idUsuario);
            ConexionSqlServer.cerrarConexion();
            return respuesta;
        }

        static public int setEstadoDeCompra(String status, int idCompra)
        {
            SqlServerCompra resultado = new SqlServerCompra();
            int respuesta= resultado.modificarEstadoDeCompra(status, idCompra);
            ConexionSqlServer.cerrarConexion();
            return respuesta;
        }

        static public int setMetodoPago(MetodoPago metodo, int idUsuario)
        {
            SqlServerMetodoPago resultado = new SqlServerMetodoPago();
            int respuesta= resultado.agregarMetodoPago(metodo, idUsuario);
            ConexionSqlServer.cerrarConexion();
            return respuesta;
        }

        static public MetodoPago getMetodoPagoPorCompra(int idCompra)
        {
            SqlServerMetodoPago resultado = new SqlServerMetodoPago();
            MetodoPago respuesta = resultado.consultarMetodosPagoDeCompra(idCompra);
            ConexionSqlServer.cerrarConexion();
            return respuesta;
        }

        static public int setModificarMetodoPago(MetodoPago metodoModificado, int idMetodoActual, int idUsuario)
        {
            SqlServerMetodoPago resultado = new SqlServerMetodoPago();
            int respuesta= resultado.modificarMetodoPago(metodoModificado, idMetodoActual, idUsuario);
            ConexionSqlServer.cerrarConexion();
            return respuesta;
        }

        static public int setAgregarDetalleDireccion(int idUsuario, int idDireccion, Direccion direccion)
        {
            SqlServerDireccion resultado = new SqlServerDireccion();
            int respuesta= resultado.AgregarDireccionUsuario(idUsuario, idDireccion, direccion);
            ConexionSqlServer.cerrarConexion();
            return respuesta;
        }

        static public Direccion getDireccionDeCompra(int idCompra)
        {
            SqlServerDireccion resultado = new SqlServerDireccion();
            Direccion direccion = resultado.ConsultarDireccionDeCompra(idCompra);
            ConexionSqlServer.cerrarConexion();
            return direccion;
        }

        static public List<Direccion> getEstado()
        {
            SqlServerDireccion resultado = new SqlServerDireccion();
            List<Direccion> lista= resultado.consultarEstados();
            ConexionSqlServer.cerrarConexion();
            return lista;
        }

        static public List<Direccion> getCiudad(int idEstado)
        {
            SqlServerDireccion resultado = new SqlServerDireccion();
            List<Direccion> lista = resultado.consultarCiudad(idEstado);
            ConexionSqlServer.cerrarConexion();
            return lista;
        }
        static public Usuario getUsuario(int idUsuario)
        {
            SqlServerUsuario resultado = new SqlServerUsuario();
            Usuario usuario = resultado.consultarUsuario(idUsuario);
            ConexionSqlServer.cerrarConexion();
            return usuario;
        }
        static public Usuario getUsuario(string mail, int codigoActivacion)
        {
            SqlServerUsuario resultado = new SqlServerUsuario();
            Usuario usuario = resultado.consultarUsuario(mail, codigoActivacion);
            ConexionSqlServer.cerrarConexion();
            return usuario;
        }

        static public Usuario getUsuario(string mail)
        {
            SqlServerUsuario resultado = new SqlServerUsuario();
            Usuario usuario = resultado.consultarUsuario(mail);
            ConexionSqlServer.cerrarConexion();
            return usuario;
        }


        static public int setUsuario(Usuario usuarioModificado, int idUsuario)
        {
            SqlServerUsuario resultado = new SqlServerUsuario();
            int respuesta= resultado.modificarUsuario(usuarioModificado, idUsuario);
            ConexionSqlServer.cerrarConexion();
            return respuesta;
        }

    }
}