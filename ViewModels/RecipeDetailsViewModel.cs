using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private Recipe selectedRecipe;

        [ObservableProperty]
        private string newServingSize;

        public ObservableCollection<string> WeightMeasurementUnits { get; set; }

        [ObservableProperty]
        private string selectedWeightMeasurementUnitSource;

        [ObservableProperty]
        private string selectedWeightMeasurementUnitTarget;

        [ObservableProperty]
        private string selectedVolumeMeasurementUnitSource;

        [ObservableProperty]
        private string selectedVolumeMeasurementUnitTarget;

        public ObservableCollection<string> VolumeMeasurementUnits { get; set; }

        [ObservableProperty]
        private string selectedVolumeMeasurementUnit;


        //  Handle parameter when it contains complex objects
        //  Use when [QueryProperty] fails to process it
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue("SelectedRecipe", out var recipeObject) && recipeObject is Recipe recipe)
            {
                SelectedRecipe = recipe;
                SelectedRecipe.OriginalServingSize = SelectedRecipe.ServingSize;

                foreach (Ingredient ingredient in SelectedRecipe.Ingredients)
                {
                    ingredient.OriginalQuantity = ingredient.Quantity;
                    ingredient.OriginalMeasurementUnit = ingredient.MeasurementUnit;
                }    

                foreach (RecipeInstruction instruction in SelectedRecipe.Instructions)
                {
                    foreach (Ingredient ingredient in instruction.IngredientsRequired)
                    {
                        ingredient.OriginalQuantity = ingredient.Quantity;
                        ingredient.OriginalMeasurementUnit = ingredient.MeasurementUnit;
                    }
                }    
            }
        }

        public RecipeDetailsViewModel()
        {
            Utilities utilities = new Utilities();
            WeightMeasurementUnits = new ObservableCollection<string>(utilities.ConvertEnumToStringList<WeightMeasurementUnit>());
            VolumeMeasurementUnits = new ObservableCollection<string>(utilities.ConvertEnumToStringList<VolumeMeasurementUnit>());
        }

        [RelayCommand]
        private void ServingSizeBtnClicked()
        {
            if (SelectedRecipe == null || string.IsNullOrWhiteSpace(NewServingSize))
            {
                return;
            }

            int newServingSize;

            //  Check if valid integer
            if (!int.TryParse(NewServingSize, out newServingSize))
            {
                return;
            }

            double scaling = (double)newServingSize / SelectedRecipe.OriginalServingSize;

            foreach (Ingredient ingredient in SelectedRecipe.Ingredients)
            {
                ingredient.Quantity = ingredient.OriginalQuantity * scaling;
            }

            foreach (RecipeInstruction instruction in SelectedRecipe.Instructions)
            {
                foreach (Ingredient ingredient in instruction.IngredientsRequired)
                {
                    ingredient.Quantity = ingredient.OriginalQuantity * scaling;
                }
            }

            SelectedRecipe.ServingSize = newServingSize;
        }

        [RelayCommand]
        private void ConvertMeasurementUnit(MeasurementUnitCategory category)
        {
            MeasurementUnitConverter converter = new MeasurementUnitConverter();
            MeasurementUnitHelper helper = new MeasurementUnitHelper();
            MeasurementUnit source;
            MeasurementUnit target;

            if (category == MeasurementUnitCategory.Weight)
            {
                source = helper.GetUnitEnum(SelectedWeightMeasurementUnitSource);
                target = helper.GetUnitEnum(SelectedWeightMeasurementUnitTarget);
            } else
            {
                source = helper.GetUnitEnum(SelectedVolumeMeasurementUnitSource);
                target = helper.GetUnitEnum(SelectedVolumeMeasurementUnitTarget);
            }

            if (source == target)
            {
                return;
            }

            foreach (Ingredient ingredient in SelectedRecipe.Ingredients)
            {
                if (ingredient.MeasurementUnit == source && ingredient.MeasurementUnitCategory == category)
                {
                    ingredient.Quantity = converter.Convert(ingredient.Quantity, category, ingredient.OriginalMeasurementUnit, target);
                    ingredient.MeasurementUnit = target;
                }
            }

            foreach (RecipeInstruction instruction in SelectedRecipe.Instructions)
            {
                foreach (Ingredient ingredient in instruction.IngredientsRequired)
                {
                    if (ingredient.MeasurementUnit == source && ingredient.MeasurementUnitCategory == category)
                    {
                        ingredient.Quantity = converter.Convert(ingredient.OriginalQuantity, category, ingredient.OriginalMeasurementUnit, target);
                        ingredient.MeasurementUnit = target;
                    }
                }
            }
        }
    }
}
