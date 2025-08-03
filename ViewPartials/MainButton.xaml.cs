using System.Windows.Input;

namespace RecipeVault.ViewPartials;

public partial class MainButton : ContentView
{
	public static readonly BindableProperty ButtonTextProperty = BindableProperty.Create(nameof(ButtonText), typeof(string), typeof(MainButton));

	public static readonly BindableProperty ButtonCommandProperty = BindableProperty.Create(nameof(ButtonCommand), typeof(ICommand), typeof(MainButton));

	public string ButtonText
	{
		get => (string)GetValue(ButtonTextProperty);
		set => SetValue(ButtonTextProperty, value);
	}

	public ICommand ButtonCommand
	{
		get => (ICommand)GetValue(ButtonCommandProperty);
		set => SetValue(ButtonCommandProperty, value);
	}

	public MainButton()
	{
		InitializeComponent();
	}
}