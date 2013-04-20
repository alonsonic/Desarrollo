using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using AeiWebServices.Permanencia;

namespace AeiWebServices.Logica
{
    public class ServicioDetalleProducto : IServicioDetalleProducto
    {
        public Producto buscarInformacionProducto(int idProducto)
        {
            return FabricaDAO.getProducto(idProducto);
        }
    }
}