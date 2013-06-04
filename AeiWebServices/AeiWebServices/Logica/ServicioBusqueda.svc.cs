using AeiWebServices.Permanencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AeiWebServices.Logica
{
    public class ServicioBusqueda : IServicioBusqueda
    {
        public List<Producto> BusquedaProducto(string busqueda, int pagina, int numeroArticulo)
        {
            logicaBusqueda resultado = new logicaBusqueda();
            return resultado.clasificarBusqueda(busqueda, pagina, numeroArticulo);
        }        
    }

}
