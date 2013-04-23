using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AeiCliente.ServicioUsuario;
using AeiCliente.ServicioProducto;

namespace AeiCliente
{
    public static class BufferUsuario
    {
        static AeiCliente.ServicioUsuario.Usuario bufferUsuario = null;

        public static AeiCliente.ServicioUsuario.Usuario Usuario
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

        static public void comprar(AeiCliente.ServicioUsuario.Producto compra)
        {
            //bufferUsuario.Carrito
        }

    }
}
