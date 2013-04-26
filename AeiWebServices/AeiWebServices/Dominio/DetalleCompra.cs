using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AeiWebServices
{
    [DataContract]
    public class DetalleCompra
    {
        private int id;
        private float monto;
        private int cantidad;
        private Producto producto;

        public DetalleCompra(int id, float monto, int cantidad, Producto producto)
        {
            this.id = id;
            this.monto = monto;
            this.cantidad = cantidad;
            this.Producto = producto;
        }

        [DataMember]
        public Producto Producto
        {
            get { return producto; }
            set { producto = value; }
        }

        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        [DataMember]
        public float Monto
        {
            get { return monto; }
            set { monto = value; }
        }
    }
}
