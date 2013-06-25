using AeiMobile.ServicioAEI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AeiMobile
{
    public static class BufferUsuario
    {
        static Usuario bufferUsuario = null;

        public static Usuario Usuario
        {
            get { return BufferUsuario.bufferUsuario; }
            set { BufferUsuario.bufferUsuario = value; }
        }


    }
}
