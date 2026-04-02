using Campus.ViewModels;

namespace Campus.Views;

public partial class CategoryFilterView : ContentPage
{
    public CategoryFilterView(CategoryViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is CategoryViewModel vm)
        {
            if (vm.Categories.Count == 0)
                await vm.LoadCategoriesAsync();

            // Always refresh events to sync registration state
            // (e.g., after registering/unregistering from EventDetail or MyEvents)
            await vm.LoadEventsAsync();
        }
    }
}
