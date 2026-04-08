using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Campus.Models;
using Campus.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Campus.ViewModels;

public partial class EventViewModels : ObservableObject
{
	private readonly ICategoryService _categoryService;
	private readonly IEventService _eventService;

	public EventViewModels(ICategoryService categoryService, IEventService eventService)
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

	[ObservableProperty]
	private bool _isBusy;

	[ObservableProperty]
	private bool _isEmpty;

	public ObservableCollection<Event> EventsList { get; } = new();
	
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

	[RelayCommand]
	private async Task LoadMyEvents()
	{
		if (IsBusy) return;

		try
		{
			IsBusy = true;
			EventsList.Clear();

			var events = await _eventService.GetMyEventsAsync();

			foreach (var e in events)
			{
				EventsList.Add(e);
			}
		}
		finally
		{
			IsBusy = false;
			IsEmpty = EventsList.Count == 0;
		}
	}

	[RelayCommand]
	private async Task Unregister(Event eventItem)
	{
		if (eventItem == null || IsBusy) return;

		// Xác nhận trước khi hủy đăng ký
		bool confirmed = await Shell.Current.DisplayAlert(
			"Cancel Registration",
			$"Are you sure you want to unregister from \"{eventItem.Title}\"?",
			"Yes, Unregister",
			"Keep My Spot");

		if (!confirmed) return;

		IsBusy = true;

		try
		{
			var success = await _eventService.UnregisterEventAsync(eventItem.Id);

			if (success)
			{
				EventsList.Remove(eventItem);
				IsEmpty = EventsList.Count == 0;

				await Shell.Current.DisplayAlert(
					"Unregistered",
					$"You have been unregistered from \"{eventItem.Title}\".",
					"OK");
			}
			else
			{
				await Shell.Current.DisplayAlert(
					"Failed",
					"Could not unregister. Please try again.",
					"OK");
			}
		}
		catch (Exception)
		{
			await Shell.Current.DisplayAlert(
				"Error",
				"An unexpected error occurred. Please check your connection and try again.",
				"OK");
		}
		finally
		{
			IsBusy = false;
		}

	}

}