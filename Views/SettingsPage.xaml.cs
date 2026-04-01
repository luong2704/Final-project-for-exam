using Campus.ViewModels;

namespace Campus.Views;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
        BindingContext = new SettingsViewModel();
    }
}