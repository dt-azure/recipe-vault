using RecipeVault.ViewModels;

namespace RecipeVault.ViewPartials;

public partial class Searchbar : ContentView
{
	public Searchbar()
	{
		InitializeComponent();
	}

	private void SearchEntryCompleted(object sender,  EventArgs e)
	{
		if (BindingContext is MainPageViewModel viewModel)
		{
			if (viewModel.ApplyFilterAndSortCommand.CanExecute(null))
			{
				viewModel.ApplyFilterAndSortCommand.Execute(null);
			}
		}
	}
}