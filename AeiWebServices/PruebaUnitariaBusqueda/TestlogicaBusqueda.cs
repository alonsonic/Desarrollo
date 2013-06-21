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
    public class TestlogicaBusqueda
    {
        private List<Producto> listaEsperadaNull;
        private List<Producto> listaEsperadaBusquedaConResultado;
        private List<Producto> listaActualBusquedaVacia;
        private List<Producto> listaActualSinResultado;
        private List<Producto> listaActualConResultado;
        private List<Producto> listaActualBusquedaNula;
        private List<Producto> listaActualBusquedaConPaginaYCantidadCero;

        [TestInitialize]
        public void inicio()
        {
            listaEsperadaNull = null;
            listaEsperadaBusquedaConResultado = new List<Producto>();
            listaEsperadaBusquedaConResultado.Add(new Producto(130, "Password ", "Por fin, el juego más esperado del año. Diviértete con el juego del programa " +
                "" + "de TV de Cuatro. Adivina todos los password y gana.", 3456, "mesa_130.jpg", "mesa_130.jpg", new Categoria(5, "Juegos de Mesa"), 1));
        }

        [TestMethod]
        public void testBusquedaSinResultado()
        {
           var test_object = new logicaBusqueda();
           listaActualSinResultado=test_object.clasificarBusqueda("bloquessdfghj", 1, 5);
           Assert.AreEqual<List<Producto>>(listaEsperadaNull, listaActualSinResultado, "No paso la prueba");
        }

        [TestMethod]
        public void testBusquedaConResultado()
        {
            var test_object = new logicaBusqueda();
            listaActualConResultado = test_object.clasificarBusqueda("Password", 1, 5);
            bool respuesta = listaEsperadaBusquedaConResultado[0].comparacion(listaActualConResultado[0]);
            Assert.AreEqual<bool>(true, respuesta, "No paso la prueba");
        }

        [TestMethod]
        public void testBusquedaNula()
        {
            var test_object = new logicaBusqueda();
            listaActualBusquedaNula = test_object.clasificarBusqueda(null, 1, 5);
            Assert.AreEqual<List<Producto>>(listaEsperadaNull, listaActualBusquedaNula, "No paso la prueba");
        }

        [TestMethod]
        public void testBusquedaConPaginaYCantidadCero()
        {
            var test_object = new logicaBusqueda();
            listaActualBusquedaConPaginaYCantidadCero = test_object.clasificarBusqueda("Password", 0, 0);
            bool respuesta = false;
            if (listaActualBusquedaConPaginaYCantidadCero != null)
                respuesta = listaEsperadaBusquedaConResultado[0].comparacion(listaActualBusquedaConPaginaYCantidadCero[0]);
            Assert.AreEqual<bool>(false, respuesta, "No paso la prueba");
        }

        [TestMethod]
        public void testBusquedaVacia()
        {
            var test_object = new logicaBusqueda();
            listaActualBusquedaVacia = test_object.clasificarBusqueda("***", 2, 3);
            Assert.AreEqual<List<Producto>>(listaEsperadaNull, listaActualBusquedaVacia, "No paso la prueba");
        }

        [TestCleanup]
        public void final ()
        {
            listaEsperadaNull = null;
            listaEsperadaBusquedaConResultado = null;
        }
        
    }
}
