using AeiCliente.ServicioAEI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeiCliente
{
    public static class BufferUsuario
    {
        static Usuario bufferUsuario = null;

        public static Usuario Usuario
        {
            get { return BufferUsuario.bufferUsuario; }
            set { BufferUsuario.bufferUsuario = value; }
        }

        static public bool isConectado(){

            if (bufferUsuario == null)
                return false;
            else
                return true;
        }

        static public void agregarUsuario(){
        
            
        
        }

        static public void comprar(Producto compra)
        {
            //bufferUsuario.Carrito
        }

    }
}
