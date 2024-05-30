using System;
using System.Linq;

namespace ProgPart1
{
    internal class Program
    {
        /// <summary>
        /// https://github.com/Darren-Stander/ProgPart1.git // Github link
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            RecipeManager recipeManager = new RecipeManager(); // Create an instance of the RecipeManager class

            // Main program loop to interact with the user
            while (true)
            {
                Console.WriteLine("\nChoose an action:");
                Console.WriteLine("1. Add Recipe");
                Console.WriteLine("2. Display All Recipes");
                Console.WriteLine("3. Display Recipe Details");
                Console.WriteLine("4. Scale Recipe");
                Console.WriteLine("5. Reset Recipe");
                Console.WriteLine("6. Exit");

                int choice = GetValidIntInput("\nEnter your choice: ");

                // Now, execute the switch statement based on the valid choice
                switch (choice)
                {
                    case 1:
                        recipeManager.AddRecipe(); // Call the AddRecipe method of the RecipeManager class
                        break;
                    case 2:
                        recipeManager.DisplayAllRecipes(); // Call the DisplayAllRecipes method of the RecipeManager class
                        break;
                    case 3:
                        recipeManager.DisplayRecipeDetails(); // Call the DisplayRecipeDetails method of the RecipeManager class
                        break;
                    case 4:
                        // Ask the user which recipe to scale
                        recipeManager.DisplayAllRecipes();
                        string recipeNameToScale = GetValidStringInput("\nEnter the name of the recipe to scale: ");

                        // Find the recipe
                        Recipe recipeToScale = recipeManager.recipes.FirstOrDefault(r => r.Name.Equals(recipeNameToScale, StringComparison.OrdinalIgnoreCase));

                        // Scale the recipe if found
                        if (recipeToScale != null)
                        {
                            recipeToScale.ScaleRecipe(); // Call the ScaleRecipe method of the Recipe class
                        }
                        else
                        {
                            Console.WriteLine("Recipe not found.");
                        }
                        break;
                    case 5:
                        // Ask the user which recipe to reset
                        recipeManager.DisplayAllRecipes(); 
                        string recipeNameToReset = GetValidStringInput("\nEnter the name of the recipe to reset: ");

                        // Find the recipe
                        Recipe recipeToReset = recipeManager.recipes.FirstOrDefault(r => r.Name.Equals(recipeNameToReset, StringComparison.OrdinalIgnoreCase));

                        // Reset the recipe if found
                        if (recipeToReset != null)
                        {
                            recipeToReset.ResetRecipe(); // Call the ResetRecipe method of the Recipe class
                        }
                        else
                        {
                            Console.WriteLine("Recipe not found.");
                        }
                        break;
                    case 6:
                        Console.WriteLine("Exiting..."); // Exit the program
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again."); // Display an error message for an invalid choice
                        break;
                }
            }
        }

        // Method to get valid string input
        private static string GetValidStringInput(string prompt)
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

        // Method to get valid integer input
        private static int GetValidIntInput(string prompt)
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
    }
}      // End of File
