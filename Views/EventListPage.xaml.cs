using Campus.ViewModels;

namespace Campus.Views;

public partial class EventListPage : ContentPage
{
    private readonly MainEventViewModel _viewModel;

    public EventListPage(MainEventViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Load events + categories each time the page appears
        if (_viewModel.LoadDataCommand.CanExecute(null))
        {
            _viewModel.LoadDataCommand.Execute(null);
        }
    }
}
