using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml;

namespace AeiWebServices.Logica
{
    public class RestLogicaBusqueda
    {

        private XmlDocument recibirXml(string ruta)
        {
            HttpWebRequest req = WebRequest.Create(ruta) as HttpWebRequest;
            string result = null;
            using (HttpWebResponse resp = req.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(resp.GetResponseStream());
                result = reader.ReadToEnd();
            }

            XmlDocument xmlRest = new XmlDocument();
            xmlRest.LoadXml(result);
            return xmlRest;
        }

        public List<Producto> listaProductos(string ipServidorRest, string parametrosBusquedad)
        {
            List<Producto> listaProductos = new List<Producto>();
            string ruta = "http://" + ipServidorRest + ":3306/GrailsApplication3/productos/rest/"+ parametrosBusquedad;
            XmlDocument xmlRest = recibirXml(ruta);
 
            /**** LOS PARAMETROS DEL XML HAY Q ARREGLARLOS PARA EL XML DEL EQUIPO Q NOS TOCO ******/
            XmlNodeList Productos = xmlRest.GetElementsByTagName("productoes");
            XmlNodeList lista = ((XmlElement)Productos[0]).GetElementsByTagName("producto");
            foreach (XmlElement nodo in lista)
            {
                XmlNodeList lista1 = nodo.GetElementsByTagName("nombreProducto");
            }

            return listaProductos;  

        }

    }
}