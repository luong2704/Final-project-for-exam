using Campus.ViewModels;

namespace Campus.Views;

public partial class EventsPage : ContentPage
{
    public EventsPage(EventViewModels viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
