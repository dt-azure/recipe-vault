using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeVault.Model
{
    public class Tag : AppObject
    {
        public Tag(string name, string desc) : base(name, desc) { }
        public Tag(string name) : base(name) { }
    }
}
