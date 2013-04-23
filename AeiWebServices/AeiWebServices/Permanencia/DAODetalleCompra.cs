using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeiWebServices.Permanencia
{
    interface DAODetalleCompra
    {
        List<DetalleCompra> buscarDetalleCompra(int idCompra);
        int agregarDetalleCompra(int idCompra, DetalleCompra detalleCompra);
    }
}
