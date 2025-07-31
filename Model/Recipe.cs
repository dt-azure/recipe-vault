using System;
using System.Collections.Generic;
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
        public List<Tag> Tags { get; }
        public List<Ingredient> Ingredients { get; }
        public int ServingSize { get; set; }
        //Time in seconds
        public int PrepTime { get; set; }
        public int CookTime { get; set; }
        public Difficulty Difficulty { get; set; }
        public List<Image> Gallery {  get; }
        public bool Hidden { get; set; }
        public List<RecipeInstruction> Instructions { get; }


        public Recipe(string name, string desc, int servingSize, int prepTime, int cookTime, Difficulty difficulty) : base(name, desc)
        {
            DateCreated = DateTime.Now.ToString();
            DateLastModified = DateCreated;
            Tags = new List<Tag>();
            Ingredients = new List<Ingredient>();
            ServingSize = servingSize;
            PrepTime = prepTime;
            CookTime = cookTime;
            Difficulty = difficulty;
            Gallery = new List<Image>();
            Hidden = false;
            Instructions = new List<RecipeInstruction>();
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
            Instructions.Add(instruction);
        }

        public void AddImage(Image image)
        {
            Gallery.Add(image);
        }
    }
}
