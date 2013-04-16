using AeiWebServices.Permanencia;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AeiWebServices
{

   public class ServicioDAO : IServicioDAO
    {
        public string GetData(int value)
        {
            return null;
        }
        public List<Categoria> getListaCategoria() 
        {
            SqlServerCategoria lista = new SqlServerCategoria();
            return lista.categorias();
        }

        public int setCompra(Compra compra)
        {
            SqlServerUsuario resultado = new SqlServerUsuario();
            return resultado.agregarCompra(compra);
        }
    }
}
