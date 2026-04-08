using Campus.ViewModels;

namespace Campus.Views;

public partial class ProfilePage : ContentPage
{
    public ProfilePage()
    {
        InitializeComponent();
        BindingContext = new ProfileViewModel();
    }
        private async void OnLogoutClicked(object sender, EventArgs e)
    {
        Preferences.Remove("UserToken");

        await Shell.Current.GoToAsync("//LoginPage");
    }
}
