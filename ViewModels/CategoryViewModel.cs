using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Campus.Models;
using Campus.Services;

namespace Campus.ViewModels;

public partial class CategoryViewModel : ObservableObject
{
    private readonly ICategoryService _categoryService;
    private readonly IEventService _eventService;
    private List<Event> _allEvents = new();

    public ObservableCollection<Category> Categories { get; } = new();
    public ObservableCollection<Event> FilteredEvents { get; } = new();

    [ObservableProperty]
    private Category? _selectedCategory;

    [ObservableProperty]
    private bool _isFiltered;

    public CategoryViewModel(ICategoryService categoryService, IEventService eventService)
    {
        _categoryService = categoryService;
        _eventService = eventService;
    }

    [RelayCommand]
    private void ApplyFilter()
    {
        if (SelectedCategory != null)
        {
            IsFiltered = true;
            FilteredEvents.Clear();
            var filtered = _allEvents
                .Where(e => e.Category == SelectedCategory.CategoryName)
                .ToList();
            foreach (var evt in filtered)
            {
                FilteredEvents.Add(evt);
            }
        }
    }

    [RelayCommand]
    private void ClearFilter()
    {
        SelectedCategory = null;
        IsFiltered = false;
        FilteredEvents.Clear();
        foreach (var evt in _allEvents)
        {
            FilteredEvents.Add(evt);
        }
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

    public async Task LoadEventsAsync()
    {
        var events = await _eventService.GetAllEventsAsync();
        _allEvents = events;
        FilteredEvents.Clear();
        foreach (var evt in events)
        {
            FilteredEvents.Add(evt);
        }
    }
}
