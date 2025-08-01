using Microsoft.Extensions.Logging;
using RecipeVault.Pages;
using RecipeVault.ViewModels;

namespace RecipeVault
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            //  Register ViewModels and Pages for dependency injection
            builder.Services.AddSingleton<MainPageViewModel>();
            builder.Services.AddSingleton<MainPage>();

            //  Transient = new instance is created every time it's requested
            builder.Services.AddTransient<RecipeDetailsViewModel>();
            builder.Services.AddTransient<RecipeDetailsPage>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
