using Campus.ViewModels;

namespace Campus.Views;

public partial class DashboardPage : ContentPage
{
    private DashboardViewModel? _viewModel;

    public DashboardPage(DashboardViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (_viewModel?.LoadDashboardDataCommand.CanExecute(null) ?? false)
        {
            await _viewModel.LoadDashboardDataCommand.ExecuteAsync(null);
        }
    }
}