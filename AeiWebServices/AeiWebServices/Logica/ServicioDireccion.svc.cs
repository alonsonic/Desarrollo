using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using AeiWebServices.Permanencia;

namespace AeiWebServices.Logica
{
    public class ServicioDireccion : IServicioDireccion
    {

        public List<Direccion> consultarEstados()
        {
            return FabricaDAO.getEstado(); 

        }

        public List<Direccion> consultarCiudad(int idEstado)
        {
            return FabricaDAO.getCiudad(idEstado);
        }


        public int AgregarDireccionUsuario(int idUsuario, int idDireccion, Direccion direccion)
        {
            return FabricaDAO.setAgregarDetalleDireccion(idUsuario, idDireccion, direccion);

        }

    }
}
