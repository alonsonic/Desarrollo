using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AeiWebServices.Logica;
using AeiWebServices;
using AeiWebServices.Permanencia;
using AeiWebServices.Dominio;
using System.Collections.Generic;

namespace PruebaUnitariaBusqueda
{
    [TestClass]
    public class TestCalificacion
    {
        Calificacion calificacion;
        SqlServerCalificacion sqlCalificacion;
        List<Calificacion> calificaciones;

        [TestInitialize]
        public void inicio()
        { 
            sqlCalificacion = new SqlServerCalificacion();
            calificacion = new Calificacion(13, 4, "Buen juego", DateTime.Now, null);
        }

        [TestMethod]
        public void testAgregarCalificacionNull()
        {
            int respuesta = sqlCalificacion.agregarCalificacion(null, 1, 1);
            Assert.AreEqual<int>(0, respuesta, "Se esperaba un 0 pero se obtuvo un 1");
        }

        [TestMethod]
        public void testAgregarCalificacion()
        {
            Calificacion calificacion = new Calificacion(13, 4, "Buen juego", DateTime.Now, null);
            int respuesta = sqlCalificacion.agregarCalificacion(calificacion, 1, 1);
            Assert.AreEqual<int>(1, respuesta, "La calificación no fue agregada");
        }

        [TestMethod]
        public void testAgregarBuscarCalificacion()
        {
            sqlCalificacion.agregarCalificacion(calificacion, 1, 1);
            //El valor del ID es autogenerado en la Base de Datos, por lo que debe de arreglarse a la hora de 
            //correr la prueba            
            calificaciones = sqlCalificacion.consultarCalificacionesPorProducto(1);
            Calificacion calificacionBusqueda = calificaciones[calificaciones.Count - 1];
            Assert.AreEqual<Calificacion>(calificacion, calificacionBusqueda, "Las calificaciones no son iguales.");
        }

        [TestCleanup]
        public void final()
        {
            calificacion=null;
            sqlCalificacion=null;
            calificaciones=null;
        }
    }
}
