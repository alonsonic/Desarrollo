using AeiWebServices.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AeiWebServices.Permanencia
{
    public static class FabricaDAO
    {
        //static public int setCantidadProducto(int idProducto, int cantidad)
        //{
        //    SqlServerCompra resultado = new SqlServerCompra();
        //    return resultado.cambiarCantidadProducto(idProducto, cantidad);
        //}

        static public int modificarDireccion(Direccion direccionModificada)
        {
            SqlServerDireccion resultado = new SqlServerDireccion();
            return resultado.modificarDireccion(direccionModificada.Id, direccionModificada);
        }
     
        static public Producto getCheckearDisponibilidadProducto(int idProducto)
        {

            return null;
        }
        static public int setMontoTotalCarrito(Compra compra, float montoNuevo)
        {
            SqlServerCompra resultado= new SqlServerCompra();
            return resultado.modificarMontoCarrito(compra, montoNuevo);
        }
        static public DetalleCompra getDetalleCompraCarrito(int idProducto, int idUsuario)
        {
            SqlServerDetalleCompra resultado = new SqlServerDetalleCompra();
            return resultado.buscarEnMiCarrito(idProducto, idUsuario);
        }
        static public int setEliminarDetalleCarrito(Compra compra, DetalleCompra detalle)
        {
            SqlServerCompra resultado = new SqlServerCompra();
            int respuesta = resultado.borrarDetalleCompra(compra, detalle);
            return respuesta;
        }
        static public List<Direccion> getListaDireccion(int idUsuario)
        {
            SqlServerDireccion resultado = new SqlServerDireccion();
            List<Direccion> direccion = resultado.ConsultarDireccion(idUsuario);             
            return direccion;
        }

        static public List<DetalleCompra> getListaProductos(int idCompra)
        {
            SqlServerDetalleCompra resultado = new SqlServerDetalleCompra();
            List<DetalleCompra> detalleCompra= resultado.buscarDetalleCompra(idCompra);             
            return detalleCompra;
        }
        static public Compra getCarrito(int idUsuario)
        {
            SqlServerCompra resultado = new SqlServerCompra();
            Compra compra= resultado.consultarCarrito(idUsuario);
             
            return compra;
        }
        static public int setAgregarDetalleCompra(int idCompra, DetalleCompra detalleCompra)
        {
            SqlServerDetalleCompra resultado = new SqlServerDetalleCompra();
            int respuesta= resultado.agregarDetalleCompra(idCompra, detalleCompra);
             
            return respuesta;
        }
        static public List<Calificacion> getCalificaciones(int idProducto)
        {
            SqlServerCalificacion resultado = new SqlServerCalificacion();
            List<Calificacion> calificacion= resultado.consultarCalificacionesPorProducto(idProducto);
             
            return calificacion;
        }
        static public Twitter getUsuarioTwitter(string screenName)
        {
            SqlServerTwitter resultado = new SqlServerTwitter();
             
            return resultado.buscarUsuario(screenName);
        }
        static public int setAgregarTwitter(Twitter usuario)
        {
            SqlServerTwitter resultado = new SqlServerTwitter();
            int respuesta= resultado.agregarUsuario(usuario);
             
            return respuesta;
        }
        static public int setNuevoUsuario(Usuario usuario)
        {
            SqlServerUsuario resultado = new SqlServerUsuario();
            int respuesta= resultado.agregarUsuario(usuario);
             
            return respuesta;
        }

        static public List<Producto> getBusquedaProducto(string busqueda)
        {
            SqlServerProducto lista = new SqlServerProducto();
            List<Producto> producto= lista.busquedaProductos(busqueda);
             
            return producto;
        }
        static public List<Producto> getBusquedaProductoConCategoria(string categoriaProducto, string busqueda)
        {
            SqlServerProducto lista = new SqlServerProducto();
            List<Producto> producto= lista.busquedaProductos(categoriaProducto, busqueda);
             
            return producto;
        }
        static public List<Categoria> getListaCategoria()
        {
            SqlServerCategoria lista = new SqlServerCategoria();
            List<Categoria> categoria= lista.categorias();
             
            return categoria;
        }

        static public int setCompra(Compra compra, int idUsuario)
        {
            SqlServerCompra resultado = new SqlServerCompra();
            int respuesta= resultado.agregarCompra(compra, idUsuario);
             
            return respuesta;
        }

        static public Categoria buscarProductoPorCategoria(int idProducto)
        {
            SqlServerCategoria resultado = new SqlServerCategoria();
            Categoria categoria = resultado.buscarCategoriaPorProducto(idProducto);
             
            return categoria;
        }

        static public List<Tag> buscarTagPorProducto(int idproducto)
        {
            SqlServerTag lista = new SqlServerTag();
            List<Tag> tags= lista.buscarTagPorProducto(idproducto);
             
            return tags;
        }

        static public int setCantidadProducto(int idProducto, int cantidadEnExistencia)
        {
            SqlServerProducto resultado = new SqlServerProducto();
            int respuesta= resultado.updateCantidad(idProducto, cantidadEnExistencia);
             
            return respuesta;
        }

        static public List<Producto> getProductos()
        {
            SqlServerProducto lista = new SqlServerProducto();
            List<Producto> producto= lista.consultarProductos();
             
            return producto;
        }

        static public List<Producto> getProductoPorNombre(String nombre)
        {
            SqlServerProducto lista = new SqlServerProducto();
            List<Producto> producto= lista.buscarPorNombre(nombre);
             
            return producto;
        }

        static public List<Producto> getProductoPorCategoria(String nombreCategoria)
        {
            SqlServerProducto lista = new SqlServerProducto();
            List<Producto> producto= lista.buscarPorCategoria(nombreCategoria);
             
            return producto;
        }

        static public Producto getProductoPorDetalleCompra(int idDetalleCompra)
        {
            SqlServerProducto resultado = new SqlServerProducto();
            Producto producto= resultado.buscarPorCompra(idDetalleCompra);
             
            return producto;
        }

        static public int setCalificacion(int idProducto, int idUsuario, Calificacion calificacion)
        {
            SqlServerCalificacion resultado = new SqlServerCalificacion();
            int respuesta= resultado.agregarCalificacion(calificacion, idUsuario, idProducto);
             
            return respuesta;
        }
        static public int setAgregarCompra(Compra compra, int idUsuario)
        {
            SqlServerCompra resultado = new SqlServerCompra();
            int respuesta= resultado.agregarCompra(compra, idUsuario);
             
            return respuesta;
        }

        static public int setEstadoDeCompra(String status, int idCompra)
        {
            SqlServerCompra resultado = new SqlServerCompra();
            int respuesta= resultado.modificarEstadoDeCompra(status, idCompra);
             
            return respuesta;
        }

        static public int setMetodoPago(MetodoPago metodo, int idUsuario)
        {
            SqlServerMetodoPago resultado = new SqlServerMetodoPago();
            int respuesta= resultado.agregarMetodoPago(metodo, idUsuario);
             
            return respuesta;
        }

        static public MetodoPago getMetodoPagoPorCompra(int idCompra)
        {
            SqlServerMetodoPago resultado = new SqlServerMetodoPago();
            MetodoPago respuesta = resultado.consultarMetodosPagoDeCompra(idCompra);
             
            return respuesta;
        }

        static public int setModificarMetodoPago(MetodoPago metodoModificado, int idMetodoActual, int idUsuario)
        {
            SqlServerMetodoPago resultado = new SqlServerMetodoPago();
            int respuesta= resultado.modificarMetodoPago(metodoModificado, idMetodoActual, idUsuario);
             
            return respuesta;
        }

        static public int setAgregarDetalleDireccion(int idUsuario, int idDireccion, Direccion direccion)
        {
            SqlServerDireccion resultado = new SqlServerDireccion();
            int respuesta= resultado.AgregarDireccionUsuario(idUsuario, idDireccion, direccion);
             
            return respuesta;
        }

        static public Direccion getDireccionDeCompra(int idCompra)
        {
            SqlServerDireccion resultado = new SqlServerDireccion();
            Direccion direccion = resultado.ConsultarDireccionDeCompra(idCompra);
             
            return direccion;
        }

        static public List<Direccion> getEstado()
        {
            SqlServerDireccion resultado = new SqlServerDireccion();
            List<Direccion> lista= resultado.consultarEstados();
             
            return lista;
        }

        static public List<Direccion> getCiudad(int idEstado)
        {
            SqlServerDireccion resultado = new SqlServerDireccion();
            List<Direccion> lista = resultado.consultarCiudad(idEstado);
             
            return lista;
        }
        static public Usuario getUsuario(int idUsuario)
        {
            SqlServerUsuario resultado = new SqlServerUsuario();
            Usuario usuario = resultado.consultarUsuario(idUsuario);
             
            return usuario;
        }
        static public Usuario getUsuario(string mail, int codigoActivacion)
        {
            SqlServerUsuario resultado = new SqlServerUsuario();
            Usuario usuario = resultado.consultarUsuario(mail, codigoActivacion);
             
            return usuario;
        }

        static public Usuario getUsuario(string mail)
        {
            SqlServerUsuario resultado = new SqlServerUsuario();
            Usuario usuario = resultado.consultarUsuario(mail);
             
            return usuario;
        }


        static public int setUsuario(Usuario usuarioModificado, int idUsuario)
        {
            SqlServerUsuario resultado = new SqlServerUsuario();
            int respuesta= resultado.modificarUsuario(usuarioModificado, idUsuario);
             
            return respuesta;
        }

    }
}