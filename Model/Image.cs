using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeVault.Model
{
    public class Image : AppObject
    {
        public string DateAdded { get; set; }
        public string Source { get; set; }

        public Image(string name, string desc) : base(name, desc) 
        {
            DateAdded = DateTime.Now.ToString();
            Source = string.Empty;
        }

        public Image(string name) : this(name, "") { }

        public Image() { }
    }
}
