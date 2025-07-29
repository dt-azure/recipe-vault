using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeVault.Model
{
    public class Tag : AppObject
    {
        public TagColor TagColor { get; }

        public Tag(string name, string desc, TagColor color) : base(name, desc)
        {
            TagColor = color;
        }
        public Tag(string name, TagColor color) : this(name, string.Empty, color) { }

        public Tag() { }
    }
}
