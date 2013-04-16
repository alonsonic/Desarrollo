using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AeiWebServices
{
    [DataContract]
    public class Compra
    {
        private int id;
        private float montoTotal;
        private DateTime fechaSolicitud;
        private DateTime fechaEntrega;
        private string status;
        private List<DetalleCompra> productos;
        private MetodoPago pago;
        private Direccion direccion;

        public Compra(int id, float montoTotal, DateTime fechaSolicitud, DateTime fechaEntrega, string status,
             MetodoPago pago, List<DetalleCompra> productos, Direccion direccion)
        {
            this.id = id;
            this.montoTotal = montoTotal;
            this.fechaSolicitud = fechaSolicitud;
            this.fechaEntrega = fechaEntrega;
            this.status = status;
            this.productos = productos;
            this.pago = pago;
            this.direccion = direccion;
        }

        public void AgregarDetallesCompra(DetalleCompra detallecompra)
        {
            this.productos.Add(detallecompra);
        }

        [DataMember]
        public Direccion Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        [DataMember]
        public MetodoPago Pago
        {
            get { return pago; }
            set { pago = value; }
        }

        [DataMember]
        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        [DataMember]
        public DateTime FechaEntrega
        {
            get { return fechaEntrega; }
            set { fechaEntrega = value; }
        }

        [DataMember]
        public DateTime FechaSolicitud
        {
            get { return fechaSolicitud; }
            set { fechaSolicitud = value; }
        }

        [DataMember]
        public float MontoTotal
        {
            get { return montoTotal; }
            set { montoTotal = value; }
        }

        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
