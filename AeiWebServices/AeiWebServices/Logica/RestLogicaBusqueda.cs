using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml;
using AeiWebServices.Permanencia;

namespace AeiWebServices.Logica
{
    public static class RestLogicaBusqueda
    {

        private static XmlDocument recibirXml(string ruta)
        {
            try
            {
                HttpWebRequest req = WebRequest.Create(ruta) as HttpWebRequest;
                string result = null;
                using (HttpWebResponse resp = req.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(resp.GetResponseStream());
                    result = reader.ReadToEnd();
                }
                Log.LogInstanciar().Debug("Recibiendo respuesta del API");
                XmlDocument xmlRest = new XmlDocument();
                //xmlRest.Load(@"C:\Users\LyAna\Desktop\PruebaXml.xml");
                xmlRest.LoadXml(result);
                return xmlRest;
            }
            catch (WebException ex)
            {
                Log.LogInstanciar().Error("Error. Web Service el servidor no esta encendido o la busqueda no retorno ningun resultado.");
                return null;
            }
        }

        public static List<Producto> listaProductos(string ipWebServer, string puertoWebServer, string parametrosBusquedad, string pagina)
        {
            List<Producto> listaProductos = new List<Producto>();

            string ruta = "http://" + ipWebServer + ":" + puertoWebServer + "/GrailsApplication3/productos/rest/" + parametrosBusquedad + "," + pagina;
            Log.LogInstanciar().Info("Iniciando conexion al API /GrailsApplication3/productos/rest/ con IP: " + ipWebServer + "y puerto: " + puertoWebServer);
            XmlDocument xmlRest = recibirXml(ruta);
            if (xmlRest != null)
            {
                char[] separadores = { '/' };

                XmlNodeList productos = xmlRest.GetElementsByTagName("list");
                XmlNodeList lista = ((XmlElement)productos[0]).GetElementsByTagName("productos");
                foreach (XmlElement nodo in lista)
                {
                    Producto auxProducto = new Producto();
                    string[] rutaImagen = nodo.GetElementsByTagName("archivo")[0].InnerText.Split(separadores);

                    auxProducto.Nombre = nodo.GetElementsByTagName("nombre")[0].InnerText;
                    auxProducto.Precio = float.Parse(nodo.GetElementsByTagName("precio")[0].InnerText);
                    auxProducto.Descripcion = nodo.GetElementsByTagName("descripcion")[0].InnerText;
                    auxProducto.ImagenDetalle = "http://" + ipWebServer + ":" + puertoWebServer + "/" + rutaImagen[1] + "/" + rutaImagen[2] + "/" + rutaImagen[3] + "/" + rutaImagen[4];
                    auxProducto.Cantidad = 10;
                    auxProducto.Categoria = new Categoria(9999, "Le cloud");
                    listaProductos.Add(auxProducto);
                }

                return listaProductos;
            }
            else
            {
                return null;
            }

        }

    }
}