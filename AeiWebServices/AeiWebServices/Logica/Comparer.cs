using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AeiWebServices.Logica
{
    public class Comparer : IEqualityComparer<Producto>
    {
        public bool Equals(Producto producto1, Producto producto2)
        {
            return producto1.Id == producto2.Id;
        }

        public int GetHashCode(Producto obj)
        {
            return (int)obj.Id;
        }
    }
}