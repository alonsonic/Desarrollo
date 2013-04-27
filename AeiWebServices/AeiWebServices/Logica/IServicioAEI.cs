using AeiWebServices.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AeiWebServices.Logica
{
    [ServiceContract]
    public interface IServicioAEI
    {
        [OperationContract]
        Usuario agregarMetodoPago(MetodoPago metodo, Usuario usuario);

        [OperationContract]
        int modificarDireccion(Direccion direccionModificada);

        [OperationContract]
        Usuario checkout(MetodoPago metodo, Direccion direccion, Usuario usuario);

        [OperationContract]
        bool disponibilidadProductos(List<DetalleCompra> detalle);

        [OperationContract]
        Boolean checkearProductoCarrito(Usuario usuario, Producto producto);

        [OperationContract]
        Usuario borrarDetalleCarrito(Usuario usuario, DetalleCompra detalle);

        [OperationContract]
        int enviarCorreoDeModificacion(Usuario usuario);

        [OperationContract]
        int enviarCorreoDeBienvenida(Usuario usuario);

        [OperationContract]
        int modificarUsuario(Usuario usuario);

        [OperationContract]
        Usuario ConsultarUsuario(string mail);

        [OperationContract]
        Usuario agregarUsuario(string nombre, string apellido, string pasaporte, string mail, string fechaNacimiento);

        [OperationContract]
        Twitter getTwitter(string screenName);

        [OperationContract]
        int agregarTwitter(string idUsuario, string screenName, string OauthToken, string OauthTokenSecret);

        [OperationContract]
        List<Calificacion> buscarCalificacionProducto(int idProducto);

        [OperationContract]
        List<Producto> BuscarProductoPorCategoria(string nombre);

        [OperationContract]
        List<Producto> BusquedaProductoConCategoria(string categoriaProducto, string busqueda);

        [OperationContract]
        List<Producto> BusquedaProducto(string busqueda);

        [OperationContract]
        List<Categoria> BuscarTodasLasCategorias();

        [OperationContract]
        List<Direccion> consultarEstados();

        [OperationContract]
        List<Direccion> consultarCiudad(int idEstado);

        [OperationContract]
        int agregarDireccionUsuario(int idUsuario, int idDireccion, string descripcion, int codigoPostal);

        [OperationContract]
        Usuario agregarCarrito(Usuario usuario, DetalleCompra detalleCompra);

        [OperationContract]
        List<Direccion> buscarDireccionUsuario(int idUsuario);

    }
}
