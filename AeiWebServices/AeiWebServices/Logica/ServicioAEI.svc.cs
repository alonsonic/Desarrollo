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
            string fechaRegistro = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();

            Usuario usuario = new Usuario(1, nombre, apellido, pasaporte, mail, DateTime.ParseExact("1990-12-20", "yyyy-MM-dd", null), DateTime.ParseExact(fechaNacimiento, "yyyy-MM-dd", null), "I", null, null, null, null, 0);
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

        public Usuario agregarCarrito(Usuario usuario, DetalleCompra detalleCompra)
        {
            Compra carrito = FabricaDAO.getCarrito(usuario.Id);
            int respuesta = FabricaDAO.setAgregarDetalleCompra(carrito.Id, detalleCompra);
            if (respuesta == 1)
            {
                carrito.AgregarDetallesCompra(detalleCompra);
                usuario.Carrito = carrito;
                return usuario;
            }
            return null;
        }

    }
}
