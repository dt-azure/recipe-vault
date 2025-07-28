using CommunityToolkit.Mvvm.ComponentModel;

namespace RecipeVault.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private SearchbarViewModel searchbarViewModel;

        public MainPageViewModel()
        {
            searchbarViewModel = new SearchbarViewModel();
        }
    }
}
