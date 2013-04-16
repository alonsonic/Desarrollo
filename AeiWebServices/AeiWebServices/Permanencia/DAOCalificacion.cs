using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeiWebServices.Permanencia
{
    interface DAOCalificacion
    {
        int agregarCalificacion(Calificacion calificacion, int idUsuario, int idProducto);
        List<Calificacion> consultarCalificacionesPorProducto(int idProducto);
    }
}
