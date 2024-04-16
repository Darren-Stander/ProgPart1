using ProgPart1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProgPart1
{
internal class Recipe
{
    private List<Ingredient> ingredients; 
    private List<string> steps;
    private bool isScaled;
    private double scaleFactor;

        //********************** Start of Recipe ************//


    public Recipe()
    {
        ingredients = new List<Ingredient>(); 
        steps = new List<string>();
        isScaled = false;
        scaleFactor = 1.0;
    }

        //********************** End of Recipe ************//
        public void EnterIngredients()                                                                 // This method allows the user to enter details of ingredients
        {
        int numIngredients;
        while (true)                                                                               // Loops until a valid number of ingredients is entered
            {
            Console.Write("\nPlease enter the amount of ingredients: ");                           // Prompt the user to enter the number of ingredients

                if (int.TryParse(Console.ReadLine(), out numIngredients) && numIngredients > 0)    // Check if the parsed value is positive and break the loop if valid

                    break;

            Console.WriteLine("Invalid input. Please enter a positive integer.");                  // If invalid input is entered, display an error message

            }

        for (int i = 0; i < numIngredients; i++)
        {
            Console.Write("\nIngredients name: ");
            string name = Console.ReadLine();

            double quantity;                                                                         // Declare a variable to store the quantity of the ingredient
                while (true)
            {
                Console.Write("Enter quantity: ");                                                   // Prompt the user to enter the quantity

                    if (double.TryParse(Console.ReadLine(), out quantity) && quantity > 0)           // Check if the parsed value is positive and break the loop if valid
                        break;
                Console.WriteLine("Input error. Please provide a positive number.");
            }

            Console.Write("Please indicate the unit of measurement: ");                             // Prompt the user to enter the unit of measurement for the ingredient
                string unit = Console.ReadLine();

            ingredients.Add(new Ingredient(name, quantity, unit));                                 // Create a new Ingredient object with the entered details and add it to the ingredients list
            }
    }

    public void EnterSteps()                                                                     // This method allows the user to enter cooking steps or instructions
        {
        int numSteps;
        while (true)                                                                             // Loop until a valid number of steps is entered
            {
            Console.Write("\nProvide the number of instructions: ");                            // Prompt the user to enter the number of steps
                if (int.TryParse(Console.ReadLine(), out numSteps) && numSteps > 0)
                break;
            Console.WriteLine("Invalid input. Please enter a positive integer.");               // If invalid input is entered, display an error message
            }

        for (int i = 0; i < numSteps; i++)                                                      // Loop to iterate through each step
            {
            Console.Write("Steps to follow: ");                                                 // Prompt the user to enter the cooking step or instruction
                string step = Console.ReadLine();
            steps.Add(step);                                                                    // Add the entered step to the steps list
            }
    }

    public void DisplayRecipe()                                                                 // This method displays the recipe details including ingredients and cooking steps
        {
            Console.ForegroundColor = ConsoleColor.Blue;

            if (ingredients.Count == 0 || steps.Count == 0)                                         // Check if there are no ingredients or steps available
            {
            Console.WriteLine("No recipe data available.");
            return;
        }

        Console.WriteLine("\nIngredients:");                                                     // Display the list of ingredients with adjusted quantities if scaling is enabled
            foreach (Ingredient ingredient in ingredients)
        {
            double adjustedQuantity = isScaled ? ingredient.Quantity * scaleFactor : ingredient.Quantity;       // Calculate adjusted quantity if scaling is used
                Console.WriteLine($"{adjustedQuantity} {ingredient.Unit} of {ingredient.Name}");                // Display the ingredient details with adjusted amount
            }

        Console.WriteLine("\nSteps:");                                                        // Display the list of cooking steps
            for (int i = 0; i < steps.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {steps[i]}");       // Displays each step prefixed with its index number
            }

            Console.ResetColor();
        }

    public void ScaleRecipe()                                                           // This method allows the user to scale the recipe by a specified factor
    {
        double factor;                                                                 // Declares the variable to store the scale factor

        while (true)                                                                    // Loops until a valid scale factor is enterd
        {
            Console.Write("'\nEnter the scale factor( 0.5, 2 0r 3): ");                  // Prompt the user to enter the scale factor


                if (double.TryParse(Console.ReadLine(), out factor) && (factor == 0.5 || factor == 2 || factor == 3))        // Checks if the parsed value is either 2 or 3 and break the loop if valid
                {
                isScaled = true;                                            // Sets the scaling to true and updates the scale factor
                scaleFactor = factor;
                Console.WriteLine("\nRecipe was successfully scaled");        // Displays a message that indicates the recipe was successfully scaled
                    return;

            }
            Console.WriteLine("You can only scale by 0.5, 2 or 3 ");            //If an invalid input is entered,it will display an error message
        }
    }

    public void ResetRecipe()                                   // This method resets the recipe measurements back to their original values
        {
        isScaled = false;
        scaleFactor = 1.0;                                      // Resets the scale factor to its original value of 1.0

            Console.WriteLine("\nSuccessfully reset the measurements to their original values.");       // Displays the message indicating that the measurements were successfully reset
        }

    public void DeleteRecipe()                  // This method deletes the current recipe by clearing all ingredients, steps and resets any scaled adjustments
        {
        ingredients.Clear();                    // Clear the list of ingredients

            steps.Clear();                        // Clear the list of steps

            isScaled = false;                        // Reset the scaling flag to false

            scaleFactor = 1.0;                      // Resets the scale factor to its original value of 1.0

            Console.WriteLine("\nRecipe cleared. You're welcome to add a new one.");    // A message indicating that the recipe has been cleared

            EnterIngredients();         //The user to enter new ingredients and steps for a new recipe.
        EnterSteps();
    }
}
}

//----------------------------------------EndOfFile------------------------------------------//
