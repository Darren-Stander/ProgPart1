using System;
using System.Collections.Generic;
using System.Linq;


namespace ProgPart1
{



    internal class Recipe
    {
        // Properties for recipe details
        public string Name { get; set; }
        private List<Ingredient> ingredients; // List to store ingredients
        private List<string> steps;          // List to store steps
        private bool isScaled;            // Flag to indicate if the recipe is scaled
        private double scaleFactor;          // Factor to scale the recipe by

        // Delegate for handling calorie exceeded event
        public delegate void CaloriesExceededHandler(string message);

        // Event to notify when calories exceed 300
        public event CaloriesExceededHandler CalorieExceeded;

        // Constructor to initialize a recipe object
        public Recipe(string name)
        {
            Name = name;
            ingredients = new List<Ingredient>();
            steps = new List<string>();
            isScaled = false;
            scaleFactor = 1.0;
        }

        // Method to enter ingredients for the recipe
        public void EnterIngredients()
        {
            try
            {
                Console.Write("\nPlease enter the number of ingredients: ");
                int numIngredients = int.Parse(Console.ReadLine());

                for (int i = 0; i < numIngredients; i++)
                {
                    Console.Write("\nIngredient name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter quantity: ");
                    double quantity = double.Parse(Console.ReadLine());

                    Console.Write("Please indicate the unit of measurement: ");
                    string unit = Console.ReadLine();

                    Console.Write("Enter number of calories: ");
                    int calories = int.Parse(Console.ReadLine());

                    Console.Write("Enter food group: ");
                    string foodGroup = Console.ReadLine();

                    ingredients.Add(new Ingredient(name, quantity, unit, calories, foodGroup));
                }

                // Check if total calories exceed 300 and raise event
                CheckCalories();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while entering ingredients: {ex.Message}");
            }
        }

        // Method to enter steps for the recipe
        public void EnterSteps()
        {
            try
            {
                Console.Write("\nProvide the number of instructions: ");
                int numSteps = int.Parse(Console.ReadLine());

                for (int i = 0; i < numSteps; i++)
                {
                    Console.Write("Step: ");
                    string step = Console.ReadLine();
                    steps.Add(step);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while entering steps: {ex.Message}");
            }
        }

        // Method to display the recipe details
        public void DisplayRecipe()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Blue;

                if (ingredients.Count == 0 || steps.Count == 0)
                {
                    Console.WriteLine("No recipe data available.");
                    return;
                }

                Console.WriteLine($"\nRecipe: {Name}");
                Console.WriteLine("\nIngredients:");
                foreach (Ingredient ingredient in ingredients)
                {
                    double adjustedQuantity = isScaled ? ingredient.Quantity * scaleFactor : ingredient.Quantity;
                    Console.WriteLine($"{adjustedQuantity} {ingredient.Unit} of {ingredient.Name} - {ingredient.Calories} calories ({ingredient.FoodGroup})");
                }

                Console.WriteLine("\nSteps:");
                for (int i = 0; i < steps.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {steps[i]}");
                }

                // Display total calories
                DisplayTotalCalories();

                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while displaying the recipe: {ex.Message}");
            }
        }

        // Method to calculate and display total calories for the recipe
        private void DisplayTotalCalories()
        {
            try
            {
                int totalCalories = ingredients.Sum(ingredient => ingredient.Calories);
                Console.WriteLine($"\nTotal Calories: {totalCalories}");

                // Raise the CalorieExceeded event if needed
                if (totalCalories > 300)
                {
                    CalorieExceeded?.Invoke($"Warning: The total calories for the recipe '{Name}' exceed 300.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while calculating total calories: {ex.Message}");
            }
        }

        // Method to check if total calories exceed 300
        private void CheckCalories()
        {
            int totalCalories = ingredients.Sum(ingredient => ingredient.Calories);
            if (totalCalories > 300)
            {
                CalorieExceeded?.Invoke($"Warning: The total calories of the recipe \"{Name}\" exceed 300!");
            }
        }

        // Method to scale the recipe
        public void ScaleRecipe()
        {
            try
            {
                Console.Write("Enter the scale factor (0.5, 2 or 3): ");
                double factor = double.Parse(Console.ReadLine());

                if (factor == 0.5 || factor == 2 || factor == 3)
                {
                    isScaled = true;
                    scaleFactor = factor;

                    // Scale the ingredient quantities
                    foreach (Ingredient ingredient in ingredients)
                    {
                        if (ingredient.Unit == "teaspoon")
                        {
                            ingredient.Quantity *= factor * 3;
                        }
                        else if (ingredient.Unit == "tablespoon")
                        {
                            ingredient.Quantity *= factor * 3;
                        }
                        else if (ingredient.Unit == "cup")
                        {
                            if (factor == 0.5)
                            {
                                ingredient.Quantity *= 8 * factor;
                            }
                            else if (factor == 2)
                            {
                                ingredient.Quantity *= 16 * factor;
                            }
                            else if (factor == 3)
                            {
                                ingredient.Quantity *= 16 * factor;
                            }
                        }
                    }
                    Console.WriteLine("\nRecipe was successfully scaled.");
                }
                else
                {
                    Console.WriteLine("You can only scale by 0.5, 2, or 3.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. You can only scale by 0.5, 2, or 3.");
            }
        }

        // Method to reset the recipe scaling
        public void ResetRecipe()
        {
            isScaled = false;
            scaleFactor = 1.0;
            Console.WriteLine("\nSuccessfully reset the measurements to their original values.");
        }

        // Method to delete the recipe
        public void DeleteRecipe()
        {
            ingredients.Clear();
            steps.Clear();
            isScaled = false;
            scaleFactor = 1.0;
            Console.WriteLine("\nRecipe cleared. You're welcome to add a new one.");
        }
    }
}








//----------------------------------------EndOfFile------------------------------------------//
