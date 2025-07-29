using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeVault.Model
{
    public class RecipeInstruction : AppObject
    {
        public List<InstructionIngredient> IngredientsRequired { get; }
        public string Details { get; set; }

        public RecipeInstruction(string details) : base(string.Empty)
        {
            IngredientsRequired = new List<InstructionIngredient>();
            Details = details;
        }

        public RecipeInstruction() { }

        public void AddIngredient(InstructionIngredient ingredient)
        {
            IngredientsRequired.Add(ingredient);
        }
    }
}
