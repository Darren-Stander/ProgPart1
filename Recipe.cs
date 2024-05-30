using System;
using System.Collections.Generic;
using System.Linq;

namespace ProgPart1
{
    internal class Recipe
    {
        // Properties for recipe details
        public string Name { get; set; } // Name of the recipe
        private List<Ingredient> ingredients; // List to store ingredients
        private List<string> steps; // List to store steps
        private bool isScaled; // Flag to indicate if the recipe is scaled
        private double scaleFactor; // Factor to scale the recipe by

        // Delegate for handling calorie exceeded event
        public delegate void CaloriesExceededHandler(string message);

        // Event to notify when calories exceed 300
        public event CaloriesExceededHandler CalorieExceeded;

        // Constructor to initialize a recipe object
        public Recipe(string name)
        {
            Name = name; // Set the name of the recipe
            ingredients = new List<Ingredient>(); // Initialize the ingredients list
            steps = new List<string>(); // Initialize the steps list
            isScaled = false; // Set the scaling flag to false by default
            scaleFactor = 1.0; // Set the scale factor to 1.0 by default (no scaling)
        }

        // Method to get valid string input
        private string GetValidStringInput(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input) && input.All(char.IsLetter))
                {
                    return input;
                }
                Console.WriteLine("Invalid input. Please enter a valid string.");
            }
        }



        // Method to enter ingredients for the recipe
        public void EnterIngredients()
        {
            try
            {
                int numIngredients = GetValidIntInput("\nPlease enter the number of ingredients: ");

                for (int i = 0; i < numIngredients; i++)
                {
                    string name = GetValidStringInput("\nIngredient name: ");
                    double quantity = GetValidDoubleInput("Enter quantity: ");
                    string unit = GetValidStringInput("Please indicate the unit of measurement: ");
                    int calories = GetValidIntInput("Enter number of calories: ");
                    string foodGroup = GetValidStringInput("Enter food group: ");

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

        // Method to get valid integer input
        private int GetValidIntInput(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    return result;
                }
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }

        // Method to get valid double input
        private double GetValidDoubleInput(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out double result))
                {
                    return result;
                }
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        // Method to enter steps for the recipe
        public void EnterSteps()
        {
            try
            {
                int numSteps = GetValidIntInput("\nProvide the number of instructions: ");

                for (int i = 0; i < numSteps; i++)
                {
                    string step = GetValidStringInput("Step: ");
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

                // Display an alert if total calories exceed 300
                if (totalCalories > 300)
                {
                    DisplayCalorieAlert(totalCalories);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while calculating total calories: {ex.Message}");
            }
        }

        // Method to display an alert when calories exceed 300
        private void DisplayCalorieAlert(int totalCalories)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Warning: The total calories for the recipe '{Name}' exceed 300.");
            DisplayCalorieInformation(totalCalories);
            Console.ResetColor();
        }

        // Method to display information relevant to the number of calories
        private void DisplayCalorieInformation(int totalCalories)
        {
            Console.WriteLine("Calorie Information:");
            Console.WriteLine($"Total Calories: {totalCalories}");

            // Recommended daily calorie intake
            int recommendedDailyCalories = 2000; // Assuming a recommended daily intake of 2000 calories
            Console.WriteLine($"Recommended Daily Calorie Intake: {recommendedDailyCalories}");

            // Percentage of recommended daily intake
            double percentageOfRecommendedIntake = (double)totalCalories / recommendedDailyCalories * 100;
            Console.WriteLine($"Percentage of Recommended Daily Intake: {percentageOfRecommendedIntake:F2}%");

            // Suggestions for reducing calories
            if (totalCalories > recommendedDailyCalories)
            {
                Console.WriteLine("Suggestions for Reducing Calories: ");
                Console.WriteLine("- Use low-calorie ingredients or substitutes");
                Console.WriteLine("- Reduce portion sizes");
                Console.WriteLine("- Avoid high-calorie ingredients or condiments");
                Console.WriteLine("- Increase physical activity");
            }
        }

        // Method to check if total calories exceed 300
        private void CheckCalories()
        {
            int totalCalories = ingredients.Sum(ingredient => ingredient.Calories);
            if (totalCalories > 300)
            {
                // Invoke the CalorieExceeded event
                CalorieExceeded?.Invoke($"Warning: The total calories of the recipe \"{Name}\" exceed 300. The total calorie count is {totalCalories}.");
            }
        }

        // Method to scale the recipe
        public void ScaleRecipe()
        {
            try
            {
                double factor = GetValidDoubleInput("Enter the scale factor (0.5, 2 or 3): ");

                if (factor == 0.5 || factor == 2 || factor == 3)
                {
                    isScaled = true;
                    scaleFactor = factor;

                    // Scale the ingredient quantities
                    foreach (Ingredient ingredient in ingredients)
                    {
                        if (ingredient.Unit == "teaspoon" || ingredient.Unit == "tablespoon")
                        {
                            ingredient.Quantity *= factor * 3;
                        }
                        else if (ingredient.Unit == "cup")
                        {
                            if (factor == 0.5)
                            {
                                ingredient.Quantity *= 8 * factor;
                            }
                            else if (factor == 2 || factor == 3)
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
