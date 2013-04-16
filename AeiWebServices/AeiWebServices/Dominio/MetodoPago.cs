using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AeiWebServices
{
    [DataContract]
    public class MetodoPago
    {
        private int id;
        private int numero;
        private DateTime fechaVencimiento;
        private string marca;

        public MetodoPago(int id, int numero, DateTime fechaVencimiento, string marca)
        {
            this.id = id;
            this.numero = numero;
            this.fechaVencimiento = fechaVencimiento;
            this.marca = marca;
        }

        [DataMember]
        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        [DataMember]
        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }

        [DataMember]
        public DateTime FechaVencimiento
        {
            get { return fechaVencimiento; }
            set { fechaVencimiento = value; }
        }

        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
