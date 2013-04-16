using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeiWebServices.Permanencia
{
    interface DAODireccion
    {
        int AgregarDireccionUsuario(int idUsuario, int idDireccion, Direccion direccion);
        List<Direccion> ConsultarDireccion(int idUsuario);
        int modificarDireccion(int idDireccion, Direccion direccionModificada);
    }
}
 