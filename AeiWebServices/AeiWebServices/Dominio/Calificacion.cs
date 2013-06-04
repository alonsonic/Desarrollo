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
        private string comentario;
        private DateTime fecha;

        
        private Usuario usuario;


        public Calificacion(int id, int puntaje, string comentario, DateTime fecha, Usuario usuario)
        {
            this.id = id;
            this.puntaje = puntaje;
            this.comentario = comentario;
            this.fecha = fecha;
            this.usuario = usuario;
        }

        [DataMember]
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        [DataMember]
        public string Comentario
        {
            get { return comentario; }
            set { comentario = value; }
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

        [DataMember]
        public Usuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        //Sobre escribimos el metodo equals para ser usado en las pruebas unitarias
         public override bool Equals(Object calificacion)
         {
             if (calificacion == null || GetType() != calificacion.GetType())
                 return false;
             Calificacion cal = calificacion as Calificacion;
             if (this.puntaje == cal.puntaje && this.fecha.ToString("yyyy-MM-dd").Equals(cal.fecha.ToString("yyyy-MM-dd")) && this.comentario.Equals(cal.comentario))
                 return true;
             else
                 return false;
         }
    }
}
