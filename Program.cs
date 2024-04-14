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

            //ingredients.EnterIngredients();
            //ingredinets.EnterSteps();

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
                        recipe.displayrecipe();
                        break;

                    case b:
                        recipe.scalerecipe;
                        break;

                    case c:
                        recipe.resetrecipe;
                        break;
                    case c:
                        recipe.deleterecipe;
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

                }
            }
        }
    }
}
