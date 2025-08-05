using RecipeVault.ViewModels;

namespace RecipeVault.Pages;

public partial class RecipeListPage : ContentPage
{

	public RecipeListPage(MainPageViewModel viewModel)
	{
		InitializeComponent();

		this.BindingContext = viewModel;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is MainPageViewModel viewModel)
        {
            await viewModel.LoadRecipesAsync();
        }
    }
}