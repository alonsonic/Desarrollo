using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AeiWebServices
{
    [DataContract]
    public class Usuario
    {
        private int id;
        private string nombre;
        private string apellido;
        private string pasaporte;
        private string email;
        private DateTime fechaRegistro;
        private DateTime fechaNacimiento;
        private string status;
        private Compra carrito;
        private List<Compra> compras;
        private List<Direccion> direcciones;
        private List<MetodoPago> metodosPago;
        private int codigoActivacion;

        public Usuario() 
        { 
        }

        public Usuario(int id, string nombre, string apellido, string pasaporte, string email,DateTime fechaRegistro, 
            DateTime fechaNacimiento, string status, Compra carrito, List<Compra> compras,
            List<Direccion> direcciones, List<MetodoPago> metodosPago, int codigoActivacion)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.pasaporte = pasaporte;
            this.email = email;
            this.fechaNacimiento = fechaNacimiento;
            this.fechaRegistro = fechaRegistro;
            this.status = status;
            this.carrito = carrito;
            this.compras = compras;
            this.direcciones = direcciones;
            this.metodosPago = metodosPago;
            this.codigoActivacion = codigoActivacion;
        }

        public void AgregarDireccion(Direccion direccion)
        {
            this.Direcciones.Add(direccion);
        }

        public void AgregarCompra(Compra compra)
        {
            this.Compras.Add(compra);
        }

        public void AgregarMetodoPago(MetodoPago pago)
        {
            this.MetodosPago.Add(pago);
        }

        [DataMember]
        public int CodigoActivacion
        {
            get { return codigoActivacion; }
            set { codigoActivacion = value; }
        }

        [DataMember]
        public List<MetodoPago> MetodosPago
        {
            get { return metodosPago; }
            set { metodosPago = value; }
        }

        [DataMember]
        public List<Compra> Compras
        {
            get { return compras; }
            set { compras = value; }
        }

        [DataMember]
        public Compra Carrito
        {
            get { return carrito; }
            set { carrito = value; }
        }

        [DataMember]
        public List<Direccion> Direcciones
        {
            get { return direcciones; }
            set { direcciones = value; }
        } 
        [DataMember]
        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        [DataMember]
        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }

        [DataMember]
        public DateTime FechaRegistro
        {
            get { return fechaRegistro; }
            set { fechaRegistro = value; }
        }

        [DataMember]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        [DataMember]
        public string Pasaporte
        {
            get { return pasaporte; }
            set { pasaporte = value; }
        }

        [DataMember]
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        [DataMember]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        [DataMember]
        public int Id
        {
          get { return id; }
          set { id = value; }
        }
    }
}
