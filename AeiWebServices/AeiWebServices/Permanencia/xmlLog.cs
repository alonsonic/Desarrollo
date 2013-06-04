using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml;

namespace AeiWebServices.Permanencia
{
    public class xmlLog
    {
        XmlDocument documento = new XmlDocument();

        public XmlNode crearNodoXml(string Fecha, string Peticion, string Status)
        {

            documento = new XmlDocument();
            documento.Load("C:\\logBusqueda.xml");

            XmlElement busqueda = documento.CreateElement("Busqueda");
            XmlElement fecha = documento.CreateElement("Fecha");
            fecha.InnerText = Fecha;
            busqueda.AppendChild(fecha);

            XmlElement peticion = documento.CreateElement("Peticion");
            peticion.InnerText = Peticion;
            busqueda.AppendChild(peticion);

            XmlElement status = documento.CreateElement("Status");
            status.InnerText = Status;
            busqueda.AppendChild(status);

            return busqueda;
        }

        public void escribir(string Peticion, string Status)
        {
            XmlWriteMode xml = new XmlWriteMode();
            //Creamos el nodo que deseamos insertar.
            XmlNode empleado = crearNodoXml(DateTime.Now.ToString(),Peticion,Status);

            //Obtenemos el nodo raiz del documento.
            XmlNode nodoRaiz = documento.DocumentElement;

            //Insertamos el nodo empleado al final del archivo
            nodoRaiz.InsertAfter(empleado, nodoRaiz.LastChild);   

            documento.Save("C:\\logBusqueda.xml");
        }

    }
}