using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AeiWebServices.Permanencia
{
    public interface DAOTag
    {
        List<Tag> buscarTagPorProducto(int idproducto);
    }
}