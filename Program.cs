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

            ingredients.EnterIngredients();
            ingredients.EnterSteps();

            while (!close)
            {
                Console.WriteLine("Welcome to our app enter your....");


                Console.WriteLine("\nOptions");
                Console.WriteLine("a. View Recipe");
                Console.WriteLine("b. Scale Recipe");
                Console.WriteLine("b. Reset Recipe");
                Console.WriteLine("c. Delete Recipe");
                Console.WriteLine("d. Close Application");

               
                string choices;
                if (!string.IsNullOrEmpty(Console.ReadLine()))
                {
                    | Console.WriteLine("Invalid opotion, enter a a,b,c or d");
                    continue;
                }

                switch (close) 
                {
                    case a:
                        ingredients.displayrecipe();
                        break;

                    case b:
                        ingredients.scalerecipe;
                        break;

                    case c:
                        ingredients.resetrecipe;
                        break;
                    case c:
                        ingredients.deleterecipe;
                        break;
                    case d:
                        close = true;
                        break;
                        default:
                        Console.WriteLine("Invalid selection");
                        continue;
                        
                }
                if (!close)
                {
                    Console.WriteLine("Would you like to continue? (yes/no): ");
                    string continueclose =Console.ReadLine().ToLower();
                    if (continueclose ! = "yes")
                        close = true;
                }
            }
        }
    }
}
