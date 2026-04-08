using Campus.ViewModels;

namespace Campus.Views;

public partial class EventDetailPage : ContentPage
{
    public EventDetailPage(EventDetailViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Refresh IsRegistered từ Event object khi quay lại từ RegistrationPage
        if (BindingContext is EventDetailViewModel vm && vm.Event != null)
        {
            vm.IsRegistered = vm.Event.IsRegistered;
        }
    }
}
