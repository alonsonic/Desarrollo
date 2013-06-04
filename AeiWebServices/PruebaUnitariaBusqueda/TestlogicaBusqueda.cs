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
        [TestMethod]
        public void testBusquedaSinResultado()
        {
           var test_object = new logicaBusqueda();
           List<Producto> listaEsperada = null;
           List<Producto> actual = test_object.clasificarBusqueda("bloquessdfghj",1, 5);
           Assert.AreEqual<List<Producto>>(listaEsperada, actual, "No paso la prueba");
        }

        [TestMethod]
        public void testBusquedaConResultado()
        {
            var test_object = new logicaBusqueda();
            List<Producto> listaEsperada =new List<Producto>();
            listaEsperada.Add(new Producto(130, "Password ", "Por fin, el juego más esperado del año. Diviértete con el juego del programa de TV de Cuatro. Adivina todos los password y gana.", 3456, "mesa_130.jpg", "mesa_130.jpg", new Categoria(5, "Juegos de Mesa"), 1));
            List<Producto> actual = test_object.clasificarBusqueda("Password", 1, 5);
            bool respuesta = listaEsperada[0].comparacion(actual[0]);
            Assert.AreEqual<bool>(true, respuesta, "No paso la prueba");
        }

        [TestMethod]
        public void testBusquedaNula()
        {
            var test_object = new logicaBusqueda();
            List<Producto> listaEsperada = null;
            List<Producto> actual = test_object.clasificarBusqueda(null, 1, 5);
            Assert.AreEqual<List<Producto>>(listaEsperada, actual, "No paso la prueba");
        }

        [TestMethod]
        public void testBusquedaConPaginaYCantidadCero()
        {
            var test_object = new logicaBusqueda();
            List<Producto> listaEsperada = new List<Producto>();
            listaEsperada.Add(new Producto(130, "Password ", "Por fin, el juego más esperado del año. Diviértete con el juego del programa de TV de Cuatro. Adivina todos los password y gana.", 3456, "mesa_130.jpg", "mesa_130.jpg", new Categoria(5, "Juegos de Mesa"), 1));
            List<Producto> actual = test_object.clasificarBusqueda("Password", 0, 0);
            bool respuesta = false;
            if (actual!=null)
                 respuesta= listaEsperada[0].comparacion(actual[0]);
            Assert.AreEqual<bool>(true, respuesta, "No paso la prueba");
        }
    }
}
