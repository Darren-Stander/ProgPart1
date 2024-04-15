using System;
using System.Collections.Generic;

namespace ProgPart1
{


    internal class Ingredient               // This class represents an ingredient with a name, quantity, and unit of measurement
    {
        public string Name { get; set; }        // Name of the ingredients
        public double Quantity { get; set; }        // Quantity of ingredients
        public string Unit { get; set; }            // Unit used for the measurement of ingredients

        public Ingredient(string name, double quantity, string unit)        // Constructor to initialize an instance of the Ingredient class with provided values
        {
            Name = name;        // Name property with name provided
            Quantity = quantity;    //Quantity property with qauntity provided
            Unit = unit;        // Unit property with unit provided
        }
    }
}
