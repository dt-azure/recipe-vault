using RecipeVault.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeVault.Model
{
    public class RecipeImage : AppObject
    {
        public string DateAdded { get; set; }
        public string Source { get; set; }
        public ImageSource SourceImage
        {
            get
            {
                DataService dataService = new DataService();
                return dataService.ConvertBase64ToImg(Source);

            }
        }

        public RecipeImage(string name, string desc, string source) : base(name, desc) 
        {
            DateAdded = DateTime.Now.ToString();
            Source = source;
        }

        public RecipeImage(string name, string source) : this(name, "", source) { }

        public RecipeImage() { }
    }
}
