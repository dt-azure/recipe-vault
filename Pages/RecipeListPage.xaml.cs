using RecipeVault.ViewModels;

namespace RecipeVault.Pages;

public partial class RecipeListPage : ContentPage
{
	private MainPageViewModel _viewModel;

	public RecipeListPage()
	{
		InitializeComponent();

		_viewModel = new MainPageViewModel();
		this.BindingContext = _viewModel;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await _viewModel.LoadRecipesAsync();
    }
}