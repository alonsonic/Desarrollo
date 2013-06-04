using AeiWebServices.Permanencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AeiWebServices.Logica
{
    public class logicaBusqueda
    {
        public List<Producto> clasificarBusqueda(string busqueda, int pagina, int numeroArticulo)
        {
            if (busqueda == null) return null;
            else if (busqueda.Equals("") || busqueda.Equals(" ")) return FabricaDAO.getProductos(pagina,numeroArticulo);
            else return FabricaDAO.getBusquedaProducto(busqueda, pagina, numeroArticulo);
        }
    }
}