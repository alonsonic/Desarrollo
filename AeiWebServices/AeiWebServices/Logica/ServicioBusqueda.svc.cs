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
        public List<Producto> BusquedaProducto(string busqueda, string pagina, string numeroArticulo)
        {
            try
            {
                logicaBusqueda resultado = new logicaBusqueda();
                return resultado.clasificarBusqueda(busqueda, int.Parse(pagina), int.Parse(numeroArticulo));
            }
            catch (Exception e)
            {
                Log.LogInstanciar().Error("Finalizacion de busqueda. No exitosa. Pagina o Numero de articulo con formato no valido."); 
                return null;
            }

        }        
    }

}
