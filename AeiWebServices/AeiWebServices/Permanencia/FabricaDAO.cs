using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AeiWebServices.Permanencia
{
    public class FabricaDAO
    {
        public List<Categoria> getListaCategoria()
        {
            SqlServerCategoria lista = new SqlServerCategoria();
            return lista.categorias();
        }

        public int setCompra(Compra compra)
        {
            SqlServerCompra resultado = new SqlServerCompra();
            return resultado.agregarCompra(compra);
        }

        public Categoria buscarProductoPorCategoria(int idProducto)
        {
            SqlServerCategoria resultado = new SqlServerCategoria();
            return resultado.buscarCategoriaPorProducto(idProducto);
        }

        public List<Tag> buscarTagPorProducto(int idproducto)
        {
            SqlServerTag lista = new SqlServerTag();
            return lista.buscarTagPorProducto(idproducto);
        }

        public int setCantidadProducto(int idProducto, int cantidadEnExistencia)
        {
            SqlServerProducto resultado = new SqlServerProducto();
            return resultado.updateCantidad(idProducto, cantidadEnExistencia);
        }

        public List<Producto> getProductos()
        {
            SqlServerProducto lista = new SqlServerProducto();
            return lista.consultarProductos();
        }

        public List<Producto> getProductoPorNombre(String nombre)
        {
            SqlServerProducto lista = new SqlServerProducto();
            return lista.buscarPorNombre(nombre);
        }

        public List<Producto> getProductoPorCategoria(String nombreCategoria)
        {
            SqlServerProducto lista = new SqlServerProducto();
            return lista.buscarPorCategoria(nombreCategoria);
        }

        public Producto getProductoPorDetalleCompra(int idDetalleCompra)
        {
            SqlServerProducto resultado = new SqlServerProducto();
            return resultado.buscarPorCompra(idDetalleCompra);
        }

        public int setCalificacion(int idProducto, int idUsuario, Calificacion calificacion)
        {
            Usuario user = new Usuario();
            SqlServerCalificacion resultado = new SqlServerCalificacion();
            return resultado.agregarCalificacion(calificacion,idUsuario,idProducto);
        }
        public int setAgregarCompra(Compra compra)
        {
            SqlServerCompra resultado = new SqlServerCompra();
            Usuario user = new Usuario();
            return resultado.agregarCompra(compra);
        }

        public int setEstadoDeCompra(String status, int idCompra)
        {
            SqlServerCompra resultado = new SqlServerCompra();
            return resultado.modificarEstadoDeCompra(status, idCompra);
        }

        public int setMetodoPago(MetodoPago metodo, int idUsuario)
        {
            SqlServerMetodoPago resultado = new SqlServerMetodoPago();
            return resultado.agregarMetodoPago(metodo, idUsuario);
        }

        public MetodoPago getMetodoPagoPorCompra(int idCompra)
        {
            SqlServerMetodoPago resultado = new SqlServerMetodoPago();
            return resultado.consultarMetodosPagoDeCompra(idCompra);
        }

        public int setModificarMetodoPago(MetodoPago metodoModificado, int idMetodoActual, int idUsuario)
        {
            SqlServerMetodoPago resultado = new SqlServerMetodoPago();
            return resultado.modificarMetodoPago(metodoModificado, idMetodoActual, idUsuario);
        }

        public int setAgregarDetalleDireccion(int idUsuario, int idDireccion, Direccion direccion)
        {
            SqlServerDireccion resultado = new SqlServerDireccion();
            return resultado.AgregarDireccionUsuario(idUsuario, idDireccion, direccion);
        }
        public Direccion getDireccionDeCompra(int idCompra)
        {
            SqlServerUsuario resultado = new SqlServerUsuario();
            return resultado.ConsultarDireccionDeCompra(3);
        }

        public Usuario getUsuario(string mail, string codigoActivacion)
        {
            SqlServerUsuario resultado = new SqlServerUsuario();
            return resultado.consultarUsuario(mail, codigoActivacion);
        }

        public int setUsuario(Usuario usuarioModificado, int idUsuario)
        {
            SqlServerUsuario resultado = new SqlServerUsuario();
            return resultado.modificarUsuario(usuarioModificado, idUsuario);
        }

    }
}