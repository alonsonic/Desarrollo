using AeiWebServices.Dominio;
using AeiWebServices.Permanencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AeiWebServices.Logica
{

    public class ServicioAEI : IServicioAEI
    {
        public int enviarCorreoDeBienvenida(Usuario usuario)
        {
            Correo correo = new Correo();
            return correo.enviarCorreoDeBienvenida(usuario.Email, usuario.Nombre, usuario.Apellido, usuario.CodigoActivacion);

        }

        public int modificarUsuario(Usuario usuario)
        {
            return FabricaDAO.setUsuario(usuario, usuario.Id);
        }

        public List<Direccion> buscarDireccionUsuario(int idUsuario)
        {
            return FabricaDAO.getListaDireccion(idUsuario);
        }

        public Usuario ConsultarUsuario(string mail)
        {
            Usuario usuario = FabricaDAO.getUsuario(mail);
            if (usuario != null)
            {
                usuario.Carrito = FabricaDAO.getCarrito(usuario.Id);
                if (usuario.Carrito != null) usuario.Carrito.Productos = FabricaDAO.getListaProductos(usuario.Carrito.Id);
            }
            return usuario;
        }

        public Usuario agregarUsuario(string nombre, string apellido, string pasaporte, string mail, string fechaNacimiento)
        {
            DateTime fechaRegistro = DateTime.Today;
            Usuario usuario = new Usuario(1, nombre, apellido, pasaporte, mail, fechaRegistro, DateTime.ParseExact(fechaNacimiento, "yyyy-MM-dd", null), "I", null, null, null, null, 0);
            if (FabricaDAO.setNuevoUsuario(usuario) == 1)
            {
                return FabricaDAO.getUsuario(usuario.Email);
            }
            return null;
        }

        public Twitter getTwitter(string screenName)
        {
            return FabricaDAO.getUsuarioTwitter(screenName);
        }

        public int agregarTwitter(string idUsuario, string screenName, string OauthToken, string OauthTokenSecret)
        {
            Twitter nuevoUsuario = new Twitter(idUsuario, screenName, OauthToken, OauthTokenSecret);
            return FabricaDAO.setAgregarTwitter(nuevoUsuario);
        }

        public List<Producto> BuscarProductoPorCategoria(string nombre)
        {
            return FabricaDAO.getProductoPorCategoria(nombre);
        }

        public List<Producto> BusquedaProductoConCategoria(string categoriaProducto, string busqueda)
        {
            return FabricaDAO.getBusquedaProductoConCategoria(categoriaProducto, busqueda);
        }

        public List<Producto> BusquedaProducto(string busqueda)
        {
            return FabricaDAO.getBusquedaProducto(busqueda);
        }

        public List<Categoria> BuscarTodasLasCategorias()
        {
            return FabricaDAO.getListaCategoria();
        }

        public List<Calificacion> buscarCalificacionProducto(int idProducto)
        {
            return FabricaDAO.getCalificaciones(idProducto);
        }

        public List<Direccion> consultarEstados()
        {
            return FabricaDAO.getEstado();

        }

        public List<Direccion> consultarCiudad(int idEstado)
        {
            return FabricaDAO.getCiudad(idEstado);
        }


        public int agregarDireccionUsuario(int idUsuario, int idDireccion, string descripcion, int codigoPostal)
        {
            Direccion detalleDireccion = new Direccion(-1, null, null, null, codigoPostal, descripcion, "A");

            return FabricaDAO.setAgregarDetalleDireccion(idUsuario, idDireccion, detalleDireccion);

        }

        public Usuario agregarCarrito(Usuario usuario, DetalleCompra detalleCompra, Producto p)
        {
            Compra carrito = FabricaDAO.getCarrito(usuario.Id);
            if (carrito == null)
            {
                DateTime fechaRegistro = DateTime.Today;
                carrito = new Compra(1, detalleCompra.Monto,fechaRegistro,fechaRegistro, "C",null,null,null);
                FabricaDAO.setAgregarCompra(carrito, usuario.Id);
                carrito = FabricaDAO.getCarrito(usuario.Id);
            }
            int respuesta = FabricaDAO.setAgregarDetalleCompra(carrito.Id, detalleCompra);
            if (respuesta == 1)
            {
                if (carrito.Productos == null) carrito.Productos = new List<DetalleCompra>();
                carrito.AgregarDetallesCompra(detalleCompra);
                usuario.Carrito = carrito;
                return usuario;
            }
            return null;
        }

    }
}
