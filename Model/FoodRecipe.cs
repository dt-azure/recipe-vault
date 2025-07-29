using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeVault.Model
{
    public class FoodRecipe : Recipe
    {
        public FoodType FoodType { get; set; }
        public CuisineType CuisineType { get; set; }
        public bool IsVegetarian { get; set; }
        public bool IsVegan {  get; set; }
        public SpiceLevel SpiceLevel { get; set; }

        public FoodRecipe(string name, string desc, int servingSize, int prepTime, int cookTime, Difficulty difficulty, FoodType foodType, CuisineType cuisineType, SpiceLevel spiceLevel) : base(name, desc, servingSize, prepTime, cookTime, difficulty)
        {
            IsVegetarian = false;
            IsVegan = false;
            FoodType = foodType;
            CuisineType = cuisineType;
            SpiceLevel = spiceLevel;
        }

        public FoodRecipe() { }
    }
}
