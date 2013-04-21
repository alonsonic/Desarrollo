using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using AeiWebServices.Permanencia;

namespace AeiWebServices.Logica
{
      public class ServicioProducto : IServicioProducto
    {
          public List<Producto> BuscarProductoPorCategoria(string nombre)
          {
              return FabricaDAO.getProductoPorCategoria(nombre);
          }

          public List<Producto> BusquedaProductoConCategoria(string categoriaProducto, string busqueda)
          {
              return FabricaDAO.getBusquedaProductoConCategoria(categoriaProducto,busqueda);
          }

          public List<Producto> BusquedaProducto(string busqueda)
          {
              return FabricaDAO.getBusquedaProducto(busqueda);
          }

          public List<Categoria> BuscarTodasLasCategorias()
          {
              return FabricaDAO.getListaCategoria();
          }


    }
}
