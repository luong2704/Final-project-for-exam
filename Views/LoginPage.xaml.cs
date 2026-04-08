namespace Campus.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();

        // Set binding context to the view model
        this.BindingContext = new Campus.ViewModels.LoginViewModel();
	}
    private async void OnForgotPasswordTapped(object sender, EventArgs e)
    {
        await DisplayAlert("Forgot Password", "Password recovery feature coming soon!", "OK");
    }
    private async void OnRegisterTapped(object sender, EventArgs e)
    {
        await DisplayAlert("Register", "Navigate to register page (not implemented yet).", "OK");
    }
}