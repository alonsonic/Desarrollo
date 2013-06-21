using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Net;

namespace AeiWebServices.Logica
{
    public class ServicioTwtter
    {
        var client = new JsonServiceClient("http://host/api/");
    }
}