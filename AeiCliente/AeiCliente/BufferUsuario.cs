using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AeiCliente.ServicioUsuario;

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

        static public void comprar(Producto compra, int monto, int cantidad)
        {
            //Necesito un servicio donde envie el producto el usuario la cantidad monto 
            //y se encargue de salvar y disminuir los valores de la cantidad del producto 
            //en la BD

            DetalleCompra detalleCompra = new DetalleCompra();
            detalleCompra.Producto = compra;
            detalleCompra.Monto = monto;
            detalleCompra.Cantidad = cantidad;

            bufferUsuario.Carrito.Productos.Add(detalleCompra);
            //Salvar en BD con servicioDAO
        }

    }
}
