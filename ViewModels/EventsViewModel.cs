using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Campus.Models;
using Campus.Services;

namespace Campus.ViewModels;

public partial class EventsViewModel : ObservableObject
{
    private readonly ICategoryService _categoryService;
    private readonly IEventService _eventService;

    public EventsViewModel(ICategoryService categoryService, IEventService eventService)
    {
        _categoryService = categoryService;
        _eventService = eventService;
        _ = LoadDataAsync();
    }

    [ObservableProperty]
    private ObservableCollection<Category> _categories = new();

    [ObservableProperty]
    private ObservableCollection<Event> _events = new();

    [ObservableProperty]
    private ObservableCollection<Event> _filteredEvents = new();

    [ObservableProperty]
    private Category? _selectedCategory;

    [ObservableProperty]
    private bool _isLoading;

    [ObservableProperty]
    private bool _hasNoEvents;

    private async Task LoadDataAsync()
    {
        IsLoading = true;
        try
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            Categories = new ObservableCollection<Category>(categories);

            var events = await _eventService.GetAllEventsAsync();
            Events = new ObservableCollection<Event>(events);
            
            FilteredEvents = new ObservableCollection<Event>(events);
            HasNoEvents = !FilteredEvents.Any();
        }
        finally
        {
            IsLoading = false;
        }
    }

    [RelayCommand]
    private async Task SelectCategory(Category? category)
    {
        SelectedCategory = category;
        await FilterEventsAsync();
    }

    [RelayCommand]
    private async Task ShowAllCategories()
    {
        SelectedCategory = null;
        await FilterEventsAsync();
    }

    [RelayCommand]
    private async Task RefreshAsync()
    {
        await LoadDataAsync();
        if (SelectedCategory != null)
        {
            await FilterEventsAsync();
        }
    }

    private async Task FilterEventsAsync()
    {
        if (SelectedCategory == null)
        {
            FilteredEvents = new ObservableCollection<Event>(Events);
        }
        else
        {
            var filtered = await _eventService.GetEventsByCategoryAsync(SelectedCategory.CategoryId);
            FilteredEvents = new ObservableCollection<Event>(filtered);
        }
        HasNoEvents = !FilteredEvents.Any();
    }
}
