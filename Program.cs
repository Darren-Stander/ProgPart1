using System;
using System.Linq;



namespace ProgPart1
{
    internal class Program
    {/// <summary>
     /// https://github.com/Darren-Stander/ProgPart1.git        // Github link
     /// </summary>
     /// <param name="args"></param>
        static void Main(string[] args)
        {
            RecipeManager recipeManager = new RecipeManager();

            // Main program loop to interact with the user
            while (true)
            {
                Console.WriteLine("\nChoose an action:");
                Console.WriteLine("1. Add Recipe");
                Console.WriteLine("2. Display All Recipes");
                Console.WriteLine("3. Display Recipe Details");
                Console.WriteLine("4. Scale Recipe"); // New option
                Console.WriteLine("5. Reset Recipe"); // New option
                Console.WriteLine("6. Exit");

                Console.Write("\nEnter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        recipeManager.AddRecipe();
                        break;
                    case 2:
                        recipeManager.DisplayAllRecipes();
                        break;
                    case 3:
                        recipeManager.DisplayRecipeDetails();
                        break;
                    case 4:
                        // Ask the user which recipe to scale
                        recipeManager.DisplayAllRecipes();
                        Console.Write("\nEnter the name of the recipe to scale: ");
                        string recipeNameToScale = Console.ReadLine();

                        // Find the recipe
                        Recipe recipeToScale = recipeManager.recipes.FirstOrDefault(r => r.Name.Equals(recipeNameToScale, StringComparison.OrdinalIgnoreCase));

                        // Scale the recipe if found
                        if (recipeToScale != null)
                        {
                            recipeToScale.ScaleRecipe();
                        }
                        else
                        {
                            Console.WriteLine("Recipe not found.");
                        }
                        break;
                    case 5:
                        // Ask the user which recipe to reset
                        recipeManager.DisplayAllRecipes();
                        Console.Write("\nEnter the name of the recipe to reset: ");
                        string recipeNameToReset = Console.ReadLine();

                        // Find the recipe
                        Recipe recipeToReset = recipeManager.recipes.FirstOrDefault(r => r.Name.Equals(recipeNameToReset, StringComparison.OrdinalIgnoreCase));

                        // Reset the recipe if found
                        if (recipeToReset != null)
                        {
                            recipeToReset.ResetRecipe();
                        }
                        else
                        {
                            Console.WriteLine("Recipe not found.");
                        }
                        break;
                    case 6:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}

