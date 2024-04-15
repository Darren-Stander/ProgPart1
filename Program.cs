using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;


namespace ProgPart1
{
    internal class Program
    {
        static void Main(string[] args)     // Start of our application
        {
            bool close = false;             // A boolean variable to control the application loop

            Recipe recipe = new Recipe();       //Created a new instance of the recipe class

            Console.Write("Welcome to our app!");       // Shows a welcome message and prompts the user to enter ingredients and steps for the recipe
            recipe.EnterIngredients();
            recipe.EnterSteps();

            while (!close)                              // Main application loop to display the menu and handle user choices
            { 
                Console.WriteLine("\nWonderful recipe! It sounds absolutely delicious. Feel free to use the menu below.");
                Console.WriteLine("a. View Recipe");
                Console.WriteLine("b. Scale Recipe");
                Console.WriteLine("c. Reset Scale");
                Console.WriteLine("d. Delete Recipe");
                Console.WriteLine("e. Close App");

                string choice = Console.ReadLine().ToLower();       // Read the user's choice

                switch (choice)         // Use the user's choice using a switch statement.
                {
                    case "a":
                        recipe.DisplayRecipe(); //Displays the current recipe details
                        break;

                    case "b":
                        recipe.ScaleRecipe(); // Scale the recipe by a specified
                        break;

                    case "c":
                        recipe.ResetRecipe(); // Reset any scaling adjustments made to the recipe
                        break;

                    case "d":
                        recipe.DeleteRecipe(); // Deletes the current recipe
                        break;

                    case "e":
                        close = true;       // Shuts down the application
                        break;

                    default:
                        Console.WriteLine("Invalid selection");         // Gives an error message when the user gives an invalid letter
                        continue;
                }

                if (!close)         // Confirms if the user wants to continue using the application
                {
                    Console.WriteLine("\nWould you like to go back to the menu? (yes/no): ");
                    string continueClose = Console.ReadLine().ToLower(); 
                    if (continueClose != "yes")
                        close = true; break;            // If it meets the condition the application will close
                }
            }
        }
    }
}
