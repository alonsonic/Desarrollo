using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using AeiWebServices.Permanencia;

namespace AeiWebServices.Logica
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioCompra" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServicioCompra.svc o ServicioCompra.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioCompra : IServicioCompra
    {
        public Usuario agregarCarrito(Usuario usuario, DetalleCompra detalleCompra )
        {
            usuario = FabricaDAO.getUsuario(1);
            Producto p = FabricaDAO.getProductoPorDetalleCompra(1);
            detalleCompra = new DetalleCompra(150, 2, p);
            Compra carrito = FabricaDAO.getCarrito(usuario.Id);
            int respuesta= FabricaDAO.setAgregarDetalleCompra(carrito.Id,detalleCompra);
            if (respuesta == 1)
            {
                carrito.AgregarDetallesCompra(detalleCompra);
                usuario.Carrito = carrito;
                return usuario;
            }
            return null;
        }
    }
}
