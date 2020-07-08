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
        public IList<string> ListaToppings { get; set; } = new List<string>();
        [Required]
        public string TamanoPizza { get; set; }
        [Required]
        public string MasaPizza { get; set; }
        [Required]
        public string SalsaPizza { get; set; }
        [Required]
        public string QuesoPizza { get; set; }
        [Required(ErrorMessage = "Por favor ingrese un nombre con que identificarse.")]
        [MaxLength(200, ErrorMessage = "El nombre no puede ser mayor a 200 caracteres.")]
        public string NombreCliente { get; set; }
        [Required(ErrorMessage = "Por favor ingrese la ciudad de envio.")]
        [MaxLength(200, ErrorMessage = "El nombre de la ciudad no puede ser mayor a 200 caracteres.")]
        public string CiudadCliente { get; set; }
        [Required(ErrorMessage = "Por favor ingrese la dirección de envio.")]
        [MaxLength(1500, ErrorMessage = "La dirección de envio no puede ser mayor a 1500 caracteres.")]
        public string DireccionCliente { get; set; }
        [Required(ErrorMessage = "Por favor ingrese su número telefónico")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "Por favor ingrese un númerico telefónico de 8 cifras.")]
        [RegularExpression("^[0-9]*$",
         ErrorMessage = "Solo caracteres del 0-9 son permitidos.")]
        public string NumeroCliente { get; set; }

    }

    public class PizzaFacturaModel
    {
        public PizzaOrdenModel Orden { get; set; }
        public IList<double> ListaPrecioToppings { get; set; } = new List<double>();
        public double PrecioTamanoPizza { get; set; }
        public double PrecioMasaPizza { get; set; }
        public double PrecioSalsaPizza { get; set; }
        public double PrecioQuesoPizza { get; set; }
        public double PrecioTotalBase { get; set; }
        public double PrecioTotalToppings { get; set; }
        public double PrecioEnvio { get; set; }
        public double PrecioSubtotal { get; set; }
        public double PrecioImpuesto { get; set; }
        public double PrecioTotal { get; set; }
    }


}