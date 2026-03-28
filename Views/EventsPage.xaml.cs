using Campus.ViewModels;

namespace Campus.Views;

public partial class EventsPage : ContentPage
{
    public EventsPage(EventsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
