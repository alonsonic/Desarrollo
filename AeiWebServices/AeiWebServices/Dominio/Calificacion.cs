using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AeiWebServices
{
    [DataContract]
    public class Calificacion
    {
        private int id;
        private int puntaje;
        private string detalle;
        private DateTime fecha;
        private Usuario usuario;

        Calificacion(int id, int puntaje, string detalle, DateTime fecha, Usuario usuario)
        {
            this.id = id;
            this.puntaje = puntaje;
            this.detalle = detalle;
            this.fecha = fecha;
            this.usuario = usuario;
        }

        [DataMember]
        public string Detalle
        {
            get { return detalle; }
            set { detalle = value; }
        }

        [DataMember]
        public int Puntaje
        {
            get { return puntaje; }
            set { puntaje = value; }
        }

        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
