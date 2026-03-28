namespace Campus.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}
    private async void OnForgotPasswordTapped(object sender, EventArgs e)
    {
        await DisplayAlert("Forgot Password", "Password recovery feature coming soon!", "OK");
    }
}