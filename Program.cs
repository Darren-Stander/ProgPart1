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
            Recipe recipe = new Recipe();
            Console.Write("Welcome to our app!");
            recipe.EnterIngredients();
            recipe.EnterSteps();

            while (!close)
            { 
                Console.WriteLine("\nWonderful recipe! It sounds absolutely delicious. Feel free to use the menu below.");
                Console.WriteLine("a. View Recipe");
                Console.WriteLine("b. Scale Recipe");
                Console.WriteLine("c. Reset Scale");
                Console.WriteLine("d. Delete Recipe");
                Console.WriteLine("e. Close App");

                string choice = Console.ReadLine().ToLower(); 

                switch (choice) 
                {
                    case "a":
                        recipe.DisplayRecipe(); 
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
                    Console.WriteLine("\nWould you like to go back to the menu? (yes/no): ");
                    string continueClose = Console.ReadLine().ToLower(); 
                    if (continueClose != "yes")
                        close = true;
                }
            }
        }
    }
}
