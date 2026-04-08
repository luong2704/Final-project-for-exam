using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Campus.Models;
using Campus.Services;
using CommunityToolkit.Mvvm.Messaging;
using Campus.Messages;
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
    }

    public void RegisterForMessages()
    {
        // Reload dashboard data when an event is updated elsewhere in the app
        WeakReferenceMessenger.Default.Register<EventUpdatedMessage>(this, (r, m) =>
        {
            if (r is DashboardViewModel vm)
            {
                if (vm.LoadDashboardDataCommand.CanExecute(null))
                {
                    _ = vm.LoadDashboardDataCommand.ExecuteAsync(null);
                }
            }
        });
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
            >= 5 and < 12 => "Chào buổi sáng",
            >= 12 and < 17 => "Chào buổi chiều",
            >= 17 and < 21 => "Chào buổi tối",
            _ => "Chào đêm"
        };

        GreetingMessage = $"{greeting}, {UserName}! 👋";
    }

    
    /// load Dashboard  data
    
    [RelayCommand]
    private async Task LoadDashboardDataAsync()
    {
        IsLoading = true;
        try
        {
            
            InitializeGreeting();

			// take all events of user
			_allEvents = await _eventService.GetAllEventsAsync();

            
            CalculateStatistics();

           
            LoadRecentEvents();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Lỗi tải Dashboard: {ex.Message}");
        }
        finally
        {
            IsLoading = false;
        }
    }

	// Calculate statistics for the dashboard
	private void CalculateStatistics()
    {
        
        TotalEvents = _allEvents.Count;

        var now = DateTime.Now;

       
        UpcomingEvents = _allEvents.Count(e => e.Date > now);

      
        AttendedEvents = _allEvents.Count(e => e.IsRegistered);

        
        SavedEvents = _allEvents.Count(e => e.IsRegistered && e.Date > now);
    }
	// Load recent events for the dashboard
	private void LoadRecentEvents()
    {
        RecentEvents.Clear();

        var recent = _allEvents
            .Where(e => e.Date > DateTime.Now)          
            .OrderBy(e => e.Date)                       
            .Take(5)             // 5 events                          
            .ToList();

        
        foreach (var evt in recent)
        {
            RecentEvents.Add(evt);
        }
    }

   
    [RelayCommand]
    private async Task ViewEventDetails(Event? selectedEvent)
    {
        if (selectedEvent == null) return;

        await Shell.Current.GoToAsync($"eventdetail?eventId={selectedEvent.Id}",
            new Dictionary<string, object> { { "Event", selectedEvent } });
    }

   
    [RelayCommand]
    private async Task RefreshDashboard()
    {
        await LoadDashboardDataAsync();
    }
}