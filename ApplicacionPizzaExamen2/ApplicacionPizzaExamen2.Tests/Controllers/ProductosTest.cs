using System;
using ApplicacionPizzaExamen2.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApplicacionPizzaExamen2.Tests.Controllers
{
    [TestClass]
    public class ProductosTest
    {
        [TestMethod]
        public void GetPrecioDeProducto_ReturnMenos1()
        {
            Productos prod = new Productos();
            double result = prod.GetPrecioDeProducto("");
            Assert.AreEqual(result, -1.00);
            double result2 = prod.GetPrecioDeProducto("No esta");
            Assert.AreEqual(result2, -1.00);
            double result3 = prod.GetPrecioDeProducto("No esta1234");
            Assert.AreEqual(result3, -1.00);
        }
        [TestMethod]
        public void GetPrecioDeProducto_ReturnTrue()
        {
            Productos prod = new Productos();
            double result = prod.GetPrecioDeProducto("Grande");
            Assert.AreEqual(result, 6000.00);
            double result2 = prod.GetPrecioDeProducto("Chile dulce");
            Assert.AreEqual(result2, 50.00);
            double result3 = prod.GetPrecioDeProducto("Cuatro quesos");
            Assert.AreEqual(result3, 500.00);
            double result4 = prod.GetPrecioDeProducto("Masa gruesa");
            Assert.AreEqual(result4, 200.00);
        }

    }
}
