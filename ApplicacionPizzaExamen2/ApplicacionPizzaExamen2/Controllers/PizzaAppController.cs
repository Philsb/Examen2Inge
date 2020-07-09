using ApplicacionPizzaExamen2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace ApplicacionPizzaExamen2.Controllers
{
    public class PizzaAppController : Controller
    {
        public ActionResult Index()
        {
            if (TempData["MensajeExito"] != null)
            {
                ViewBag.MensajeExito = TempData["MensajeExito"];
            }
            if (TempData["MensajeCancelar"] != null) {
                ViewBag.MensajeCancelar = TempData["MensajeCancelar"];

            }
            if (TempData["MensajeError"] != null)
            {
                ViewBag.MensajeError = TempData["MensajeError"];
            }
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult NuestrosIngredientes() {
            return View();
        }

        public ActionResult MostrarCarrito()
        {
            if (TempData["Factura"] != null)
            {
                ViewBag.Factura = TempData["Factura"];
            }

            return View();
        }

        [HttpPost]
        public ActionResult SumarACarrito(PizzaOrdenModel model) {
            PizzaFacturaModel factura;
            try {
                factura = CalcularPrecios(model);
            }
            catch (Exception ex) {
                Console.WriteLine("Error: {0}", ex.ToString());
                @TempData["MensajeError"] = "Error al tramitar orden.";
                return RedirectToAction("Index", "PizzaApp");

            }
            @TempData["Factura"] = factura;

            return RedirectToAction("MostrarCarrito", "PizzaApp");
        }

        public ActionResult TramitarOrden(string estadoOrden) {

            if (estadoOrden.Equals("Cancelada")) {
                @TempData["MensajeCancelar"] = "Orden cancelada.";
            }
            if (estadoOrden.Equals("Aceptada"))
            {
                @TempData["MensajeExito"] = "Pizza ordenada! Su comida debería llegar pronto al lugar de destino.";
            }

            return RedirectToAction("Index", "PizzaApp");
        }

        public PizzaFacturaModel CalcularPrecios(PizzaOrdenModel model) {
            PizzaFacturaModel factura = new PizzaFacturaModel();
            Productos productos = new Productos();

            factura.Orden = model;

            //Calcula el precio base de la pizza, sin los toppings
            factura.PrecioTamanoPizza = productos.GetPrecioDeProducto(model.TamanoPizza);
            factura.PrecioMasaPizza = productos.GetPrecioDeProducto(model.MasaPizza);
            factura.PrecioSalsaPizza = productos.GetPrecioDeProducto(model.SalsaPizza);
            factura.PrecioQuesoPizza = productos.GetPrecioDeProducto(model.QuesoPizza);
            factura.PrecioTotalBase = factura.PrecioTamanoPizza + factura.PrecioMasaPizza + factura.PrecioSalsaPizza + factura.PrecioQuesoPizza;

            
            //Calcula la parte de precio de toppings
            foreach (string producto in model.ListaToppings) {
                double precioTopping = productos.GetPrecioDeProducto(producto);
                factura.ListaPrecioToppings.Add(precioTopping);
                factura.PrecioTotalToppings += precioTopping;
            }

            //Calcula los precios finales sumados con el 13% de impuesto;
            factura.PrecioEnvio = 1000.00;
            factura.PrecioSubtotal = factura.PrecioTotalBase + factura.PrecioTotalToppings + factura.PrecioEnvio;
            factura.PrecioImpuesto = (factura.PrecioSubtotal * 0.13);
            factura.PrecioTotal = factura.PrecioSubtotal + factura.PrecioImpuesto;

            return factura;
        }

    }
}