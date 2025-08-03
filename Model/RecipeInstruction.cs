using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeVault.Model
{
    public class RecipeInstruction : AppObject
    {
        public List<InstructionIngredient> IngredientsRequired { get; set; }
        public string Details { get; set; }
        public int Index { get; set; }

        public RecipeInstruction(string details) : base(string.Empty)
        {
            IngredientsRequired = new List<InstructionIngredient>();
            Details = details;
            Index = 0;
        }

        public RecipeInstruction()
        {
            IngredientsRequired = new List<InstructionIngredient>();
        }

        public void AddIngredient(InstructionIngredient ingredient)
        {
            IngredientsRequired.Add(ingredient);
        }
    }
}
