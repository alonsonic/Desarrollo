using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AeiWebServices.Logica;
using AeiWebServices;
using AeiWebServices.Permanencia;
using System.Collections.Generic;
namespace PruebaUnitariaBusqueda
{
    [TestClass]
    public class TestlogicaBusqueda
    {
        [TestMethod]
        public void testBusquedaSinResultado()
        {
           var test_object = new logicaBusqueda();
           List<Producto> listaEsperada = null;
           List<Producto> actual = test_object.clasificarBusqueda("bloquessdfghj",1, 5);
           Assert.AreEqual<List<Producto>>(listaEsperada, actual, "No paso la prueba");
        }
    }
}
