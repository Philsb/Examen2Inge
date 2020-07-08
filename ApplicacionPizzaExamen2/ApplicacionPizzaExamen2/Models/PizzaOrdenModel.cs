using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApplicacionPizzaExamen2.Models
{
    public class PizzaOrdenModel
    {
        public List<string> ListaToppings { get; set; }
        public string TamanoPizza { get; set; }
        public string MasaPizza { get; set; }
        public string SalsaPizza { get; set; }
        public string QuesoPizza { get; set; }
        public string NombreCliente { get; set; }
        public string CiudadCliente { get; set; }
        public string DireccionCliente { get; set; }
        public string NumeroCliente { get; set; }

    }
}