using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeVault.Model
{
    public class DrinkRecipe : Recipe
    {
        public bool IsAlcoholic { get; set; }
        public DrinkRecipe(string name, string desc, int servingSize, int prepTime, int cookTime, Difficulty difficulty) : base(name, desc, servingSize, prepTime, cookTime, difficulty)
        {
            IsAlcoholic = false;
        }

        public DrinkRecipe() { }
    }
}
