using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using AeiWebServices.Permanencia;
using AeiWebServices.Dominio;

namespace AeiWebServices.Logica
{
    public class ServiceUsuario : IServicioUsuario
    {
        public Usuario ConsultarUsuario(string mail)
        {
            Usuario usuario=FabricaDAO.getUsuario(mail);
            usuario.Carrito = FabricaDAO.getCarrito(usuario.Id);
            if (usuario.Carrito!=null) usuario.Carrito.Productos = FabricaDAO.getListaProductos(usuario.Carrito.Id);
            return usuario;
        }

        public Usuario agregarUsuario(string nombre, string apellido, string pasaporte, string mail, string fechaNacimiento)
        {
            string fechaRegistro = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString()+"-"+DateTime.Now.Day.ToString();
         
            Usuario usuario = new Usuario(1, nombre, apellido, pasaporte, mail, DateTime.ParseExact("1990-12-20", "yyyy-MM-dd", null), DateTime.ParseExact(fechaNacimiento, "yyyy-MM-dd", null), "I", null, null, null, null, 0);
            if  (FabricaDAO.setNuevoUsuario(usuario)==1) 
            {
                return FabricaDAO.getUsuario(usuario.Email);
            }
            return null;
        }


    }
}
