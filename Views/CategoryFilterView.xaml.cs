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
        if (BindingContext is CategoryViewModel vm && vm.Categories.Count == 0)
        {
            await vm.LoadCategoriesAsync();
            await vm.LoadEventsAsync();
        }
    }
}
