using RecipeVault.Pages;

namespace RecipeVault
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            //  Register the pages with Shell's routing system
            Routing.RegisterRoute(nameof(RecipeDetailsPage), typeof(RecipeDetailsPage));
        }
    }
}
