using AeiWebServices.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AeiWebServices.Permanencia
{
    interface DAOTwitter
    {
        int agregarUsuario(Twitter usuario);
    }
}