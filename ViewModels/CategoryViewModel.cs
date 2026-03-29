using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Campus.Models;
using Campus.Services;

namespace Campus.ViewModels;

public partial class CategoryViewModel : ObservableObject
{
    private readonly ICategoryService _categoryService;

    public ObservableCollection<Category> Categories { get; } = new();

    [ObservableProperty]
    private Category? _selectedCategory;

    [ObservableProperty]
    private bool _isFiltered;

    public CategoryViewModel(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [RelayCommand]
    private void ApplyFilter()
    {
        if (SelectedCategory != null)
        {
            IsFiltered = true;
        }
    }

    [RelayCommand]
    private void ClearFilter()
    {
        SelectedCategory = null;
        IsFiltered = false;
    }

    public async Task LoadCategoriesAsync()
    {
        var categories = await _categoryService.GetAllCategoriesAsync();
        Categories.Clear();
        foreach (var category in categories)
        {
            Categories.Add(category);
        }
    }
}
