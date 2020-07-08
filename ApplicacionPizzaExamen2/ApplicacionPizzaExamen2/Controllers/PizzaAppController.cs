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
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

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
                @TempData["Error"] = "Error al tramitar orden.";
                return RedirectToAction("Index", "PizzaApp");

            }
            @TempData["Factura"] = factura;
    
            return RedirectToAction("MostrarFactura", "PizzaApp");
        }

        public ActionResult MostrarFactura()
        {
            if (TempData["Factura"] != null) {
                ViewBag.Factura = TempData["Factura"];
            }

            return View();
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
            factura.PrecioConImpuestos = factura.PrecioSubtotal + (factura.PrecioSubtotal * 0.13);

            return factura;
        }

    }
}