﻿
namespace AeiCliente.ServicioAEI {
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MetodoPago", Namespace="http://schemas.datacontract.org/2004/07/AeiWebServices")]
    public partial class MetodoPago : object, System.ComponentModel.INotifyPropertyChanged {
        
        private System.DateTime FechaVencimientoField;
        
        private int IdField;
        
        private string MarcaField;
        
        private string NumeroField;
        
        private string StatusField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime FechaVencimiento {
            get {
                return this.FechaVencimientoField;
            }
            set {
                if ((this.FechaVencimientoField.Equals(value) != true)) {
                    this.FechaVencimientoField = value;
                    this.RaisePropertyChanged("FechaVencimiento");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Marca {
            get {
                return this.MarcaField;
            }
            set {
                if ((object.ReferenceEquals(this.MarcaField, value) != true)) {
                    this.MarcaField = value;
                    this.RaisePropertyChanged("Marca");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Numero {
            get {
                return this.NumeroField;
            }
            set {
                if ((object.ReferenceEquals(this.NumeroField, value) != true)) {
                    this.NumeroField = value;
                    this.RaisePropertyChanged("Numero");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Status {
            get {
                return this.StatusField;
            }
            set {
                if ((object.ReferenceEquals(this.StatusField, value) != true)) {
                    this.StatusField = value;
                    this.RaisePropertyChanged("Status");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Usuario", Namespace="http://schemas.datacontract.org/2004/07/AeiWebServices")]
    public partial class Usuario : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string ApellidoField;
        
        private AeiCliente.ServicioAEI.Compra CarritoField;
        
        private int CodigoActivacionField;
        
        private System.Collections.Generic.List<AeiCliente.ServicioAEI.Compra> ComprasField;
        
        private System.Collections.Generic.List<AeiCliente.ServicioAEI.Direccion> DireccionesField;
        
        private string EmailField;
        
        private System.DateTime FechaNacimientoField;
        
        private System.DateTime FechaRegistroField;
        
        private int IdField;
        
        private System.Collections.Generic.List<AeiCliente.ServicioAEI.MetodoPago> MetodosPagoField;
        
        private string NombreField;
        
        private string PasaporteField;
        
        private string StatusField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Apellido {
            get {
                return this.ApellidoField;
            }
            set {
                if ((object.ReferenceEquals(this.ApellidoField, value) != true)) {
                    this.ApellidoField = value;
                    this.RaisePropertyChanged("Apellido");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public AeiCliente.ServicioAEI.Compra Carrito {
            get {
                return this.CarritoField;
            }
            set {
                if ((object.ReferenceEquals(this.CarritoField, value) != true)) {
                    this.CarritoField = value;
                    this.RaisePropertyChanged("Carrito");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CodigoActivacion {
            get {
                return this.CodigoActivacionField;
            }
            set {
                if ((this.CodigoActivacionField.Equals(value) != true)) {
                    this.CodigoActivacionField = value;
                    this.RaisePropertyChanged("CodigoActivacion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.List<AeiCliente.ServicioAEI.Compra> Compras {
            get {
                return this.ComprasField;
            }
            set {
                if ((object.ReferenceEquals(this.ComprasField, value) != true)) {
                    this.ComprasField = value;
                    this.RaisePropertyChanged("Compras");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.List<AeiCliente.ServicioAEI.Direccion> Direcciones {
            get {
                return this.DireccionesField;
            }
            set {
                if ((object.ReferenceEquals(this.DireccionesField, value) != true)) {
                    this.DireccionesField = value;
                    this.RaisePropertyChanged("Direcciones");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime FechaNacimiento {
            get {
                return this.FechaNacimientoField;
            }
            set {
                if ((this.FechaNacimientoField.Equals(value) != true)) {
                    this.FechaNacimientoField = value;
                    this.RaisePropertyChanged("FechaNacimiento");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime FechaRegistro {
            get {
                return this.FechaRegistroField;
            }
            set {
                if ((this.FechaRegistroField.Equals(value) != true)) {
                    this.FechaRegistroField = value;
                    this.RaisePropertyChanged("FechaRegistro");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.List<AeiCliente.ServicioAEI.MetodoPago> MetodosPago {
            get {
                return this.MetodosPagoField;
            }
            set {
                if ((object.ReferenceEquals(this.MetodosPagoField, value) != true)) {
                    this.MetodosPagoField = value;
                    this.RaisePropertyChanged("MetodosPago");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nombre {
            get {
                return this.NombreField;
            }
            set {
                if ((object.ReferenceEquals(this.NombreField, value) != true)) {
                    this.NombreField = value;
                    this.RaisePropertyChanged("Nombre");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Pasaporte {
            get {
                return this.PasaporteField;
            }
            set {
                if ((object.ReferenceEquals(this.PasaporteField, value) != true)) {
                    this.PasaporteField = value;
                    this.RaisePropertyChanged("Pasaporte");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Status {
            get {
                return this.StatusField;
            }
            set {
                if ((object.ReferenceEquals(this.StatusField, value) != true)) {
                    this.StatusField = value;
                    this.RaisePropertyChanged("Status");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Compra", Namespace="http://schemas.datacontract.org/2004/07/AeiWebServices")]
    public partial class Compra : object, System.ComponentModel.INotifyPropertyChanged {
        
        private AeiCliente.ServicioAEI.Direccion DireccionField;
        
        private System.DateTime FechaEntregaField;
        
        private System.DateTime FechaSolicitudField;
        
        private int IdField;
        
        private float MontoTotalField;
        
        private AeiCliente.ServicioAEI.MetodoPago PagoField;
        
        private System.Collections.Generic.List<AeiCliente.ServicioAEI.DetalleCompra> ProductosField;
        
        private string StatusField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public AeiCliente.ServicioAEI.Direccion Direccion {
            get {
                return this.DireccionField;
            }
            set {
                if ((object.ReferenceEquals(this.DireccionField, value) != true)) {
                    this.DireccionField = value;
                    this.RaisePropertyChanged("Direccion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime FechaEntrega {
            get {
                return this.FechaEntregaField;
            }
            set {
                if ((this.FechaEntregaField.Equals(value) != true)) {
                    this.FechaEntregaField = value;
                    this.RaisePropertyChanged("FechaEntrega");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime FechaSolicitud {
            get {
                return this.FechaSolicitudField;
            }
            set {
                if ((this.FechaSolicitudField.Equals(value) != true)) {
                    this.FechaSolicitudField = value;
                    this.RaisePropertyChanged("FechaSolicitud");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float MontoTotal {
            get {
                return this.MontoTotalField;
            }
            set {
                if ((this.MontoTotalField.Equals(value) != true)) {
                    this.MontoTotalField = value;
                    this.RaisePropertyChanged("MontoTotal");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public AeiCliente.ServicioAEI.MetodoPago Pago {
            get {
                return this.PagoField;
            }
            set {
                if ((object.ReferenceEquals(this.PagoField, value) != true)) {
                    this.PagoField = value;
                    this.RaisePropertyChanged("Pago");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.List<AeiCliente.ServicioAEI.DetalleCompra> Productos {
            get {
                return this.ProductosField;
            }
            set {
                if ((object.ReferenceEquals(this.ProductosField, value) != true)) {
                    this.ProductosField = value;
                    this.RaisePropertyChanged("Productos");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Status {
            get {
                return this.StatusField;
            }
            set {
                if ((object.ReferenceEquals(this.StatusField, value) != true)) {
                    this.StatusField = value;
                    this.RaisePropertyChanged("Status");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Direccion", Namespace="http://schemas.datacontract.org/2004/07/AeiWebServices")]
    public partial class Direccion : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string CiudadField;
        
        private int CodigoPostalField;
        
        private string DescripcionField;
        
        private string EstadoField;
        
        private int IdField;
        
        private string PaisField;
        
        private string StatusField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Ciudad {
            get {
                return this.CiudadField;
            }
            set {
                if ((object.ReferenceEquals(this.CiudadField, value) != true)) {
                    this.CiudadField = value;
                    this.RaisePropertyChanged("Ciudad");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CodigoPostal {
            get {
                return this.CodigoPostalField;
            }
            set {
                if ((this.CodigoPostalField.Equals(value) != true)) {
                    this.CodigoPostalField = value;
                    this.RaisePropertyChanged("CodigoPostal");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Descripcion {
            get {
                return this.DescripcionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescripcionField, value) != true)) {
                    this.DescripcionField = value;
                    this.RaisePropertyChanged("Descripcion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Estado {
            get {
                return this.EstadoField;
            }
            set {
                if ((object.ReferenceEquals(this.EstadoField, value) != true)) {
                    this.EstadoField = value;
                    this.RaisePropertyChanged("Estado");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Pais {
            get {
                return this.PaisField;
            }
            set {
                if ((object.ReferenceEquals(this.PaisField, value) != true)) {
                    this.PaisField = value;
                    this.RaisePropertyChanged("Pais");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Status {
            get {
                return this.StatusField;
            }
            set {
                if ((object.ReferenceEquals(this.StatusField, value) != true)) {
                    this.StatusField = value;
                    this.RaisePropertyChanged("Status");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DetalleCompra", Namespace="http://schemas.datacontract.org/2004/07/AeiWebServices")]
    public partial class DetalleCompra : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int CantidadField;
        
        private int IdField;
        
        private float MontoField;
        
        private AeiCliente.ServicioAEI.Producto ProductoField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Cantidad {
            get {
                return this.CantidadField;
            }
            set {
                if ((this.CantidadField.Equals(value) != true)) {
                    this.CantidadField = value;
                    this.RaisePropertyChanged("Cantidad");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float Monto {
            get {
                return this.MontoField;
            }
            set {
                if ((this.MontoField.Equals(value) != true)) {
                    this.MontoField = value;
                    this.RaisePropertyChanged("Monto");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public AeiCliente.ServicioAEI.Producto Producto {
            get {
                return this.ProductoField;
            }
            set {
                if ((object.ReferenceEquals(this.ProductoField, value) != true)) {
                    this.ProductoField = value;
                    this.RaisePropertyChanged("Producto");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Producto", Namespace="http://schemas.datacontract.org/2004/07/AeiWebServices")]
    public partial class Producto : object, System.ComponentModel.INotifyPropertyChanged {
        
        private System.Collections.Generic.List<AeiCliente.ServicioAEI.Calificacion> CalificacionesField;
        
        private int CantidadField;
        
        private AeiCliente.ServicioAEI.Categoria CategoriaField;
        
        private string DescripcionField;
        
        private System.Collections.Generic.List<AeiCliente.ServicioAEI.Tag> EtiquetasField;
        
        private int IdField;
        
        private string ImagenDetalleField;
        
        private string ImagenMiniaturaField;
        
        private string NombreField;
        
        private float PrecioField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.List<AeiCliente.ServicioAEI.Calificacion> Calificaciones {
            get {
                return this.CalificacionesField;
            }
            set {
                if ((object.ReferenceEquals(this.CalificacionesField, value) != true)) {
                    this.CalificacionesField = value;
                    this.RaisePropertyChanged("Calificaciones");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Cantidad {
            get {
                return this.CantidadField;
            }
            set {
                if ((this.CantidadField.Equals(value) != true)) {
                    this.CantidadField = value;
                    this.RaisePropertyChanged("Cantidad");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public AeiCliente.ServicioAEI.Categoria Categoria {
            get {
                return this.CategoriaField;
            }
            set {
                if ((object.ReferenceEquals(this.CategoriaField, value) != true)) {
                    this.CategoriaField = value;
                    this.RaisePropertyChanged("Categoria");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Descripcion {
            get {
                return this.DescripcionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescripcionField, value) != true)) {
                    this.DescripcionField = value;
                    this.RaisePropertyChanged("Descripcion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.List<AeiCliente.ServicioAEI.Tag> Etiquetas {
            get {
                return this.EtiquetasField;
            }
            set {
                if ((object.ReferenceEquals(this.EtiquetasField, value) != true)) {
                    this.EtiquetasField = value;
                    this.RaisePropertyChanged("Etiquetas");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ImagenDetalle {
            get {
                return this.ImagenDetalleField;
            }
            set {
                if ((object.ReferenceEquals(this.ImagenDetalleField, value) != true)) {
                    this.ImagenDetalleField = value;
                    this.RaisePropertyChanged("ImagenDetalle");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ImagenMiniatura {
            get {
                return this.ImagenMiniaturaField;
            }
            set {
                if ((object.ReferenceEquals(this.ImagenMiniaturaField, value) != true)) {
                    this.ImagenMiniaturaField = value;
                    this.RaisePropertyChanged("ImagenMiniatura");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nombre {
            get {
                return this.NombreField;
            }
            set {
                if ((object.ReferenceEquals(this.NombreField, value) != true)) {
                    this.NombreField = value;
                    this.RaisePropertyChanged("Nombre");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float Precio {
            get {
                return this.PrecioField;
            }
            set {
                if ((this.PrecioField.Equals(value) != true)) {
                    this.PrecioField = value;
                    this.RaisePropertyChanged("Precio");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Categoria", Namespace="http://schemas.datacontract.org/2004/07/AeiWebServices")]
    public partial class Categoria : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int IdField;
        
        private string NombreField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nombre {
            get {
                return this.NombreField;
            }
            set {
                if ((object.ReferenceEquals(this.NombreField, value) != true)) {
                    this.NombreField = value;
                    this.RaisePropertyChanged("Nombre");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Calificacion", Namespace="http://schemas.datacontract.org/2004/07/AeiWebServices")]
    public partial class Calificacion : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string ComentarioField;
        
        private System.DateTime FechaField;
        
        private int IdField;
        
        private int PuntajeField;
        
        private AeiCliente.ServicioAEI.Usuario UsuarioField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Comentario {
            get {
                return this.ComentarioField;
            }
            set {
                if ((object.ReferenceEquals(this.ComentarioField, value) != true)) {
                    this.ComentarioField = value;
                    this.RaisePropertyChanged("Comentario");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Fecha {
            get {
                return this.FechaField;
            }
            set {
                if ((this.FechaField.Equals(value) != true)) {
                    this.FechaField = value;
                    this.RaisePropertyChanged("Fecha");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Puntaje {
            get {
                return this.PuntajeField;
            }
            set {
                if ((this.PuntajeField.Equals(value) != true)) {
                    this.PuntajeField = value;
                    this.RaisePropertyChanged("Puntaje");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public AeiCliente.ServicioAEI.Usuario Usuario {
            get {
                return this.UsuarioField;
            }
            set {
                if ((object.ReferenceEquals(this.UsuarioField, value) != true)) {
                    this.UsuarioField = value;
                    this.RaisePropertyChanged("Usuario");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Tag", Namespace="http://schemas.datacontract.org/2004/07/AeiWebServices")]
    public partial class Tag : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int IdField;
        
        private string NombreField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nombre {
            get {
                return this.NombreField;
            }
            set {
                if ((object.ReferenceEquals(this.NombreField, value) != true)) {
                    this.NombreField = value;
                    this.RaisePropertyChanged("Nombre");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Twitter", Namespace="http://schemas.datacontract.org/2004/07/AeiWebServices.Dominio")]
    public partial class Twitter : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string IdUsuarioField;
        
        private string OauthTokenField;
        
        private string OauthTokenSecretField;
        
        private string ScreenNameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string IdUsuario {
            get {
                return this.IdUsuarioField;
            }
            set {
                if ((object.ReferenceEquals(this.IdUsuarioField, value) != true)) {
                    this.IdUsuarioField = value;
                    this.RaisePropertyChanged("IdUsuario");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OauthToken {
            get {
                return this.OauthTokenField;
            }
            set {
                if ((object.ReferenceEquals(this.OauthTokenField, value) != true)) {
                    this.OauthTokenField = value;
                    this.RaisePropertyChanged("OauthToken");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OauthTokenSecret {
            get {
                return this.OauthTokenSecretField;
            }
            set {
                if ((object.ReferenceEquals(this.OauthTokenSecretField, value) != true)) {
                    this.OauthTokenSecretField = value;
                    this.RaisePropertyChanged("OauthTokenSecret");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ScreenName {
            get {
                return this.ScreenNameField;
            }
            set {
                if ((object.ReferenceEquals(this.ScreenNameField, value) != true)) {
                    this.ScreenNameField = value;
                    this.RaisePropertyChanged("ScreenName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServicioAEI.IServicioAEI")]
    public interface IServicioAEI {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioAEI/eliminarMetodoPago", ReplyAction="http://tempuri.org/IServicioAEI/eliminarMetodoPagoResponse")]
        System.Threading.Tasks.Task<AeiCliente.ServicioAEI.Usuario> eliminarMetodoPagoAsync(AeiCliente.ServicioAEI.MetodoPago metodo, AeiCliente.ServicioAEI.Usuario usuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioAEI/agregarCalificacion", ReplyAction="http://tempuri.org/IServicioAEI/agregarCalificacionResponse")]
        System.Threading.Tasks.Task<int> agregarCalificacionAsync(int idProducto, int idUsuario, AeiCliente.ServicioAEI.Calificacion calificacion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioAEI/modificarStatusCompra", ReplyAction="http://tempuri.org/IServicioAEI/modificarStatusCompraResponse")]
        System.Threading.Tasks.Task<int> modificarStatusCompraAsync(int idCompra);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioAEI/modificarMetodoPago", ReplyAction="http://tempuri.org/IServicioAEI/modificarMetodoPagoResponse")]
        System.Threading.Tasks.Task<AeiCliente.ServicioAEI.Usuario> modificarMetodoPagoAsync(AeiCliente.ServicioAEI.MetodoPago metodo, AeiCliente.ServicioAEI.Usuario usuario, int metodoActual);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioAEI/generarXml", ReplyAction="http://tempuri.org/IServicioAEI/generarXmlResponse")]
        System.Threading.Tasks.Task<string> generarXmlAsync(int idCompra);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioAEI/enviarCorreoDeFactura", ReplyAction="http://tempuri.org/IServicioAEI/enviarCorreoDeFacturaResponse")]
        System.Threading.Tasks.Task<int> enviarCorreoDeFacturaAsync(AeiCliente.ServicioAEI.Usuario usuario, AeiCliente.ServicioAEI.Compra compra);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioAEI/agregarMetodoPago", ReplyAction="http://tempuri.org/IServicioAEI/agregarMetodoPagoResponse")]
        System.Threading.Tasks.Task<AeiCliente.ServicioAEI.Usuario> agregarMetodoPagoAsync(AeiCliente.ServicioAEI.MetodoPago metodo, AeiCliente.ServicioAEI.Usuario usuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioAEI/modificarDireccion", ReplyAction="http://tempuri.org/IServicioAEI/modificarDireccionResponse")]
        System.Threading.Tasks.Task<int> modificarDireccionAsync(AeiCliente.ServicioAEI.Direccion direccionModificada);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioAEI/checkout", ReplyAction="http://tempuri.org/IServicioAEI/checkoutResponse")]
        System.Threading.Tasks.Task<AeiCliente.ServicioAEI.Usuario> checkoutAsync(AeiCliente.ServicioAEI.MetodoPago metodo, AeiCliente.ServicioAEI.Direccion direccion, AeiCliente.ServicioAEI.Usuario usuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioAEI/disponibilidadProductos", ReplyAction="http://tempuri.org/IServicioAEI/disponibilidadProductosResponse")]
        System.Threading.Tasks.Task<bool> disponibilidadProductosAsync(System.Collections.Generic.List<AeiCliente.ServicioAEI.DetalleCompra> detalle);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioAEI/checkearProductoCarrito", ReplyAction="http://tempuri.org/IServicioAEI/checkearProductoCarritoResponse")]
        System.Threading.Tasks.Task<bool> checkearProductoCarritoAsync(AeiCliente.ServicioAEI.Usuario usuario, AeiCliente.ServicioAEI.Producto producto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioAEI/borrarDetalleCarrito", ReplyAction="http://tempuri.org/IServicioAEI/borrarDetalleCarritoResponse")]
        System.Threading.Tasks.Task<AeiCliente.ServicioAEI.Usuario> borrarDetalleCarritoAsync(AeiCliente.ServicioAEI.Usuario usuario, AeiCliente.ServicioAEI.DetalleCompra detalle);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioAEI/enviarCorreoDeModificacion", ReplyAction="http://tempuri.org/IServicioAEI/enviarCorreoDeModificacionResponse")]
        System.Threading.Tasks.Task<int> enviarCorreoDeModificacionAsync(AeiCliente.ServicioAEI.Usuario usuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioAEI/enviarCorreoDeBienvenida", ReplyAction="http://tempuri.org/IServicioAEI/enviarCorreoDeBienvenidaResponse")]
        System.Threading.Tasks.Task<int> enviarCorreoDeBienvenidaAsync(AeiCliente.ServicioAEI.Usuario usuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioAEI/modificarUsuario", ReplyAction="http://tempuri.org/IServicioAEI/modificarUsuarioResponse")]
        System.Threading.Tasks.Task<int> modificarUsuarioAsync(AeiCliente.ServicioAEI.Usuario usuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioAEI/ConsultarUsuario", ReplyAction="http://tempuri.org/IServicioAEI/ConsultarUsuarioResponse")]
        System.Threading.Tasks.Task<AeiCliente.ServicioAEI.Usuario> ConsultarUsuarioAsync(string mail);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioAEI/agregarUsuario", ReplyAction="http://tempuri.org/IServicioAEI/agregarUsuarioResponse")]
        System.Threading.Tasks.Task<AeiCliente.ServicioAEI.Usuario> agregarUsuarioAsync(string nombre, string apellido, string pasaporte, string mail, string fechaNacimiento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioAEI/getTwitter", ReplyAction="http://tempuri.org/IServicioAEI/getTwitterResponse")]
        System.Threading.Tasks.Task<AeiCliente.ServicioAEI.Twitter> getTwitterAsync(string screenName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioAEI/agregarTwitter", ReplyAction="http://tempuri.org/IServicioAEI/agregarTwitterResponse")]
        System.Threading.Tasks.Task<int> agregarTwitterAsync(string idUsuario, string screenName, string OauthToken, string OauthTokenSecret);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioAEI/buscarCalificacionProducto", ReplyAction="http://tempuri.org/IServicioAEI/buscarCalificacionProductoResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<AeiCliente.ServicioAEI.Calificacion>> buscarCalificacionProductoAsync(int idProducto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioAEI/BuscarProductoPorCategoria", ReplyAction="http://tempuri.org/IServicioAEI/BuscarProductoPorCategoriaResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<AeiCliente.ServicioAEI.Producto>> BuscarProductoPorCategoriaAsync(string nombre);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioAEI/BusquedaProductoConCategoria", ReplyAction="http://tempuri.org/IServicioAEI/BusquedaProductoConCategoriaResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<AeiCliente.ServicioAEI.Producto>> BusquedaProductoConCategoriaAsync(string categoriaProducto, string busqueda);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioAEI/BusquedaProducto", ReplyAction="http://tempuri.org/IServicioAEI/BusquedaProductoResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<AeiCliente.ServicioAEI.Producto>> BusquedaProductoAsync(string busqueda);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioAEI/BuscarTodasLasCategorias", ReplyAction="http://tempuri.org/IServicioAEI/BuscarTodasLasCategoriasResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<AeiCliente.ServicioAEI.Categoria>> BuscarTodasLasCategoriasAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioAEI/consultarEstados", ReplyAction="http://tempuri.org/IServicioAEI/consultarEstadosResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<AeiCliente.ServicioAEI.Direccion>> consultarEstadosAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioAEI/consultarCiudad", ReplyAction="http://tempuri.org/IServicioAEI/consultarCiudadResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<AeiCliente.ServicioAEI.Direccion>> consultarCiudadAsync(int idEstado);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioAEI/agregarDireccionUsuario", ReplyAction="http://tempuri.org/IServicioAEI/agregarDireccionUsuarioResponse")]
        System.Threading.Tasks.Task<int> agregarDireccionUsuarioAsync(int idUsuario, int idDireccion, string descripcion, int codigoPostal);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioAEI/agregarCarrito", ReplyAction="http://tempuri.org/IServicioAEI/agregarCarritoResponse")]
        System.Threading.Tasks.Task<AeiCliente.ServicioAEI.Usuario> agregarCarritoAsync(AeiCliente.ServicioAEI.Usuario usuario, AeiCliente.ServicioAEI.DetalleCompra detalleCompra);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioAEI/buscarDireccionUsuario", ReplyAction="http://tempuri.org/IServicioAEI/buscarDireccionUsuarioResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<AeiCliente.ServicioAEI.Direccion>> buscarDireccionUsuarioAsync(int idUsuario);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServicioAEIChannel : AeiCliente.ServicioAEI.IServicioAEI, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServicioAEIClient : System.ServiceModel.ClientBase<AeiCliente.ServicioAEI.IServicioAEI>, AeiCliente.ServicioAEI.IServicioAEI {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public ServicioAEIClient() : 
                base(ServicioAEIClient.GetDefaultBinding(), ServicioAEIClient.GetDefaultEndpointAddress()) {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IServicioAEI.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ServicioAEIClient(EndpointConfiguration endpointConfiguration) : 
                base(ServicioAEIClient.GetBindingForEndpoint(endpointConfiguration), ServicioAEIClient.GetEndpointAddress(endpointConfiguration)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ServicioAEIClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(ServicioAEIClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ServicioAEIClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(ServicioAEIClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ServicioAEIClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Threading.Tasks.Task<AeiCliente.ServicioAEI.Usuario> eliminarMetodoPagoAsync(AeiCliente.ServicioAEI.MetodoPago metodo, AeiCliente.ServicioAEI.Usuario usuario) {
            return base.Channel.eliminarMetodoPagoAsync(metodo, usuario);
        }
        
        public System.Threading.Tasks.Task<int> agregarCalificacionAsync(int idProducto, int idUsuario, AeiCliente.ServicioAEI.Calificacion calificacion) {
            return base.Channel.agregarCalificacionAsync(idProducto, idUsuario, calificacion);
        }
        
        public System.Threading.Tasks.Task<int> modificarStatusCompraAsync(int idCompra) {
            return base.Channel.modificarStatusCompraAsync(idCompra);
        }
        
        public System.Threading.Tasks.Task<AeiCliente.ServicioAEI.Usuario> modificarMetodoPagoAsync(AeiCliente.ServicioAEI.MetodoPago metodo, AeiCliente.ServicioAEI.Usuario usuario, int metodoActual) {
            return base.Channel.modificarMetodoPagoAsync(metodo, usuario, metodoActual);
        }
        
        public System.Threading.Tasks.Task<string> generarXmlAsync(int idCompra) {
            return base.Channel.generarXmlAsync(idCompra);
        }
        
        public System.Threading.Tasks.Task<int> enviarCorreoDeFacturaAsync(AeiCliente.ServicioAEI.Usuario usuario, AeiCliente.ServicioAEI.Compra compra) {
            return base.Channel.enviarCorreoDeFacturaAsync(usuario, compra);
        }
        
        public System.Threading.Tasks.Task<AeiCliente.ServicioAEI.Usuario> agregarMetodoPagoAsync(AeiCliente.ServicioAEI.MetodoPago metodo, AeiCliente.ServicioAEI.Usuario usuario) {
            return base.Channel.agregarMetodoPagoAsync(metodo, usuario);
        }
        
        public System.Threading.Tasks.Task<int> modificarDireccionAsync(AeiCliente.ServicioAEI.Direccion direccionModificada) {
            return base.Channel.modificarDireccionAsync(direccionModificada);
        }
        
        public System.Threading.Tasks.Task<AeiCliente.ServicioAEI.Usuario> checkoutAsync(AeiCliente.ServicioAEI.MetodoPago metodo, AeiCliente.ServicioAEI.Direccion direccion, AeiCliente.ServicioAEI.Usuario usuario) {
            return base.Channel.checkoutAsync(metodo, direccion, usuario);
        }
        
        public System.Threading.Tasks.Task<bool> disponibilidadProductosAsync(System.Collections.Generic.List<AeiCliente.ServicioAEI.DetalleCompra> detalle) {
            return base.Channel.disponibilidadProductosAsync(detalle);
        }
        
        public System.Threading.Tasks.Task<bool> checkearProductoCarritoAsync(AeiCliente.ServicioAEI.Usuario usuario, AeiCliente.ServicioAEI.Producto producto) {
            return base.Channel.checkearProductoCarritoAsync(usuario, producto);
        }
        
        public System.Threading.Tasks.Task<AeiCliente.ServicioAEI.Usuario> borrarDetalleCarritoAsync(AeiCliente.ServicioAEI.Usuario usuario, AeiCliente.ServicioAEI.DetalleCompra detalle) {
            return base.Channel.borrarDetalleCarritoAsync(usuario, detalle);
        }
        
        public System.Threading.Tasks.Task<int> enviarCorreoDeModificacionAsync(AeiCliente.ServicioAEI.Usuario usuario) {
            return base.Channel.enviarCorreoDeModificacionAsync(usuario);
        }
        
        public System.Threading.Tasks.Task<int> enviarCorreoDeBienvenidaAsync(AeiCliente.ServicioAEI.Usuario usuario) {
            return base.Channel.enviarCorreoDeBienvenidaAsync(usuario);
        }
        
        public System.Threading.Tasks.Task<int> modificarUsuarioAsync(AeiCliente.ServicioAEI.Usuario usuario) {
            return base.Channel.modificarUsuarioAsync(usuario);
        }
        
        public System.Threading.Tasks.Task<AeiCliente.ServicioAEI.Usuario> ConsultarUsuarioAsync(string mail) {
            return base.Channel.ConsultarUsuarioAsync(mail);
        }
        
        public System.Threading.Tasks.Task<AeiCliente.ServicioAEI.Usuario> agregarUsuarioAsync(string nombre, string apellido, string pasaporte, string mail, string fechaNacimiento) {
            return base.Channel.agregarUsuarioAsync(nombre, apellido, pasaporte, mail, fechaNacimiento);
        }
        
        public System.Threading.Tasks.Task<AeiCliente.ServicioAEI.Twitter> getTwitterAsync(string screenName) {
            return base.Channel.getTwitterAsync(screenName);
        }
        
        public System.Threading.Tasks.Task<int> agregarTwitterAsync(string idUsuario, string screenName, string OauthToken, string OauthTokenSecret) {
            return base.Channel.agregarTwitterAsync(idUsuario, screenName, OauthToken, OauthTokenSecret);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<AeiCliente.ServicioAEI.Calificacion>> buscarCalificacionProductoAsync(int idProducto) {
            return base.Channel.buscarCalificacionProductoAsync(idProducto);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<AeiCliente.ServicioAEI.Producto>> BuscarProductoPorCategoriaAsync(string nombre) {
            return base.Channel.BuscarProductoPorCategoriaAsync(nombre);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<AeiCliente.ServicioAEI.Producto>> BusquedaProductoConCategoriaAsync(string categoriaProducto, string busqueda) {
            return base.Channel.BusquedaProductoConCategoriaAsync(categoriaProducto, busqueda);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<AeiCliente.ServicioAEI.Producto>> BusquedaProductoAsync(string busqueda) {
            return base.Channel.BusquedaProductoAsync(busqueda);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<AeiCliente.ServicioAEI.Categoria>> BuscarTodasLasCategoriasAsync() {
            return base.Channel.BuscarTodasLasCategoriasAsync();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<AeiCliente.ServicioAEI.Direccion>> consultarEstadosAsync() {
            return base.Channel.consultarEstadosAsync();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<AeiCliente.ServicioAEI.Direccion>> consultarCiudadAsync(int idEstado) {
            return base.Channel.consultarCiudadAsync(idEstado);
        }
        
        public System.Threading.Tasks.Task<int> agregarDireccionUsuarioAsync(int idUsuario, int idDireccion, string descripcion, int codigoPostal) {
            return base.Channel.agregarDireccionUsuarioAsync(idUsuario, idDireccion, descripcion, codigoPostal);
        }
        
        public System.Threading.Tasks.Task<AeiCliente.ServicioAEI.Usuario> agregarCarritoAsync(AeiCliente.ServicioAEI.Usuario usuario, AeiCliente.ServicioAEI.DetalleCompra detalleCompra) {
            return base.Channel.agregarCarritoAsync(usuario, detalleCompra);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<AeiCliente.ServicioAEI.Direccion>> buscarDireccionUsuarioAsync(int idUsuario) {
            return base.Channel.buscarDireccionUsuarioAsync(idUsuario);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IServicioAEI)) {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IServicioAEI)) {
                return new System.ServiceModel.EndpointAddress("http://localhost:52896/Logica/ServicioAEI.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding() {
            return ServicioAEIClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IServicioAEI);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress() {
            return ServicioAEIClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IServicioAEI);
        }
        
        public enum EndpointConfiguration {
            
            BasicHttpBinding_IServicioAEI,
        }
    }
}

