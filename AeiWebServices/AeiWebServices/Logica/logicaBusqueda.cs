using AeiWebServices.Permanencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AeiWebServices.Logica
{
    public class logicaBusqueda
    {
        private string ipWebServerRest = "172.16.66.221";
        private string puertoWebServerRest = "3306";
        private string ipWebServerSOAP = "localhost";
        private string puertoWebServerSOAP = "3030";

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
                    listaProducto = cambiarIpProductoSOAP(listaProducto);
                    return listaProducto;
                }

            }
        }

        private List<Producto> cambiarIpProductoSOAP(List<Producto> listaProducto)
        {
            for (int i = 0; i < listaProducto.Count(); i++)
            {
                listaProducto[i].ImagenDetalle = "http://" + ipWebServerSOAP + ":" + puertoWebServerSOAP +"/"+ listaProducto[i].ImagenDetalle;
            }
            return listaProducto;
        }
    }
}