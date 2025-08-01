using RecipeVault.ViewModels;

namespace RecipeVault.Pages;

public partial class RecipeDetailsPage : ContentPage
{
	public RecipeDetailsPage(RecipeDetailsViewModel viewmodel)
	{
		InitializeComponent();

		BindingContext = viewmodel;
	}
}