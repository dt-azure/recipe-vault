using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using RecipeVault.Model;
using RecipeVault.Pages;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Diagnostics;
using System.Text.Json.Serialization.Metadata;
using CommunityToolkit.Mvvm.Input;
using RecipeVault.Services;
using Microsoft.Maui.Controls.Platform;
using FuzzySharp;

namespace RecipeVault.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Recipe> recipes;

        private readonly List<Recipe> _backupRecipeList;

        [ObservableProperty]
        private ObservableCollection<string> sortCriteria;

        [ObservableProperty]
        private ObservableCollection<string> sortOrder;

        [ObservableProperty]
        private ObservableCollection<Tag> recipeTags;

        [ObservableProperty]
        private ObservableCollection<Difficulty> recipeDifficulties;

        [ObservableProperty]
        private string? selectedSortCriteria;

        [ObservableProperty]
        private string? selectedSortOrder;

        [ObservableProperty]
        private Tag? selectedTag;

        [ObservableProperty]
        private Difficulty? selectedDifficulty;

        [ObservableProperty]
        private string searchQuery;

        //private readonly string _filePath;
        private readonly JsonSerializerOptions _jsonOptions;

        public MainPageViewModel()
        {
            recipes = new ObservableCollection<Recipe>();
            _backupRecipeList = new List<Recipe>();
            sortCriteria = new ObservableCollection<string>() { "Name", "Date Added" };
            sortOrder = new ObservableCollection<string>() { "Ascending", "Descending" };
            recipeTags = new ObservableCollection<Tag>();
            recipeDifficulties = new ObservableCollection<Difficulty>(Enum.GetValues(typeof(Difficulty)).Cast<Difficulty>());

            _jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new JsonStringEnumConverter() }  // Serialize enums as string
            };

            //Telling the app how to handle polymorphism during deserialization
            _jsonOptions.TypeInfoResolver = new DefaultJsonTypeInfoResolver
            {
                Modifiers = { JsonTypeInfo =>
                {
                    if (JsonTypeInfo.Type == typeof(Recipe))
                    {
                        JsonTypeInfo.PolymorphismOptions = new JsonPolymorphismOptions
                        {
                            TypeDiscriminatorPropertyName = "$type",
                            DerivedTypes =
                            {
                                new JsonDerivedType(typeof(FoodRecipe), "FoodRecipe"),
                                new JsonDerivedType(typeof(DrinkRecipe), "DrinkRecipe")
                            }
                        };
                    }
                }
                }
            };
        }

        public async Task LoadRecipesAsync()
        {
            Recipes.Clear();

            try
            {
                using var stream = await FileSystem.OpenAppPackageFileAsync("recipes.json");
                using var reader = new StreamReader(stream);

                var contents = reader.ReadToEnd();
                var loadedRecipes = JsonSerializer.Deserialize<List<Recipe>>(contents, _jsonOptions);

                Utilities utilities = new Utilities();

                if (loadedRecipes != null)
                {
                    foreach (var recipe in loadedRecipes)
                    {
                        foreach (RecipeImage img in recipe.Gallery)
                        {
                            img.SourceImage = utilities.ConvertBase64ToImg(img.Source);
                        }

                        Recipes.Add(recipe);
                        _backupRecipeList.Add(recipe);
                    }
                }

                //  Create of list of available tags
                RecipeTags = new ObservableCollection<Tag>(Recipes.SelectMany(recipe => recipe.Tags).DistinctBy(tag => tag.Name).ToList());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        [RelayCommand]
        private async Task NavigateToRecipeDetailsPage(Recipe recipe)
        {
            if (recipe  == null)
            {
                return;
            }

            var navigationParam = new Dictionary<string, object>
            {
                {"SelectedRecipe", recipe }
            };

            await Shell.Current.GoToAsync(nameof(RecipeDetailsPage), true, navigationParam);
        }

        [RelayCommand]
        private async Task NavigateToMainPage()
        {
            if (Shell.Current.CurrentPage.GetType() == typeof(MainPage))
            {
                return;
            }

            await Shell.Current.GoToAsync("///MainRoute/MainPage");
        }

        [RelayCommand]
        private async Task NavigateToRecipeListPage()
        {
            if (Shell.Current.CurrentPage.GetType() == typeof(RecipeListPage))
            {
                return;
            }

            await Shell.Current.GoToAsync("///ListRoute/RecipeListPage");
        }

        [RelayCommand]
        private void ApplyFilterAndSort()
        {
            var filteredAndSortedList = _backupRecipeList.AsEnumerable();

            //  Search
            filteredAndSortedList =  Search(filteredAndSortedList);


            if (SelectedTag != null)
            {
                filteredAndSortedList = filteredAndSortedList.Where(recipe => recipe.Tags.Contains(SelectedTag));
            }

            if (SelectedDifficulty.HasValue)
            {
                filteredAndSortedList = filteredAndSortedList.Where(recipe => recipe.Difficulty == SelectedDifficulty.Value);
            }

            if (!string.IsNullOrEmpty(SelectedSortCriteria))
            {
                bool isAsc = SelectedSortOrder == "Ascending";

                switch (SelectedSortCriteria)
                {
                    case "Name":
                        if (isAsc)
                        {
                            filteredAndSortedList = filteredAndSortedList.OrderBy(recipe => recipe.Name);
                        } else
                        {
                            filteredAndSortedList = filteredAndSortedList.OrderByDescending(recipe => recipe.Name);
                        }
                        break;
                    case "Date Added":
                        if (isAsc)
                        {
                            filteredAndSortedList = filteredAndSortedList.OrderBy(recipe => recipe.DateCreated);
                        }
                        else
                        {
                            filteredAndSortedList = filteredAndSortedList.OrderByDescending(recipe => recipe.DateCreated);
                        }
                        break;
                }
            }

            Recipes.Clear();
            foreach (Recipe recipe in filteredAndSortedList)
            {
                Recipes.Add(recipe);
            }
        }

        [RelayCommand]
        private void ResetFilterAndSort()
        {
            Recipes.Clear();
            SelectedDifficulty = null;
            SelectedSortCriteria = null;
            SelectedSortOrder = null;
            SearchQuery = null;
            SelectedTag = null;

            ApplyFilterAndSort();
        }

        private IEnumerable<Recipe> Search(IEnumerable<Recipe> recipes)
        {
            if (string.IsNullOrWhiteSpace(SearchQuery))
            {
                return recipes;
            }

            string query = SearchQuery.ToLower();

            //  Fuzziness threshold = 75
            return recipes.Where(recipe => recipe.Name.ToLower().Contains(query) || Fuzz.PartialRatio(recipe.Name, query) >= 75);
        }
    }
}
