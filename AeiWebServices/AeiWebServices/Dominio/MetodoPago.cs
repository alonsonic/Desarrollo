﻿using System;
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
        private string numero;
        private DateTime fechaVencimiento;
        private string marca;
        private string status;

        public MetodoPago()
        {
        }
        public MetodoPago(int id, string numero, DateTime fechaVencimiento, string marca, string status)
        {
            this.id = id;
            this.numero = numero;
            this.fechaVencimiento = fechaVencimiento;
            this.marca = marca;
            this.status = status;
        }
        [DataMember]
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        [DataMember]
        public string Numero
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
