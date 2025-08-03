using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RecipeVault.Model;
using RecipeVault.Services;

namespace RecipeVault.ViewModels
{

    public partial class RecipeDetailsViewModel : ObservableObject, IQueryAttributable
    {
        [ObservableProperty]
        private Recipe _selectedRecipe;

        partial void OnSelectedRecipeChanged(Recipe value)
        {
            // Notify the UI that these properties have changed
            OnPropertyChanged(nameof(FormattedPrepTime));
            OnPropertyChanged(nameof(FormattedCookTime));
            //OnPropertyChanged(nameof(RecipeImages));
        }

        public string FormattedPrepTime
        {
            get
            {
                if (SelectedRecipe == null)
                {
                    return string.Empty;
                }

                DataService dataService = new DataService();
                return dataService.FormatRecipeTime(SelectedRecipe.PrepTime);
            }
        }

        public string FormattedCookTime
        {
            get
            {
                if (SelectedRecipe == null)
                {
                    return string.Empty;
                }

                DataService dataService = new DataService();
                return dataService.FormatRecipeTime(SelectedRecipe.CookTime);
            }
        }

        //public List<ImageSource> RecipeImages
        //{
        //    get
        //    {
        //        DataService dataService = new DataService();
        //        return dataService.GetRecipeImages(SelectedRecipe.Gallery);
        //    }
        //}

        //  Handle parameter when it contains complex objects
        //  Use when [QueryProperty] fails to process it
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue("SelectedRecipe", out var recipeObject) && recipeObject is Recipe recipe)
            {
                SelectedRecipe = recipe;
            }
        }

        [RelayCommand]
        async Task ServingSizeBtnClicked()
        {
            await Application.Current.MainPage.DisplayAlert("Button Clicked", "The custom button was tapped!", "OK");
        }
    }
}
