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
}