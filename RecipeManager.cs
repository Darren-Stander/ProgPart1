using System;
using System.Collections.Generic;
using System.Linq;

namespace ProgPart1
{ 
    internal class RecipeManager
{
    public List<Recipe> recipes; // List to store recipes

    // Constructor to initialize the RecipeManager
    public RecipeManager()
    {
        recipes = new List<Recipe>(); // Initialize the recipes list
    }

    // Method to add a new recipe
    public void AddRecipe()
    {
        Console.Write("\nEnter the recipe name: ");
        string name = Console.ReadLine(); // Get the recipe name from the user

        Recipe recipe = new Recipe(name); // Create a new Recipe object with the given name
        recipe.EnterIngredients(); // Prompt the user to enter the ingredients for the recipe
        recipe.EnterSteps(); // Prompt the user to enter the steps for the recipe

        // Subscribe to the CalorieExceeded event of the newly created recipe
        recipe.CalorieExceeded += NotifyCalorieExceed; // Register the NotifyCalorieExceed method to handle the CalorieExceeded event

        recipes.Add(recipe); // Add the recipe to the list
        Console.WriteLine("\nRecipe added successfully.");
    }

    // Method to display all recipes in alphabetical order
    public void DisplayAllRecipes()
    {
        if (recipes.Count == 0) // Check if the recipes list is empty
        {
            Console.WriteLine("No recipes available.");
            return;
        }

        // Order the recipes by name in ascending order
        var sortedRecipes = recipes.OrderBy(r => r.Name).ToList();

        Console.WriteLine("\nRecipes:");
        foreach (var recipe in sortedRecipes) // Iterate through the sorted recipes
        {
            Console.WriteLine(recipe.Name); // Print the name of each recipe
        }
    }

    // Method to display the details of a specific recipe
    public void DisplayRecipeDetails()
    {
        if (recipes.Count == 0) // Check if the recipes list is empty
        {
            Console.WriteLine("No recipes available.");
            return;
        }

        DisplayAllRecipes(); // Display all available recipes

        Console.Write("\nEnter the name of the recipe you want to view: ");
        string name = Console.ReadLine(); // Get the recipe name from the user

        // Find the recipe with the specified name (case-insensitive)
        Recipe recipe = recipes.FirstOrDefault(r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (recipe != null) // If the recipe is found
        {
            recipe.DisplayRecipe(); // Display the recipe details
        }
        else
        {
            Console.WriteLine("Recipe not found.");
        }
    }

    // Method to handle the CalorieExceeded event
    private void NotifyCalorieExceed(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red; // Set the console text color to red
        Console.WriteLine(message); // Print the message
        Console.ResetColor(); // Reset the console text color to the default
    }
}
}
