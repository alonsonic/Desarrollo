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

          public Producto buscarInformacionProducto(int idProducto)
          {
              Producto p = new Producto();
              p= FabricaDAO.getProducto(idProducto);
              p.Calificaciones = FabricaDAO.getCalificacionesPorProducto(p.Id);
              return p;
          }
    }
}
