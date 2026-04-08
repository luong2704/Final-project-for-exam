using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Campus.Models;
using Campus.Services;

namespace Campus.ViewModels;

/// <summary>
/// Task 6 – The centralized ViewModel for the Event List screen.
/// Owns: event loading, category filtering, search, and event-selection navigation.
/// Other team members should migrate their personal ViewModel logic into this class.
/// </summary>
public partial class MainEventViewModel : ObservableObject
{
    private readonly IEventService _eventService;
    private readonly ICategoryService _categoryService;

    // ── Full, unfiltered data sets ──────────────────────────────────
    private List<Event> _allEvents = new();

    // ── Observable collections bound to the UI ─────────────────────
    [ObservableProperty]
    private ObservableCollection<Event> _filteredEvents = new();

    [ObservableProperty]
    private ObservableCollection<Category> _categories = new();

    // ── Selected category for filtering ────────────────────────────
    [ObservableProperty]
    private Category? _selectedCategory;

    // ── Search text ────────────────────────────────────────────────
    [ObservableProperty]
    private string _searchText = string.Empty;

    // ── UI state flags ─────────────────────────────────────────────
    [ObservableProperty]
    private bool _isLoading;

    [ObservableProperty]
    private bool _isRefreshing;

    [ObservableProperty]
    private bool _hasNoEvents;

    // ── Selected event (for CollectionView binding) ────────────────
    [ObservableProperty]
    private Event? _selectedEvent;

    // ────────────────────────────────────────────────────────────────
    // Constructor  (DI)
    // ────────────────────────────────────────────────────────────────
    public MainEventViewModel(IEventService eventService, ICategoryService categoryService)
    {
        _eventService = eventService;
        _categoryService = categoryService;
    }

    // ────────────────────────────────────────────────────────────────
    // TASK 6 — Load all events + categories from services
    // ────────────────────────────────────────────────────────────────
    [RelayCommand]
    private async Task LoadDataAsync()
    {
        if (IsLoading) return;

        try
        {
            IsLoading = true;

            // Fetch categories
            var cats = await _categoryService.GetAllCategoriesAsync();
            Categories = new ObservableCollection<Category>(cats);

            // Fetch events
            _allEvents = await _eventService.GetAllEventsAsync();

            // Apply any current filter / search
            ApplyFilters();
        }
        finally
        {
            IsLoading = false;
            IsRefreshing = false;
        }
    }

    // ────────────────────────────────────────────────────────────────
    // TASK 6 — Category filter commands
    // ────────────────────────────────────────────────────────────────
    [RelayCommand]
    private void SelectCategory(Category? category)
    {
        // Toggle: tap same category again → clear
        if (SelectedCategory?.CategoryId == category?.CategoryId)
        {
            SelectedCategory = null;
        }
        else
        {
            SelectedCategory = category;
        }
        ApplyFilters();
    }

    [RelayCommand]
    private void ClearFilter()
    {
        SelectedCategory = null;
        SearchText = string.Empty;
        ApplyFilters();
    }

    // ────────────────────────────────────────────────────────────────
    // TASK 6 — Refresh (pull-to-refresh)
    // ────────────────────────────────────────────────────────────────
    [RelayCommand]
    private async Task RefreshAsync()
    {
        IsRefreshing = true;
        await LoadDataAsync();
    }

    // ────────────────────────────────────────────────────────────────
    // TASK 9 — Event selection command  (navigates to detail page)
    // ────────────────────────────────────────────────────────────────
    [RelayCommand]
    private async Task EventSelected(Event? eventItem)
    {
        if (eventItem is null) return;

        // Reset selection so user can tap the same item again later
        SelectedEvent = null;

        await Shell.Current.GoToAsync(nameof(Views.EventDetailPage),
            new Dictionary<string, object>
            {
                { "Event", eventItem }
            });
    }

    // ────────────────────────────────────────────────────────────────
    // Search text changed → re-filter
    // ────────────────────────────────────────────────────────────────
    partial void OnSearchTextChanged(string value)
    {
        ApplyFilters();
    }

    // ────────────────────────────────────────────────────────────────
    // Central filtering logic
    // ────────────────────────────────────────────────────────────────
    private void ApplyFilters()
    {
        IEnumerable<Event> result = _allEvents;

        // Filter by category
        if (SelectedCategory is not null)
        {
            result = result.Where(e =>
                e.Category?.Equals(SelectedCategory.CategoryName,
                    StringComparison.OrdinalIgnoreCase) == true);
        }

        // Filter by search text
        if (!string.IsNullOrWhiteSpace(SearchText))
        {
            var term = SearchText.Trim();
            result = result.Where(e =>
                (e.Title?.Contains(term, StringComparison.OrdinalIgnoreCase) == true) ||
                (e.Description?.Contains(term, StringComparison.OrdinalIgnoreCase) == true) ||
                (e.Location?.Contains(term, StringComparison.OrdinalIgnoreCase) == true));
        }

        FilteredEvents = new ObservableCollection<Event>(result);
        HasNoEvents = FilteredEvents.Count == 0;
    }
}
