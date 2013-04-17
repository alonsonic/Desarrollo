using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AeiWebServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "IMPLEMENTAR" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione IMPLEMENTAR.svc o IMPLEMENTAR.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class IMPLEMENTAR : IIMPLEMENTAR
    {
        public List<Producto> buscarListaProducto(string busqueda)
        {
            List<Producto> listaProducto = new List<Producto>();

            listaProducto.Add(new Producto(1,"Lego","Descripcion",10,"Imagen","imagen",null,32));
            listaProducto.Add(new Producto(2,"Muñeca","Descripcion",45,"imagen","imagen",null,20));
            listaProducto.Add(new Producto(3, "Barbie", "Descripcion", 21, "imagen", "imagen", null, 85));
            listaProducto.Add(new Producto(4, "Carrito", "Descripcion", 24, "imagen", "imagen", null, 76));
            listaProducto.Add(new Producto(5, "Yoyo", "Descripcion", 64, "imagen", "imagen", null, 54));
            listaProducto.Add(new Producto(6, "Jenga", "Descripcion", 54, "imagen", "imagen", null, 34));
            listaProducto.Add(new Producto(7, "Monopolio", "Descripcion", 27, "imagen", "imagen", null, 32));
            listaProducto.Add(new Producto(8, "Peluche", "Descripcion", 83, "imagen", "imagen", null, 45));
            listaProducto.Add(new Producto(9, "Super Mario", "Descripcion", 54, "imagen", "imagen", null, 64));
            listaProducto.Add(new Producto(10, "Cuerda de Saltar", "Descripcion", 95, "imagen", "imagen", null, 43));

            return listaProducto;
        }
    }
}
