using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeVault.Model
{
    public abstract class AppObject
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public AppObject(string name, string desc = "") 
        { 
            Id = Guid.NewGuid();
            Name = name;
            Description = desc;
        }

        public AppObject() { }
    }
}
