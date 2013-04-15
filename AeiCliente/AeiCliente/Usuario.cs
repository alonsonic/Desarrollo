using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeiCliente
{
    public static class Usuario
    {

        static string pasaporte = null;
        static string correo = null;
        static DateTime fechaNac;
        static string direccion = null;

        static public string Pasaporte
        {
            get { return pasaporte; }
            set { pasaporte = value; }
        }
        

        static public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }
        

        static public DateTime FechaNac
        {
            get { return fechaNac; }
            set { fechaNac = value; }
        }

        static public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        static public bool isConectado(){

            if (pasaporte == null)
                return false;
            else
                return true;
        }
        

    }
}
