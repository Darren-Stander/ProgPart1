using System;
using System.Collections.Generic;

namespace ProgPart1
{

    

    internal class Recipe
    {
        private List<Ingredient> ingredients; // Corrected type and naming
        private List<string> steps;
        private bool isScaled;
        private double scaleFactor;

        public Recipe()
        {
            ingredients = new List<Ingredient>(); // Corrected naming
            steps = new List<string>();
            isScaled = false;
            scaleFactor = 1.0;
        }

        public void EnterIngredients()
        {
            int numIngredients;
            while (true)
            {
                Console.Write("Enter the number of ingredients: ");
                if (int.TryParse(Console.ReadLine(), out numIngredients) && numIngredients > 0)
                    break;
                Console.WriteLine("Invalid input. Please enter a positive integer.");
            }

            for (int i = 0; i < numIngredients; i++)
            {
                Console.Write("Enter ingredient name: ");
                string name = Console.ReadLine();

                double quantity;
                while (true)
                {
                    Console.Write("Enter quantity: ");
                    if (double.TryParse(Console.ReadLine(), out quantity) && quantity > 0)
                        break;
                    Console.WriteLine("Invalid input. Please enter a positive number.");
                }

                Console.Write("Enter unit of measurement: ");
                string unit = Console.ReadLine();

                ingredients.Add(new Ingredient(name, quantity, unit)); // Corrected naming
            }
        }

        public void EnterSteps()
        {
            int numSteps;
            while (true)
            {
                Console.Write("Enter the number of steps: ");
                if (int.TryParse(Console.ReadLine(), out numSteps) && numSteps > 0)
                    break;
                Console.WriteLine("Invalid input. Please enter a positive integer.");
            }

            for (int i = 0; i < numSteps; i++)
            {
                Console.Write("Enter step description: ");
                string step = Console.ReadLine();
                steps.Add(step);
            }
        }

        public void DisplayRecipe() // Corrected method name
        {
            if (ingredients.Count == 0 || steps.Count == 0)
            {
                Console.WriteLine("No recipe data available.");
                return;
            }

            Console.WriteLine("Recipe:");

            Console.WriteLine("\nIngredients:");
            foreach (Ingredient ingredient in ingredients)
            {
                double adjustedQuantity = isScaled ? ingredient.Quantity * scaleFactor : ingredient.Quantity;
                Console.WriteLine($"{adjustedQuantity} {ingredient.Unit} of {ingredient.Name}");
            }

            Console.WriteLine("\nSteps:");
            for (int i = 0; i < steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }
        }

        public void ScaleRecipe()
        {
            double factor;
            while (true)
            {
                Console.Write("Enter the scale factor(0.5, 2 0r 3): ");
                if (double.TryParse(Console.ReadLine(), out factor) && (factor == 2 || factor == 3))
                {
                    isScaled = true;
                    scaleFactor = factor;
                    Console.WriteLine("Recipe was successfully scaled");
                    return;

                }
                Console.WriteLine(" You can only scale by 0.5, 2 or 3 ");
            }
        }
        public void ResetRecipe()
        {
            isScaled = false;
            scaleFactor = 1.0;
            Console.WriteLine("Successfully reset the measurements to it's original value");
        }

        public void DeleteRecipe()
        {
            ingredients.Clear();
            steps.Clear();
            isScaled = false;
            scaleFactor = 1.0;
            Console.WriteLine("Recipe has been cleared. Feel free to add a new recipe.");
            EnterIngredients();
            EnterSteps();
        }
    }
}
