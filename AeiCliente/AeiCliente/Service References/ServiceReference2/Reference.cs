﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.18033
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.VisualStudio.ServiceReference.Platforms, version 11.0.50727.1
// 
namespace AeiCliente.ServiceReference2 {
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Producto", Namespace="http://schemas.datacontract.org/2004/07/AeiWebServices")]
    public partial class Producto : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string DescripcionField;
        
        private int IdField;
        
        private string ImagenDetalleField;
        
        private string ImagenMiniaturaField;
        
        private string NombreField;
        
        private float PrecioField;
        
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Usuario", Namespace="http://schemas.datacontract.org/2004/07/AeiWebServices")]
    public partial class Usuario : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string ApellidoField;
        
        private AeiCliente.ServiceReference2.Compra CarritoField;
        
        private string CodigoActivacionField;
        
        private System.Collections.Generic.List<AeiCliente.ServiceReference2.Compra> ComprasField;
        
        private System.Collections.Generic.List<AeiCliente.ServiceReference2.Direccion> DireccionesField;
        
        private string EmailField;
        
        private System.DateTime FechaNacimientoField;
        
        private System.DateTime FechaRegistroField;
        
        private int IdField;
        
        private System.Collections.Generic.List<AeiCliente.ServiceReference2.MetodoPago> MetodosPagoField;
        
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
        public AeiCliente.ServiceReference2.Compra Carrito {
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
        public string CodigoActivacion {
            get {
                return this.CodigoActivacionField;
            }
            set {
                if ((object.ReferenceEquals(this.CodigoActivacionField, value) != true)) {
                    this.CodigoActivacionField = value;
                    this.RaisePropertyChanged("CodigoActivacion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.List<AeiCliente.ServiceReference2.Compra> Compras {
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
        public System.Collections.Generic.List<AeiCliente.ServiceReference2.Direccion> Direcciones {
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
        public System.Collections.Generic.List<AeiCliente.ServiceReference2.MetodoPago> MetodosPago {
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
        
        private AeiCliente.ServiceReference2.Direccion DireccionField;
        
        private System.DateTime FechaEntregaField;
        
        private System.DateTime FechaSolicitudField;
        
        private int IdField;
        
        private float MontoTotalField;
        
        private AeiCliente.ServiceReference2.MetodoPago PagoField;
        
        private string StatusField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public AeiCliente.ServiceReference2.Direccion Direccion {
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
        public AeiCliente.ServiceReference2.MetodoPago Pago {
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
    [System.Runtime.Serialization.DataContractAttribute(Name="MetodoPago", Namespace="http://schemas.datacontract.org/2004/07/AeiWebServices")]
    public partial class MetodoPago : object, System.ComponentModel.INotifyPropertyChanged {
        
        private System.DateTime FechaVencimientoField;
        
        private int IdField;
        
        private string MarcaField;
        
        private int NumeroField;
        
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
        public int Numero {
            get {
                return this.NumeroField;
            }
            set {
                if ((this.NumeroField.Equals(value) != true)) {
                    this.NumeroField = value;
                    this.RaisePropertyChanged("Numero");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference2.IIMPLEMENTAR")]
    public interface IIMPLEMENTAR {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIMPLEMENTAR/buscarListaProducto", ReplyAction="http://tempuri.org/IIMPLEMENTAR/buscarListaProductoResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<AeiCliente.ServiceReference2.Producto>> buscarListaProductoAsync(string busqueda);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIMPLEMENTAR/buscarUsuario", ReplyAction="http://tempuri.org/IIMPLEMENTAR/buscarUsuarioResponse")]
        System.Threading.Tasks.Task<AeiCliente.ServiceReference2.Usuario> buscarUsuarioAsync(string correo);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IIMPLEMENTARChannel : AeiCliente.ServiceReference2.IIMPLEMENTAR, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class IMPLEMENTARClient : System.ServiceModel.ClientBase<AeiCliente.ServiceReference2.IIMPLEMENTAR>, AeiCliente.ServiceReference2.IIMPLEMENTAR {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public IMPLEMENTARClient() : 
                base(IMPLEMENTARClient.GetDefaultBinding(), IMPLEMENTARClient.GetDefaultEndpointAddress()) {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IIMPLEMENTAR.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public IMPLEMENTARClient(EndpointConfiguration endpointConfiguration) : 
                base(IMPLEMENTARClient.GetBindingForEndpoint(endpointConfiguration), IMPLEMENTARClient.GetEndpointAddress(endpointConfiguration)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public IMPLEMENTARClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(IMPLEMENTARClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public IMPLEMENTARClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(IMPLEMENTARClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public IMPLEMENTARClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<AeiCliente.ServiceReference2.Producto>> buscarListaProductoAsync(string busqueda) {
            return base.Channel.buscarListaProductoAsync(busqueda);
        }
        
        public System.Threading.Tasks.Task<AeiCliente.ServiceReference2.Usuario> buscarUsuarioAsync(string correo) {
            return base.Channel.buscarUsuarioAsync(correo);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IIMPLEMENTAR)) {
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
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IIMPLEMENTAR)) {
                return new System.ServiceModel.EndpointAddress("http://localhost:52896/IMPLEMENTAR.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding() {
            return IMPLEMENTARClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IIMPLEMENTAR);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress() {
            return IMPLEMENTARClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IIMPLEMENTAR);
        }
        
        public enum EndpointConfiguration {
            
            BasicHttpBinding_IIMPLEMENTAR,
        }
    }
}