using Campus.ViewModels;

namespace Campus.Views;

public partial class SearchPage : ContentPage
{
	public SearchPage()
	{
		InitializeComponent();
		BindingContext = new SearchViewModel();
	}
}