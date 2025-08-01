using System.Windows.Input;

namespace RecipeVault.ViewPartials;

public partial class MainButton : ContentView
{
	public static readonly BindableProperty ButtonTextProperty = BindableProperty.Create(nameof(ButtonText), typeof(string), typeof(MainButton));

	public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(ButtonCommand), typeof(ICommand), typeof(MainButton));

	public string ButtonText
	{
		get => (string)GetValue(ButtonTextProperty);
		set => SetValue(ButtonTextProperty, value);
	}

	public ICommand ButtonCommand
	{
		get => (ICommand)GetValue(CommandProperty);
		set => SetValue(CommandProperty, value);
	}

	public MainButton()
	{
		InitializeComponent();
	}
}