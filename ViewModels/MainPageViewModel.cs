using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using RecipeVault.Model;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Diagnostics;
using System.Text.Json.Serialization.Metadata;

namespace RecipeVault.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private SearchbarViewModel searchbarViewModel;

        [ObservableProperty]
        private ObservableCollection<Recipe> _recipes;

        //private readonly string _filePath;
        private readonly JsonSerializerOptions _jsonOptions;

        public MainPageViewModel()
        {
            searchbarViewModel = new SearchbarViewModel();
            _recipes = new ObservableCollection<Recipe>();

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

                if (loadedRecipes != null)
                {
                    foreach (var recipe in loadedRecipes)
                    {
                        Recipes.Add(recipe);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
