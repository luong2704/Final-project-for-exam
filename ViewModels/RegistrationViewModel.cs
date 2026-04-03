using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Campus.Models;
using Campus.Services;

namespace Campus.ViewModels;

[QueryProperty(nameof(SelectedEvent), "SelectedEvent")]
public partial class RegistrationViewModel : ObservableObject
{
    private readonly IEventService _eventService;

    [ObservableProperty]
    private Event? _selectedEvent;

    [ObservableProperty]
    private bool _isLoading;

    [ObservableProperty]
    private bool _isSuccess;

    [ObservableProperty]
    private string _statusMessage = string.Empty;

    public RegistrationViewModel(IEventService eventService)
    {
        _eventService = eventService;
    }

    [RelayCommand]
    private async Task ConfirmRegistration()
    {
        if (SelectedEvent == null || IsLoading) return;

        // Guard: already registered
        if (SelectedEvent.IsRegistered)
        {
            IsSuccess = true;
            StatusMessage = "You are already registered for this event.";
            return;
        }

        IsLoading = true;
        StatusMessage = string.Empty;

        try
        {
            var success = await _eventService.RegisterEventAsync(SelectedEvent.Id);

            if (success)
            {
                SelectedEvent.IsRegistered = true;
                IsSuccess = true;
                StatusMessage = "You have successfully registered for this event!";
            }
            else
            {
                StatusMessage = "Registration failed. The event may be full or unavailable.";
            }
        }
        catch (Exception)
        {
            StatusMessage = "An unexpected error occurred. Please check your connection and try again.";
        }
        finally
        {
            IsLoading = false;
        }
    }

    [RelayCommand]
    private async Task GoToMyEvents()
    {
        // Navigate to My Events tab
        await Shell.Current.GoToAsync("//MyEventsPage");
    }

    [RelayCommand]
    private async Task Cancel()
    {
        await Shell.Current.GoToAsync("..");
    }
}
