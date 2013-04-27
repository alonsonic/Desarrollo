using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeiWebServices.Permanencia
{
    interface DAODetalleCompra
    {
        DetalleCompra buscarEnMiCarrito(int idProducto, int idUsuario);
        List<DetalleCompra> buscarDetalleCompra(int idCompra);
        int agregarDetalleCompra(int idCompra, DetalleCompra detalleCompra);
        int borrarDetalleCompra(Compra compra, DetalleCompra detalle);
    }
}
