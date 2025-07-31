using RecipeVault.ViewModels;
namespace RecipeVault
{
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel _viewModel;

        public MainPage()
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
}
