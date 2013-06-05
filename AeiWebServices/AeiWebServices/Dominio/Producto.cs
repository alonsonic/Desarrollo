using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Serialization;

namespace AeiWebServices
{
    [DataContract]
    public class Producto
    {
        private int id;
        private string nombre;
        private string descripcion;
        private float precio;
        private string imagenMiniatura;
        private string imagenDetalle;
        private int cantidad;
        private Categoria categoria;
        private List<Tag> etiquetas;
        private List<Calificacion> calificaciones;

        public Producto(int id, string nombre, string descripcion, float precio, string imagenMiniatura, string imagenDetalle,
            Categoria categoria, int cantidad)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.precio = precio;
            this.cantidad = cantidad;
            this.imagenMiniatura = imagenMiniatura;
            this.imagenDetalle = imagenDetalle;
            this.categoria = categoria;
            this.etiquetas = null;
            this.calificaciones = null;
        }

        public Producto(){
        }
         [DataMember]
        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public void agregarTag(Tag tag)
        {
            this.etiquetas.Add(tag);
        }

        public void agregarCalificacionProducto(Calificacion calificacion)
        {
            this.calificaciones.Add(calificacion);
        }

         [DataMember]
        public List<Calificacion> Calificaciones
        {
            get { return calificaciones; }
            set { calificaciones = value; }
        }
         [DataMember]
        public List<Tag> Etiquetas
        {
            get { return etiquetas; }
            set { etiquetas = value; }
        }

         [DataMember]
        public Categoria Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        [DataMember]
        public string ImagenDetalle
        {
            get { return imagenDetalle; }
            set { imagenDetalle = value; }
        }

        [DataMember]
        public string ImagenMiniatura
        {
            get { return imagenMiniatura; }
            set { imagenMiniatura = value; }
        }

        [DataMember]
        public float Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        [DataMember]
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
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

        public bool comparacion(Producto producto)
        {
            if (producto!=null)
            {
                if (this.id == producto.id && this.nombre.Equals(producto.nombre) && this.descripcion.Equals(producto.descripcion)
                && this.precio == producto.precio && this.cantidad == producto.cantidad && this.imagenMiniatura.Equals(producto.imagenMiniatura)
                && this.imagenDetalle.Equals(producto.imagenDetalle) && this.categoria.Id == producto.categoria.Id
                && this.categoria.Nombre.Equals(producto.categoria.Nombre) && this.etiquetas == producto.etiquetas && this.calificaciones == producto.calificaciones)
                    return true;
            }
            return false;
        }

        public override string ToString()
        {
            return this.id +" "+ this.nombre+"";
        }

        
        
    }
}
