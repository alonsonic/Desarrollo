using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml;

namespace AeiWebServices.Logica
{

        private static XmlDocument recibirXml(string ruta)
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

        public static List<Producto> listaProductos(string ipWebServer, string puertoWebServer,string parametrosBusquedad, string pagina)
        {
            List<Producto> listaProductos = new List<Producto>();
            string ruta = "http://" + ipWebServer + ":" + puertoWebServer + "/GrailsApplication3/productos/rest/" + parametrosBusquedad + "," + pagina;
            XmlDocument xmlRest = recibirXml(ruta);
 
            XmlNodeList productos = xmlRest.GetElementsByTagName("list");
            XmlNodeList lista = ((XmlElement)productos[0]).GetElementsByTagName("productos");
            foreach (XmlElement nodo in lista)
            {
                Producto auxProducto = new Producto();
                auxProducto.Nombre = nodo.GetElementsByTagName("nombre")[0].InnerText;
                auxProducto.Precio = float.Parse(nodo.GetElementsByTagName("precio")[0].InnerText);
                auxProducto.Descripcion = nodo.GetElementsByTagName("descripcion")[0].InnerText;
                auxProducto.ImagenDetalle = nodo.GetElementsByTagName("archivo")[0].InnerText;
                listaProductos.Add(auxProducto);
            }

            return listaProductos;  

        }

    }
}