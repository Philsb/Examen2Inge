using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc.Routing.Constraints;

namespace ApplicacionPizzaExamen2.Models
{
    public class PizzaOrdenModel
    {
        public List<string> ListaToppings { get; set; }
        [Required]
        public string TamanoPizza { get; set; }
        [Required]
        public string MasaPizza { get; set; }
        [Required]
        public string SalsaPizza { get; set; }
        [Required]
        public string QuesoPizza { get; set; }
        [Required(ErrorMessage = "Por favor ingrese su nombre completo.")]
        public string NombreCliente { get; set; }
        [Required(ErrorMessage = "Por favor ingrese la ciudad de envio.")]
        public string CiudadCliente { get; set; }
        [Required(ErrorMessage = "Por favor ingrese la dirección de envio.")]
        public string DireccionCliente { get; set; }
        [Required(ErrorMessage = "Por favor ingrese su número telefónico")]
        [RegularExpression("^[0-9]*$",
         ErrorMessage = "Solo caracteres del 0-9 son permitidos.")]
        public string NumeroCliente { get; set; }

    }

    public class PizzaFacturaModel
    {
        public PizzaOrdenModel Orden { get; set; }
        public List<double> ListaPrecioToppings { get; set; }
        public double PrecioTamanoPizza { get; set; }
        public double PrecioMasaPizza { get; set; }
        public double PrecioSalsaPizza { get; set; }
        public double PrecioQuesoPizza { get; set; }
        public double PrecioTotalBase { get; set; }
        public double PrecioTotalToppings { get; set; }
        public double PrecioEnvio { get; set; }
        public double PrecioSubtotal { get; set; }
        public double PrecioConImpuestos { get; set; }
    }


}