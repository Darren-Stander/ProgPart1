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
        static void Main(string[] args)
        {
            bool close = false;
            Recipe recipe = new Recipe(); // Corrected class name to Recipe
            recipe.EnterIngredients();
            recipe.EnterSteps();

            while (!close)
            {
                Console.WriteLine("Welcome to our app. Enter your choice:");

                Console.WriteLine("\nOptions");
                Console.WriteLine("a. View Recipe");
                Console.WriteLine("b. Scale Recipe");
                Console.WriteLine("c. Reset Recipe");
                Console.WriteLine("d. Delete Recipe");
                Console.WriteLine("e. Close Application");

                string choice = Console.ReadLine().ToLower(); // Corrected variable name and made it lowercase

                switch (choice) // Corrected variable name and made it lowercase
                {
                    case "a": // Corrected case labels to strings
                        recipe.DisplayRecipe(); // Corrected method name to DisplayRecipe
                        break;

                    case "b":
                        recipe.ScaleRecipe(); // Assuming you will implement this method in Recipe class
                        break;

                    case "c":
                        recipe.ResetRecipe(); // Assuming you will implement this method in Recipe class
                        break;

                    case "d":
                        recipe.DeleteRecipe(); // Assuming you will implement this method in Recipe class
                        break;

                    case "e":
                        close = true;
                        break;

                    default:
                        Console.WriteLine("Invalid selection");
                        continue;
                }

                if (!close)
                {
                    Console.WriteLine("Would you like to continue? (yes/no): ");
                    string continueClose = Console.ReadLine().ToLower(); // Corrected variable name and made it lowercase
                    if (continueClose != "yes")
                        close = true;
                }
            }
        }
    }
}
