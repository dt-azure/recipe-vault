using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeVault.Model
{
    public abstract class Recipe : AppObject
    {
        public string DateCreated { get; set; }
        public string DateLastModified { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public int ServingSize { get; set; }
        //Time in seconds
        public int PrepTime { get; set; }
        public int CookTime { get; set; }
        public Difficulty Difficulty { get; set; }
        public List<Image> Gallery {  get; set; }
        public bool Hidden { get; set; }


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
        }

        public Recipe(string name, int servingSize, int prepTime, int cookTime, Difficulty difficulty) : this(name, "", servingSize, prepTime, cookTime, difficulty)
        {
        }
    }
}
