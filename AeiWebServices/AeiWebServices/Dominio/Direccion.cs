using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AeiWebServices
{
    [DataContract]
    public class Direccion
    {
        private int id;
        private string pais;
        private string estado;
        private string ciudad;
        private int codigoPostal;
        private string descripcion;
        private string status;

        [DataMember]
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        [DataMember]
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string Pais
        {
            get { return pais; }
            set { pais = value; }
        }

        [DataMember]
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        [DataMember]
        public string Ciudad
        {
            get { return ciudad; }
            set { ciudad = value; }
        }

        [DataMember]
        public int CodigoPostal
        {
            get { return codigoPostal; }
            set { codigoPostal = value; }
        }

        public Direccion (int id, string pais, string estado, string ciudad, int codigoPostal, string descripcion, string status) 
        {
            this.id = id;
            this.pais = pais;
            this.estado = estado;
            this.ciudad = ciudad;
            this.codigoPostal = codigoPostal;
            this.descripcion = descripcion;
            this.status = status;
        }
    }
}
