using Campus.ViewModels;

namespace Campus.Views;

public partial class EventListPage : ContentPage
{
    private readonly EventListViewModel _viewModel;

    public EventListPage(EventListViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        _viewModel = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.LoadEventsCommand.Execute(null);
    }
}
