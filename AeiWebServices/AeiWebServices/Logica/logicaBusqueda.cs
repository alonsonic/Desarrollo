using AeiWebServices.Permanencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AeiWebServices.Logica
{
    public class logicaBusqueda
    {
        private string ipWebServerRest = "192.168.1.1";
        private string puertoWebServerRest = "3306";

        public List<Producto> clasificarBusqueda(string busqueda, int pagina, int numeroArticulo)
        {
            if (busqueda == null)
            {
                return null;
            }
            else if (busqueda.Equals("") || busqueda.Equals(" "))
            {
                return FabricaDAO.getProductos(pagina, numeroArticulo);
            }
            else
            {
                List<Producto> listaProducto = FabricaDAO.getBusquedaProducto(busqueda, pagina, numeroArticulo);
                if (listaProducto == null)
                {
                    return RestLogicaBusqueda.listaProductos(ipWebServerRest, puertoWebServerRest, busqueda, pagina.ToString());
                }
                else
                {
                    return listaProducto;
                }

            }
        }
    }
}