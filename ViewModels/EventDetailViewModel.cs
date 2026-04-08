using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Campus.Models;
using CommunityToolkit.Mvvm.Messaging;
using Campus.Messages;

namespace Campus.ViewModels;

public partial class EventDetailViewModel : ObservableObject, IQueryAttributable
{
    [ObservableProperty]
    private Event? _event;

    [ObservableProperty]
    private string _title = string.Empty;

    [ObservableProperty]
    private string _description = string.Empty;

    [ObservableProperty]
    private string _location = string.Empty;

    [ObservableProperty]
    private DateTime _date;

    [ObservableProperty]
    private string _image = string.Empty;

    [ObservableProperty]
    private string _category = string.Empty;

    [ObservableProperty]
    private bool _isRegistered;

    [ObservableProperty]
    private string _eventStatus = string.Empty;

    [ObservableProperty]
    private bool _isUpcoming;

    [ObservableProperty]
    private bool _isPast;

    [ObservableProperty]
    private Color _statusColor = Colors.Gray;

    [ObservableProperty]
    private string _statusIcon = string.Empty;

    [ObservableProperty]
    private int _daysRemaining;

    [ObservableProperty]
    private string _formattedDate = string.Empty;

    public EventDetailViewModel()
    {
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("Event", out var eventObj) && eventObj is Event selectedEvent)
        {
            LoadEventDetails(selectedEvent);
        }
    }

    private void LoadEventDetails(Event selectedEvent)
    {
        Event = selectedEvent;
        Title = selectedEvent.Title;
        Description = selectedEvent.Description;
        Location = selectedEvent.Location;
        Date = selectedEvent.Date;
        Image = selectedEvent.Image;
        Category = selectedEvent.Category;
        IsRegistered = selectedEvent.IsRegistered;

        UpdateEventStatus();
    }
    //team 8 added this method 
    [RelayCommand]
    private async Task ToggleRegistration()
    {
        if (Event == null) return;

        // toggle registration status
        Event.IsRegistered = !Event.IsRegistered;

        // notify to refresh 
        WeakReferenceMessenger.Default.Send(new EventUpdatedMessage(Event));
        await Task.CompletedTask;
    }

    private void UpdateEventStatus()
    {
        var now = DateTime.Now;
        var eventDate = Date.Date;
        var todayDate = now.Date;
        var daysUntilEvent = (eventDate - todayDate).Days;
        DaysRemaining = daysUntilEvent < 0 ? 0 : daysUntilEvent;
        string timeString = Date.ToString("h:mm tt");

        if (daysUntilEvent < 0)
        {
            EventStatus = "Past";
            IsUpcoming = false;
            IsPast = true;
            FormattedDate = Date.ToString("MMM dd, yyyy 'at' h:mm tt");
            StatusColor = Colors.Gray;
            StatusIcon = "";
        }
        else if (daysUntilEvent == 0)
        {
            EventStatus = "Today";
            IsUpcoming = true;
            IsPast = false;
            FormattedDate = $"Today at {timeString}";
            StatusColor = Colors.Red;
            StatusIcon = "";
        }
        else if (daysUntilEvent == 1)
        {
            EventStatus = "Tomorrow";
            IsUpcoming = true;
            IsPast = false;
            FormattedDate = $"Tomorrow at {timeString}";
            StatusColor = Colors.Orange;
            StatusIcon = "";
        }
        else if (daysUntilEvent <= 7)
        {
            EventStatus = "This Week";
            IsUpcoming = true;
            IsPast = false;
            FormattedDate = $"{Date:dddd} at {timeString}";
            StatusColor = Colors.Yellow;
            StatusIcon = "";
        }
        else if (daysUntilEvent <= 30)
        {
            EventStatus = "Coming Soon";
            IsUpcoming = true;
            IsPast = false;
            FormattedDate = $"{Date:MMM dd} ({daysUntilEvent} days from now)";
            StatusColor = Colors.Green;
            StatusIcon = "";
        }
        else
        {
            EventStatus = "Upcoming";
            IsUpcoming = true;
            IsPast = false;
            FormattedDate = Date.ToString("MMM dd, yyyy");
            StatusColor = Colors.Green;
            StatusIcon = "";
        }
    }

    [RelayCommand]
    private async Task Register()
    {
        if (Event == null) return;

        await Shell.Current.GoToAsync("EventRegistrationPage", new Dictionary<string, object>
        {
            { "SelectedEvent", Event }
        });
    }

    [RelayCommand]
    private async Task GoBack()
    {
        await Shell.Current.GoToAsync("..");
    }
}
