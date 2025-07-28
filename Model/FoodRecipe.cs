using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeVault.Model
{
    public class FoodRecipe : Recipe
    {
        public FoodRecipe(string name, string desc, DateTime createdDate, DateTime lastModifiedDate, int servingSize, int prepTime, int cookTime, Difficulty difficulty) : base(name, desc, servingSize, prepTime, cookTime, difficulty) { }
    }
}
