using System;
using System.Collections.Generic;
using System.IO;

namespace ProgPart1
{
    internal class Ingredient
    {
        // Properties for ingredient details
        public string Name { get; set; } // Name of the ingredient
        public double Quantity { get; set; } // Quantity of the ingredient
        public string Unit { get; set; } // Unit of measurement for the ingredient
        public int Calories { get; set; } // Number of calories in the ingredient
        public string FoodGroup { get; set; } // Food group the ingredient belongs to

        // Constructor to initialize an ingredient object
        public Ingredient(string name, double quantity, string unit, int calories, string foodGroup)
        {
            Name = name; // Set the name of the ingredient
            Quantity = quantity; // Set the quantity of the ingredient
            Unit = unit; // Set the unit of measurement for the ingredient
            Calories = calories; // Set the number of calories in the ingredient
            FoodGroup = foodGroup; // Set the food group of the ingredient
        }
    }
}                   // End of File