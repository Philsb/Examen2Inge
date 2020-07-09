using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApplicacionPizzaExamen2;
using ApplicacionPizzaExamen2.Controllers;
using ApplicacionPizzaExamen2.Models;

namespace ApplicacionPizzaExamen2.Tests.Controllers
{
    [TestClass]
    public class PizzaAppControllerTest
    {
        [TestMethod]
        public void Index_NotNull()
        {
            PizzaAppController controller = new PizzaAppController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Contact_NotNull()
        {
            PizzaAppController controller = new PizzaAppController();
            ViewResult result = controller.Contact() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void MostrarCarrito_NotNull()
        {
            PizzaAppController controller = new PizzaAppController();
            ViewResult result = controller.MostrarCarrito() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void NuestrosIngredientes_NotNull()
        {
            PizzaAppController controller = new PizzaAppController();
            ViewResult result = controller.NuestrosIngredientes() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TramitarOrden_NotNull()
        {

            PizzaAppController controller = new PizzaAppController();
            ActionResult result = controller.TramitarOrden("Prueba") as ActionResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SumarACarrito_IsNotNull ()
        {
            PizzaAppController controller = new PizzaAppController();
            //Modelo vacio
            PizzaOrdenModel model = new PizzaOrdenModel();

            ActionResult result = controller.SumarACarrito(model) as ActionResult;
            //Deberia fallar si el modelo esta vacio o tiene algun atributo null
            Assert.IsNotNull(result);

            //Lo vuelve a tratar pero llenando el modelo
            model.ListaToppings = new List<string>();
            model.TamanoPizza = "tamano";
            model.MasaPizza = "Masa";
            model.QuesoPizza = "Salsa";
            model.QuesoPizza = "Queso";
            model.NombreCliente = "Nombre";
            model.CiudadCliente = "Ciudad";
            model.DireccionCliente = "Direccion";
            model.NumeroCliente = "12345678";
            ActionResult result2 = controller.SumarACarrito(model) as ActionResult;
            //Si todo sale bien la factura se guarda en TempData["Factura"]
            Assert.IsNotNull(result2);
        }

        [TestMethod]
        public void CalcularPrecios_ReturnTrue()
        {

            PizzaAppController controller = new PizzaAppController();

            PizzaOrdenModel model = new PizzaOrdenModel();
            model.ListaToppings = new List<string>();
            model.ListaToppings.Add("Champiñones");
            model.ListaToppings.Add("Jamón");
            model.ListaToppings.Add("Carne molida");
            model.ListaToppings.Add("Cebolla morada");
            model.ListaToppings.Add("Chile dulce");
            model.TamanoPizza = "Grande";
            model.MasaPizza = "Masa fina";
            model.SalsaPizza = "Pesto";
            model.QuesoPizza = "Parmesano";
            model.NombreCliente = "Nombre";
            model.CiudadCliente = "Ciudad";
            model.DireccionCliente = "Direccion";
            model.NumeroCliente = "12345678";
            PizzaFacturaModel factura = controller.CalcularPrecios(model);
            //Si todo sale bien la factura se guarda en TempData["Factura"]
            Assert.AreEqual((int)factura.PrecioSubtotal, 8250);
            Assert.AreEqual((int)factura.PrecioTotal, (int)(8250+ (8250 * 0.13)));
        }
    }
}
