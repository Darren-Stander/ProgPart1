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

        // Method to enter ingredients for the recipe
        public void EnterIngredients()
        {
            try
            {
                Console.Write("\nPlease enter the number of ingredients: ");
                int numIngredients = int.Parse(Console.ReadLine()); // Get the number of ingredients from the user

                for (int i = 0; i < numIngredients; i++)
                {
                    Console.Write("\nIngredient name: ");
                    string name = Console.ReadLine(); // Get the ingredient name from the user

                    Console.Write("Enter quantity: ");
                    double quantity = double.Parse(Console.ReadLine()); // Get the ingredient quantity from the user

                    Console.Write("Please indicate the unit of measurement: ");
                    string unit = Console.ReadLine(); // Get the unit of measurement from the user

                    Console.Write("Enter number of calories: ");
                    int calories = int.Parse(Console.ReadLine()); // Get the number of calories from the user

                    Console.Write("Enter food group: ");
                    string foodGroup = Console.ReadLine(); // Get the food group from the user

                    ingredients.Add(new Ingredient(name, quantity, unit, calories, foodGroup)); // Create a new Ingredient object and add it to the list
                }

                // Check if total calories exceed 300 and raise event
                CheckCalories();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while entering ingredients: {ex.Message}"); // Handle any exceptions that occur
            }
        }

        // Method to enter steps for the recipe
        public void EnterSteps()
        {
            try
            {
                Console.Write("\nProvide the number of instructions: ");
                int numSteps = int.Parse(Console.ReadLine()); // Get the number of steps from the user

                for (int i = 0; i < numSteps; i++)
                {
                    Console.Write("Step: ");
                    string step = Console.ReadLine(); // Get the step from the user
                    steps.Add(step); // Add the step to the list
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while entering steps: {ex.Message}"); // Handle any exceptions that occur
            }
        }

        // Method to display the recipe details
        public void DisplayRecipe()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Blue; // Set the console text color to blue

                if (ingredients.Count == 0 || steps.Count == 0) // Check if there are no ingredients or steps
                {
                    Console.WriteLine("No recipe data available.");
                    return;
                }

                Console.WriteLine($"\nRecipe: {Name}"); // Print the recipe name

                Console.WriteLine("\nIngredients:");
                foreach (Ingredient ingredient in ingredients) // Iterate through the ingredients
                {
                    double adjustedQuantity = isScaled ? ingredient.Quantity * scaleFactor : ingredient.Quantity; // Calculate the adjusted quantity based on the scaling factor
                    Console.WriteLine($"{adjustedQuantity} {ingredient.Unit} of {ingredient.Name} - {ingredient.Calories} calories ({ingredient.FoodGroup})"); // Print the ingredient details
                }

                Console.WriteLine("\nSteps:");
                for (int i = 0; i < steps.Count; i++) // Iterate through the steps
                {
                    Console.WriteLine($"{i + 1}. {steps[i]}"); // Print the step number and description
                }

                // Display total calories
                DisplayTotalCalories();

                Console.ResetColor(); // Reset the console text color to the default
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while displaying the recipe: {ex.Message}"); // Handle any exceptions that occur
            }
        }

        // Method to calculate and display total calories for the recipe
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
                Console.WriteLine("Suggestions for Reducing Calories:");
                Console.WriteLine("- Use low-calorie ingredients or substitutes");
                Console.WriteLine("- Reduce portion sizes");
                Console.WriteLine("- Avoid high-calorie ingredients or condiments");
                Console.WriteLine("- Increase physical activity");
            }
        }

        // Method to check if total calories exceed 300
        private void CheckCalories()
        {
            int totalCalories = ingredients.Sum(ingredient => ingredient.Calories); // Calculate the total calories by summing the calories of all ingredients
            if (totalCalories > 300)
            {
                CalorieExceeded?.Invoke($"Warning: The total calories of the recipe \"{Name}\" exceed 300!"); // Raise the CalorieExceeded event with a warning message
            }
        }

        // Method to scale the recipe
        public void ScaleRecipe()
        {
            try
            {
                Console.Write("Enter the scale factor (0.5, 2 or 3): ");
                double factor = double.Parse(Console.ReadLine()); // Get the scale factor from the user

                if (factor == 0.5 || factor == 2 || factor == 3) // Check if the scale factor is valid
                {
                    isScaled = true; // Set the scaling flag to true
                    scaleFactor = factor; // Set the scale factor

                    // Scale the ingredient quantities
                    foreach (Ingredient ingredient in ingredients)
                    {
                        if (ingredient.Unit == "teaspoon") // Scale the quantity based on the unit of measurement
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
                    Console.WriteLine("You can only scale by 0.5, 2, or 3."); // Display an error message if the scale factor is invalid
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. You can only scale by 0.5, 2, or 3."); // Handle any format exceptions that occur
            }
        }
        // Method to reset the recipe scaling
        public void ResetRecipe()
        {
            isScaled = false; // Set the scaling flag to false
            scaleFactor = 1.0; // Reset the scale factor to 1.0 (no scaling)
            Console.WriteLine("\nSuccessfully reset the measurements to their original values."); // Print a success message
        }

        // Method to delete the recipe
        public void DeleteRecipe()
        {
            ingredients.Clear(); // Clear the ingredients list
            steps.Clear(); // Clear the steps list
            isScaled = false; // Set the scaling flag to false
            scaleFactor = 1.0; // Reset the scale factor to 1.0 (no scaling)
            Console.WriteLine("\nRecipe cleared. You're welcome to add a new one."); // Print a message indicating that the recipe has been cleared
        }
    }
}

//----------------------------------------EndOfFile------------------------------------------//
