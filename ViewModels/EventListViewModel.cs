using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Campus.Models;
using Campus.Services;

namespace Campus.ViewModels;

public partial class EventListViewModel : ObservableObject
{
    private readonly IEventService _eventService;

    public ObservableCollection<Event> Events { get; } = new();

    [ObservableProperty]
    private bool isLoading;

    public EventListViewModel(IEventService eventService)
    {
        _eventService = eventService;
    }

    // ─────────────────────────────
    // TASK 6 — LOAD EVENTS
    // ─────────────────────────────
    [RelayCommand]
    private async Task LoadEventsAsync()
    {
        try
        {
            IsLoading = true;

            var events = await _eventService.GetAllEventsAsync();

            Events.Clear();
            foreach (var evt in events)
            {
                Events.Add(evt);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            IsLoading = false;
        }
    }

    // ─────────────────────────────
    // TASK 9 — SELECT EVENT
    // ─────────────────────────────
    [RelayCommand]
    private async Task SelectEvent(Event? selectedEvent)
    {
        if (selectedEvent == null) return;

        await Shell.Current.GoToAsync("EventDetailPage", new Dictionary<string, object>
        {
            { "Event", selectedEvent }
        });
    }

}