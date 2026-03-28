using Campus.Services;
using Campus.Models;
using Campus.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace Campus.ViewModels
{
	public partial class EventsViewModel : ObservableObject
	{
		private readonly IEventService _EventService;

		[ObservableProperty]
		private bool _isBusy;

		[ObservableProperty]
		private bool _isEmpty;

		public ObservableCollection<Event> EventsList { get; } = new();

		public EventsViewModel(IMyEventService myEventService)
		{
			_EventService = myEventService;
		}

		[RelayCommand]
		private async Task LoadMyEvents()
		{
			if (IsBusy) return;

			try
			{
				IsBusy = true;
				EventsList.Clear();

				var events = await _EventService.GetMyEventsAsync();

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
			if (eventItem == null) return;

			var success = await _EventService.UnregisterEventAsync(eventItem.Id);

			if (success)
			{
				EventsList.Remove(eventItem);
				IsEmpty = EventsList.Count == 0;
			}
		}
	}
}
