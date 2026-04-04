using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace Campus.ViewModels
{
	public partial class MyEventsViewModel : ObservableObject
	{
		public ObservableCollection<Event> MyEventsList { get; set; } = new();

		public MyEventsViewModel()
		{
			LoadData();
		}

		public void LoadData()
		{
			MyEventsList.Add(new Event
			{
				Title = "Tech Talk",
				Location = "Hanoi",
				Time = "10:00"
			});

			MyEventsList.Add(new Event
			{
				Title = "AI Workshop",
				Location = "HCM",
				Time = "14:00"
			});
		}

		[RelayCommand]
		public void Unregister(Event eventItem)
		{
			MyEventsList.Remove(eventItem);
		}
	}

	public class Event
	{
		public string Title { get; set; }
		public string Location { get; set; }
		public string Time { get; set; }
	}
}