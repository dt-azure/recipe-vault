using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace RecipeVault.ViewModels
{
    public partial class SearchbarViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SearchCommand))]
        private string? searchQuery;

        [RelayCommand(CanExecute = nameof(CanExecuteSearch))]
        private async Task Search()
        {
            return;
        }

        //Simple check for empty queries
        private bool CanExecuteSearch()
        {
            return !string.IsNullOrEmpty(SearchQuery);
        }
    }
}
