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

    
}