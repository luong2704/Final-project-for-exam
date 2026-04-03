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
        if (Date > DateTime.Now)
        {
            EventStatus = "Upcoming";
            IsUpcoming = true;
            IsPast = false;
        }
        else
        {
            EventStatus = "Past";
            IsUpcoming = false;
            IsPast = true;
        }
    }

    [RelayCommand]
    private async Task Register()
    {
        if (Event == null) return;

        // Navigate to Registration page (Team 4 will handle this)
        await Shell.Current.GoToAsync("EventRegistrationPage", new Dictionary<string, object>
        {
            { "Event", Event }
        });
    }

    [RelayCommand]
    private async Task GoBack()
    {
        await Shell.Current.GoToAsync("..");
    }
}
