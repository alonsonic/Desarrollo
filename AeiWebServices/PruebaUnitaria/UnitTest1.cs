using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AeiWebServices;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using AeiWebServices.Permanencia;

namespace PruebaUnitaria
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void consultarCalificacionesPorProducto_test()
        {
            var test_object = new SqlServerCalificacion();
            int respuesta = test_object.agregarCalificacion(null,1,1);
            Assert.AreEqual<int>(0, respuesta, "No paso la prueba");
        }        
    }
}
