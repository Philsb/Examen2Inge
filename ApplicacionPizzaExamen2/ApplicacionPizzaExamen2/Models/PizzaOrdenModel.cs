using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApplicacionPizzaExamen2.Models
{
    public class PizzaOrdenModel
    {
        List<string> ListaToppings;
        [Required]
        string TamanoPizza;
        [Required]
        string MasaPizza;
        [Required]
        string SalsaPizza;
        [Required]
        string QuesoPizza;
        [Required]
        string NombreCliente;
        [Required]
        string CiudadCliente;
        [Required]
        string DireccionCliente;
        [Required]
        string NumeroCliente;

    }
}