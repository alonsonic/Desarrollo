using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using AeiWebServices.Permanencia;

namespace AeiWebServices.Logica
{
    public class ServiceUsuario : IServicioUsuario
    {

        public Usuario ConsultarUsuario(string mail)
        {
            return FabricaDAO.getUsuario(mail);
        }

        public Usuario agregarUsuario(string nombre, string apellido, string pasaporte, string mail, string fechaNacimiento)
        {
            Usuario usuario = new Usuario(1, nombre, apellido, pasaporte, mail, DateTime.ParseExact("1990-12-20", "yyyy-MM-dd", null), DateTime.ParseExact(fechaNacimiento, "yyyy-MM-dd", null), "I", null, null, null, null, 0);
            if  (FabricaDAO.setNuevoUsuario(usuario)==1) 
            {
                return FabricaDAO.getUsuario(usuario.Email);
            }
            return null;
        }

    }
}
