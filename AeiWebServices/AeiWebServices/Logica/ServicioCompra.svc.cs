using AeiWebServices.Permanencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AeiWebServices.Logica
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioCompra" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServicioCompra.svc o ServicioCompra.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioCompra : IServicioCompra
    {
        public Compra getCarrito (int idusuario) 
        {
            return FabricaDAO.getCarrito(idusuario);
        }
    }
}
