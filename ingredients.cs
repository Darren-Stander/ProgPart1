using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgPart1
{
    internal class ingredients
    {
        private List<Ingredient> ingredients;
        private List<string> steps;
        private bool isScaled;
        private double scaleFactor;

        public ingredients()
        {
            ingredients = new List<Ingredient>();
            steps = new List<string>();
            isScaled = false;
            scaleFactor = 1.0;
        }


    }
}
