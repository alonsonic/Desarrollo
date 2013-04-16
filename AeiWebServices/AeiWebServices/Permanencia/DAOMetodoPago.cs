using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeiWebServices.Permanencia
{
    public interface DAOMetodoPago
    {
        int agregarMetodoPago(MetodoPago metodo, int idUsuario);
        List<MetodoPago> consultarAllMetodosPago(int idUsuario);
        int modificarMetodoPago(MetodoPago metodoModificado, int idMetodoActual, int idUsuario);
    }
}
