using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeiWebServices.Permanencia
{
    interface DAOUsuario
    {
        Usuario consultarUsuario(string mail, int CodigoActivacion);
        Usuario consultarUsuario(string mail);
        Usuario consultarUsuario(int id);
        int modificarUsuario(Usuario usuarioModificado, int idUsuario);
        int agregarUsuario(Usuario usuario);
    }
}
