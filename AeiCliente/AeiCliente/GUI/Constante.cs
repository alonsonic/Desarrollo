using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeiCliente.GUI
{
    static class Constante
    {
        static string ip = "localhost";

        public static string Ip
        {
            get { return Constante.ip; }
            set { Constante.ip = value; }
        }

    }
}
