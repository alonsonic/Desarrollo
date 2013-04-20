using AeiWebServices.Permanencia;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AeiWebServices
{

   public class ServicioDAO : IServicioDAO
    {
        public string GetData(int value)
        {
            return null;
        }
        public List<Categoria> getListaCategoria() 
        {
            SqlServerCategoria lista = new SqlServerCategoria();
            return lista.categorias();
        }

        public int setCompra(Compra compra)
        {
            SqlServerUsuario resultado = new SqlServerUsuario();
            return resultado.agregarCompra(compra);
        }

        public Categoria buscarProductoPorCategoria(int idProducto) 
        { 
            SqlServerCategoria resultado= new SqlServerCategoria();
            return resultado.buscarCategoriaPorProducto(idProducto);
        }

        public List<Tag> buscarTagPorProducto(int idproducto)
        {
            SqlServerTag lista = new SqlServerTag();
            return lista.buscarTagPorProducto(idproducto);
        }

        public int setCantidadProducto(int idProducto, int cantidadEnExistencia)
        {
            SqlServerUsuario resultado= new SqlServerUsuario();
            return resultado.updateCantidad(idProducto, cantidadEnExistencia);
        }

        public List<Producto> getProductos() 
        {
            SqlServerUsuario lista = new SqlServerUsuario();
            return lista.consultarProductos();
        }

        public List<Producto> getProductoPorNombre(String nombre)
        {
            SqlServerUsuario lista = new SqlServerUsuario();
            return lista.buscarPorNombre(nombre);
        }

        public List<Producto> getProductoPorCategoria(String nombreCategoria)
        {
            SqlServerUsuario lista = new SqlServerUsuario();
            return lista.buscarPorCategoria(nombreCategoria);
        }

        public Producto getProductoPorDetalleCompra(int idDetalleCompra)
        {
            SqlServerUsuario resultado = new SqlServerUsuario();
            return resultado.buscarPorCompra(idDetalleCompra);
        }

        public int setCalificacion(int idProducto,Calificacion calificacion) 
        {
            Usuario user= new Usuario();
            SqlServerUsuario resultado = new SqlServerUsuario();
            user=resultado.consultarUsuario("alonsonic@hotmail.com","2222");            
            Calificacion cal = new Calificacion(2, 100, "me gusto 3", DateTime.ParseExact("2013-03-03", "yyyy-MM-dd", null),user);
            return resultado.agregarCalificacion(idProducto,cal);
        }
        public int setAgregarCompra(Compra compra)
        {             
            SqlServerUsuario resultado = new SqlServerUsuario();
            Usuario user= new Usuario();
            //user=resultado.consultarUsuario("alonsonic@hotmail.com","2222");
            //Compra c = new Compra(1, 200, DateTime.ParseExact("2013-03-03", "yyyy-MM-dd", null), DateTime.ParseExact("2013-03-03", "yyyy-MM-dd", null), "C", user.MetodosPago[0], null, user.Direcciones[0]);
            return resultado.agregarCompra(compra);
        }

       public int setEstadoDeCompra(String status, int idCompra) 
       {
           SqlServerUsuario resultado = new SqlServerUsuario();
           return resultado.modificarEstadoDeCompra(status,idCompra);
       }

       public int setMetodoPago (MetodoPago metodo, int idUsuario)
       {
           SqlServerUsuario resultado = new SqlServerUsuario();
           return resultado.agregarMetodoPago(metodo, idUsuario);
       }

       public MetodoPago getMetodoPagoPorCompra(int idCompra)
       {
           SqlServerUsuario resultado = new SqlServerUsuario();
           return resultado.consultarMetodosPagoDeCompra(idCompra);
       }

       public int setModificarMetodoPago(MetodoPago metodoModificado, int idMetodoActual, int idUsuario)
       {
           SqlServerUsuario resultado = new SqlServerUsuario();
           return resultado.modificarMetodoPago(metodoModificado, idMetodoActual, idUsuario);
       }

       public int setAgregarDetalleDireccion (int idUsuario, int idDireccion, Direccion direccion)
       {
           SqlServerUsuario resultado = new SqlServerUsuario();
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
           Usuario u = new Usuario(1, "Isaac", "A", "a", "a", DateTime.ParseExact("2013-10-03", "yyyy-MM-dd", null), DateTime.ParseExact("2013-10-03", "yyyy-MM-dd", null), "A", null, null, null, null, "11111");
           return resultado.modificarUsuario(u, idUsuario);
       }

    }
}
