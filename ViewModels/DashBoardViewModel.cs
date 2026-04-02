using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Campus.Models;
using Campus.Services;
using Campus.Session;

namespace Campus.ViewModels;

public partial class DashboardViewModel : ObservableObject
{
    private readonly IEventService _eventService;
    private List<Event> _allEvents = new();

    [ObservableProperty]
    private int totalEvents;

    [ObservableProperty]
    private int upcomingEvents;

    [ObservableProperty]
    private int attendedEvents;

    [ObservableProperty]
    private int savedEvents;

    [ObservableProperty]
    private ObservableCollection<Event> recentEvents = new();

    [ObservableProperty]
    private bool isLoading;

    [ObservableProperty]
    private string userName = string.Empty;

    [ObservableProperty]
    private string greetingMessage = string.Empty;

    public DashboardViewModel(IEventService eventService)
    {
        _eventService = eventService;
        _ = LoadDashboardDataAsync();
        InitializeGreeting();
    }

    private void InitializeGreeting()
    {
        var user = AppSession.CurrentUser;
        if (user != null)
        {
            UserName = user.Username;
            GenerateGreetingMessage();
        }
    }

    private void GenerateGreetingMessage()
    {
        var hour = DateTime.Now.Hour;
        var greeting = hour switch
        {
            >= 5 and < 12 => "Good Morning",
            >= 12 and < 17 => "Good Afternoon",
            >= 17 and < 21 => "Good Evening",
            _ => "Good Night"
        };

        GreetingMessage = $"{greeting}, {UserName}! 👋";
    }

    [RelayCommand]
    private async Task LoadDashboardDataAsync()
    {
        IsLoading = true;
        try
        {
            _allEvents = await _eventService.GetAllEventsAsync();

            CalculateStatistics();
            LoadRecentEvents();
        }
        finally
        {
            IsLoading = false;
        }
    }

    private void CalculateStatistics()
    {
        TotalEvents = _allEvents.Count;

        var now = DateTime.Now;
        UpcomingEvents = _allEvents.Count(e => e.Date > now);

        AttendedEvents = _allEvents.Count(e => e.IsRegistered);

        SavedEvents = _allEvents.Count(e => e.IsRegistered && e.Date > now);
    }

    private void LoadRecentEvents()
    {
        RecentEvents.Clear();

        var recent = _allEvents
            .Where(e => e.Date > DateTime.Now)
            .OrderBy(e => e.Date)
            .Take(5)
            .ToList();

        foreach (var evt in recent)
        {
            RecentEvents.Add(evt);
        }
    }

    [RelayCommand]
    private async Task ViewEventDetails(Event selectedEvent)
    {
        if (selectedEvent == null) return;

        await Shell.Current.GoToAsync($"eventdetail?Event={selectedEvent.Id}",
            new Dictionary<string, object> { { "Event", selectedEvent } });
    }

    [RelayCommand]
    private async Task RefreshDashboard()
    {
        await LoadDashboardDataAsync();
    }

}