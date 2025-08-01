using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using RecipeVault.Model;

namespace RecipeVault.ViewModels
{
    public partial class RecipeDetailsViewModel : ObservableObject, IQueryAttributable
    {
        [ObservableProperty]
        private Recipe _selectedRecipe;

        //  Handle parameter when it contains complex objects
        //  Use when [QueryProperty] fails to process it
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue("SelectedRecipe", out var recipeObject) && recipeObject is Recipe recipe)
            {
                SelectedRecipe = recipe;
            }
        }
    }
}
