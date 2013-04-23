using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AeiWebServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioDAO
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        int setCompra(Compra compra);

        [OperationContract]
        List<Categoria> getListaCategoria();

        [OperationContract]
        Categoria buscarProductoPorCategoria(int idProducto);

        [OperationContract]
        List<Tag> buscarTagPorProducto(int idproducto);

        [OperationContract]
        int setCantidadProducto(int idProducto, int cantidadEnExistencia);

        [OperationContract]
        List<Producto> getProductos();

        [OperationContract]
        List<Producto> getProductoPorNombre(String nombre);

        [OperationContract]
        List<Producto> getProductoPorCategoria(String nombreCategoria);

        [OperationContract]
        Producto getProductoPorDetalleCompra(int idDetalleCompra);

        [OperationContract]
        int setAgregarCompra(Compra compra);

        [OperationContract]
        int setEstadoDeCompra(String status, int idCompra);

        [OperationContract]
        int setMetodoPago(MetodoPago metodo, int idUsuario);

        [OperationContract]
        MetodoPago getMetodoPagoPorCompra(int idCompra);

        [OperationContract]
        int setModificarMetodoPago(MetodoPago metodoModificado, int idMetodoActual, int idUsuario);

        [OperationContract]
        Direccion getDireccionDeCompra(int idCompra);

        [OperationContract]
        int setUsuario(Usuario usuarioModificado, int idUsuario);
        // TODO: agregue aquí sus operaciones de servicio
    }
}
