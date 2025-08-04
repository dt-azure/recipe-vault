using RecipeVault.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RecipeVault.Model
{
    [JsonDerivedType(typeof(FoodRecipe))]   //Help with deserialization
    [JsonDerivedType(typeof(DrinkRecipe))]
    public abstract class Recipe : AppObject
    {
        public string DateCreated { get; set; }
        public string DateLastModified { get; set; }
        public ObservableCollection<Tag> Tags { get; set; }
        public ObservableCollection<Ingredient> Ingredients { get; set; }
        public int ServingSize { get; set; }
        public int OriginalServingSize { get; set; }
        //Time in seconds
        public int PrepTime { get; set; }
        public int CookTime { get; set; }
        public Difficulty Difficulty { get; set; }
        public ObservableCollection<RecipeImage> Gallery { get; set; }
        public bool Hidden { get; set; }
        public ObservableCollection<RecipeInstruction> Instructions { get; set; }

        public string FormattedPrepTime
        {
            get
            {
                Utilities utilities = new Utilities();
                return utilities.FormatRecipeTime(PrepTime);
            }
        }

        public string FormattedCookTime
        {
            get
            {
                Utilities utilities = new Utilities();
                return utilities.FormatRecipeTime(CookTime);
            }
        }


        public Recipe(string name, string desc, int servingSize, int prepTime, int cookTime, Difficulty difficulty) : base(name, desc)
        {
            DateCreated = DateTime.Now.ToString();
            DateLastModified = DateCreated;
            Tags = new ObservableCollection<Tag>();
            Ingredients = new ObservableCollection<Ingredient>();
            ServingSize = servingSize;
            PrepTime = prepTime;
            CookTime = cookTime;
            Difficulty = difficulty;
            Gallery = new ObservableCollection<RecipeImage>();
            Hidden = false;
            Instructions = new ObservableCollection<RecipeInstruction>();
        }

        public Recipe(string name, int servingSize, int prepTime, int cookTime, Difficulty difficulty) : this(name, "", servingSize, prepTime, cookTime, difficulty)
        {
        }

        public Recipe() { }

        public void AddTag(Tag tag)
        {
            Tags.Add(tag);
        }

        public void AddIngredient(Ingredient ingredient)
        {
            Ingredients.Add(ingredient);
        }

        public void AddInstruction(RecipeInstruction instruction)
        {
            instruction.Index = Instructions.Count + 1;
            Instructions.Add(instruction);
        }

        public void AddImage(RecipeImage image)
        {
            Gallery.Add(image);
        }
    }
}
