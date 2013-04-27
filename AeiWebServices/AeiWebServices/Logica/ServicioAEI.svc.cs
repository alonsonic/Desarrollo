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

        //public List<Producto> disponibilidadProductos (List<DetalleCompra> detalle)
        //{
        //    List<Producto> resultado= new List<Producto>();
        //    for (int index = 0; index < detalle.Count; index++)
        //    {
        //        detalle[index].Producto
        //        resultado.Add(null);
        //    }
        //    return resultado;
        //}

        public int modificarDireccion(Direccion direccionModificada)
        {
            return FabricaDAO.modificarDireccion(direccionModificada);
        }

        public List<Producto> disponibilidadProductos (List<DetalleCompra> detalle)
        {
            List<Producto> resultado= new List<Producto>();
            for (int index = 0; index < detalle.Count; index++)
            {
                //detalle[index].Producto
               //resultado.Add(null);
            }
            return resultado;
        }

        public Usuario checkout(MetodoPago metodo, Direccion direccion, Usuario usuario)
        {
            Compra compra = usuario.Carrito;
            compra.Direccion = direccion;
            compra.Pago = metodo;
            compra.FechaSolicitud = DateTime.Now;
            compra.Status = "P";

            return usuario;
        }

        public bool checkearProductoCarrito (Usuario usuario, Producto producto)
        {
            DetalleCompra detallecompra = FabricaDAO.getDetalleCompraCarrito(producto.Id, usuario.Id);
            if (detallecompra != null) return true;
            return false;
        }

        public Usuario borrarDetalleCarrito(Usuario usuario, DetalleCompra detalle)
        {
            int respuesta = FabricaDAO.setEliminarDetalleCarrito(usuario.Carrito, detalle);
            return ConsultarUsuario(usuario.Email);
        }

        public int enviarCorreoDeModificacion(Usuario usuario)
        {
            Correo correo = new Correo();
            return correo.enviarCorreoDeModificacion(usuario.Email, usuario.Nombre, usuario.Apellido);
        }

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

        public Usuario agregarCarrito(Usuario usuario, DetalleCompra detalleCompra)
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
                usuario.Carrito.MontoTotal=carrito.MontoTotal + detalleCompra.Monto;
                int respuesta2 = FabricaDAO.setMontoTotalCarrito(carrito, usuario.Carrito.MontoTotal);
                return usuario;
            }
            return null;
        }
    }
}
