using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeVault.Model
{
    public class TagCategory : AppObject
    {
        public Color Color { get; set; }

        public TagCategory(string name, string desc, Color color) : base(name, desc) 
        { 
            Color = color;
        }

        public TagCategory(string name, Color color) : this(name, "", color) { }

        public TagCategory() { }
    }
}
