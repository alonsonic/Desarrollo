using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeiWebServices.Permanencia
{
    interface DAOUsuario
    {
        Usuario consultarUsuario(string mail, string CodigoActivacion);
        int modificarUsuario(Usuario usuarioModificado, int idUsuario);
           
    }
}
