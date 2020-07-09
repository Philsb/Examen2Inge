using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplicacionPizzaExamen2.Models
{
    public class Productos
    {
        private IDictionary<string, double> Precios = new Dictionary<string, double>();
        private IList<string> Tamaños = new List<string>();
        private IList<string> Masas = new List<string>();
        private IList<string> Salsas = new List<string>();
        private IList<string> Quesos = new List<string>();
        private IList<string> Toppings = new List<string>();

        public Productos() {
            AddPrecios();
        }


        private void AddPrecios() {
            //precios de Tamaño
            Precios.Add("Pequeña", 4000.00);
            Precios.Add("Mediana", 5000.00);
            Precios.Add("Grande", 6000.00);
            //Precios de Masa
            Precios.Add("Masa regular", 0.00);
            Precios.Add("Masa fina", 100.00);
            Precios.Add("Masa gruesa", 200.00);
            //Precios de Salsa
            Precios.Add("Tomate", 0.00);
            Precios.Add("Pesto", 400.00);
            Precios.Add("Buffalo", 300.00);
            Precios.Add("Crema y ajo", 300.0);
            //Precios de Queso
            Precios.Add("Mozzarella", 300.00);
            Precios.Add("Parmesano", 400.0);
            Precios.Add("Cuatro quesos", 500.00);
            Precios.Add("Sin queso", 0.00);
            //Precios de toppings
            Precios.Add("Jamón", 50.00);
            Precios.Add("Pepperoni", 50.00);
            Precios.Add("Tocino", 350.00);
            Precios.Add("Carne molida", 50.00);
            Precios.Add("Salami", 350.00);
            Precios.Add("Pollo", 50.00);
            Precios.Add("Chorizo", 400.00);
            Precios.Add("Fajitas", 150.00);
            Precios.Add("Champiñones", 150.00);
            Precios.Add("Aceitunas", 100.00);
            Precios.Add("Piña", 50.00);
            Precios.Add("Cebolla morada", 50.00);
            Precios.Add("Chile dulce", 50.00);
            Precios.Add("Espinaca", 100.00);
            Precios.Add("Jalapeño", 100.00);
            Precios.Add("Culantro", 50.00);
        }

        public double GetPrecioDeProducto(string producto) {
            double precio;
            try
            {
                precio = Precios[producto];
            }
            catch (KeyNotFoundException)
            {
                return -1.00;
            }

            return precio;
        }


    }
}