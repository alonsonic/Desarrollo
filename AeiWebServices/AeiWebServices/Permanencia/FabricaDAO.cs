using AeiWebServices.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AeiWebServices.Permanencia
{
    public static class FabricaDAO
    {
        static public List<Direccion> getListaDireccion(int idUsuario)
        {
            SqlServerDireccion resultado = new SqlServerDireccion();
            return resultado.ConsultarDireccion(idUsuario);
        }

        static public List<DetalleCompra> getListaProductos(int idCompra)
        {
            SqlServerDetalleCompra resultado = new SqlServerDetalleCompra();
            return resultado.buscarDetalleCompra(idCompra);
        }
        static public Compra getCarrito(int idUsuario)
        {
            SqlServerCompra resultado = new SqlServerCompra();
            return resultado.consultarCarrito(idUsuario);
        }
        static public int setAgregarDetalleCompra(int idCompra, DetalleCompra detalleCompra)
        {
            SqlServerDetalleCompra resultado = new SqlServerDetalleCompra();
            return resultado.agregarDetalleCompra(idCompra,detalleCompra);
        }
        static public List<Calificacion> getCalificaciones(int idProducto)
        {
            SqlServerCalificacion resultado = new SqlServerCalificacion();
            return resultado.consultarCalificacionesPorProducto(idProducto);
        }
        static public Twitter getUsuarioTwitter(string screenName)
        {
            SqlServerTwitter resultado = new SqlServerTwitter();
            return resultado.buscarUsuario(screenName);
        }
        static public int setAgregarTwitter(Twitter usuario)
        {
            SqlServerTwitter resultado = new SqlServerTwitter();
            return resultado.agregarUsuario(usuario);
        }
        static public int setNuevoUsuario(Usuario usuario)
        {
            SqlServerUsuario resultado = new SqlServerUsuario();
            return resultado.agregarUsuario(usuario);
        }

        static public List<Producto> getBusquedaProducto(string busqueda)
        {
            SqlServerProducto lista = new SqlServerProducto();
            return lista.busquedaProductos(busqueda);
        }
        static public List<Producto> getBusquedaProductoConCategoria(string categoriaProducto, string busqueda)
        {
            SqlServerProducto lista = new SqlServerProducto();
            return lista.busquedaProductos(categoriaProducto, busqueda);
        }
        static public List<Categoria> getListaCategoria()
        {
            SqlServerCategoria lista = new SqlServerCategoria();
            return lista.categorias();
        }

        static public int setCompra(Compra compra, int idUsuario)
        {
            SqlServerCompra resultado = new SqlServerCompra();
            return resultado.agregarCompra(compra, idUsuario);
        }

        static public Categoria buscarProductoPorCategoria(int idProducto)
        {
            SqlServerCategoria resultado = new SqlServerCategoria();
            return resultado.buscarCategoriaPorProducto(idProducto);
        }

        static public List<Tag> buscarTagPorProducto(int idproducto)
        {
            SqlServerTag lista = new SqlServerTag();
            return lista.buscarTagPorProducto(idproducto);
        }

        static public int setCantidadProducto(int idProducto, int cantidadEnExistencia)
        {
            SqlServerProducto resultado = new SqlServerProducto();
            return resultado.updateCantidad(idProducto, cantidadEnExistencia);
        }

        static public List<Producto> getProductos()
        {
            SqlServerProducto lista = new SqlServerProducto();
            return lista.consultarProductos();
        }

        static public List<Producto> getProductoPorNombre(String nombre)
        {
            SqlServerProducto lista = new SqlServerProducto();
            return lista.buscarPorNombre(nombre);
        }

        static public List<Producto> getProductoPorCategoria(String nombreCategoria)
        {
            SqlServerProducto lista = new SqlServerProducto();
            return lista.buscarPorCategoria(nombreCategoria);
        }

        static public Producto getProductoPorDetalleCompra(int idDetalleCompra)
        {
            SqlServerProducto resultado = new SqlServerProducto();
            return resultado.buscarPorCompra(idDetalleCompra);
        }

        static public int setCalificacion(int idProducto, int idUsuario, Calificacion calificacion)
        {
            Usuario user = new Usuario();
            SqlServerCalificacion resultado = new SqlServerCalificacion();
            return resultado.agregarCalificacion(calificacion,idUsuario,idProducto);
        }
        static public int setAgregarCompra(Compra compra, int idUsuario)
        {
            SqlServerCompra resultado = new SqlServerCompra();
            Usuario user = new Usuario();
            return resultado.agregarCompra(compra, idUsuario);
        }

        static public int setEstadoDeCompra(String status, int idCompra)
        {
            SqlServerCompra resultado = new SqlServerCompra();
            return resultado.modificarEstadoDeCompra(status, idCompra);
        }

        static public int setMetodoPago(MetodoPago metodo, int idUsuario)
        {
            SqlServerMetodoPago resultado = new SqlServerMetodoPago();
            return resultado.agregarMetodoPago(metodo, idUsuario);
        }

        static public MetodoPago getMetodoPagoPorCompra(int idCompra)
        {
            SqlServerMetodoPago resultado = new SqlServerMetodoPago();
            return resultado.consultarMetodosPagoDeCompra(idCompra);
        }

        static public int setModificarMetodoPago(MetodoPago metodoModificado, int idMetodoActual, int idUsuario)
        {
            SqlServerMetodoPago resultado = new SqlServerMetodoPago();
            return resultado.modificarMetodoPago(metodoModificado, idMetodoActual, idUsuario);
        }

        static public int setAgregarDetalleDireccion(int idUsuario, int idDireccion, Direccion direccion)
        {
            SqlServerDireccion resultado = new SqlServerDireccion();
            return resultado.AgregarDireccionUsuario(idUsuario, idDireccion, direccion);
        }

        static public Direccion getDireccionDeCompra(int idCompra)
        {
            SqlServerDireccion resultado = new SqlServerDireccion();
            return resultado.ConsultarDireccionDeCompra(idCompra);
        }

        static public List<Direccion> getEstado()
        {
            SqlServerDireccion resultado = new SqlServerDireccion();
            return resultado.consultarEstados();
        }

        static public List<Direccion> getCiudad(int idEstado)
        {
            SqlServerDireccion resultado = new SqlServerDireccion();
            return resultado.consultarCiudad(idEstado);
        }
        static public Usuario getUsuario(int idUsuario)
        {
            SqlServerUsuario resultado = new SqlServerUsuario();
            return resultado.consultarUsuario(idUsuario);
        }
        static public Usuario getUsuario(string mail, int codigoActivacion)
        {
            SqlServerUsuario resultado = new SqlServerUsuario();
            return resultado.consultarUsuario(mail, codigoActivacion);
        }

        static public Usuario getUsuario(string mail)
        {
            SqlServerUsuario resultado = new SqlServerUsuario();
            return resultado.consultarUsuario(mail);
        }


        static public int setUsuario(Usuario usuarioModificado, int idUsuario)
        {
            SqlServerUsuario resultado = new SqlServerUsuario();
            return resultado.modificarUsuario(usuarioModificado, idUsuario);
        }

    }
}