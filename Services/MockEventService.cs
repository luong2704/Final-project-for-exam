using Campus.Services;
using Campus.Models;

namespace Campus.Services
{
	public class MockEventService : IEventService
	{
		private readonly List<Event> _registeredEvents;

		public MockEventService()
		{
			_registeredEvents = new List<Event>
			{
				new Event
				{
					Id = Guid.NewGuid(),
					Title = "Tech Talk: Introduction to .NET MAUI",
					Description = "Learn the basics of .NET MAUI for cross-platform mobile development.",
					Date = new DateTime(2026, 3, 15, 9, 0, 0),
					Location = "Hall A - Building 1",
					Image = "dotnet_maui.png",
					Category = "Technology",
					IsRegistered = true
				},
				new Event
				{
					Id = Guid.NewGuid(),
					Title = "Campus Music Festival",
					Description = "Annual music festival featuring student bands and solo performers.",
					Date = new DateTime(2026, 3, 20, 18, 0, 0),
					Location = "Open Air Theater",
					Image = "music_fest.png",
					Category = "Entertainment",
					IsRegistered = true
				},
				new Event
				{
					Id = Guid.NewGuid(),
					Title = "Career Fair 2026",
					Description = "Meet top employers and explore internship opportunities.",
					Date = new DateTime(2026, 3, 10, 8, 30, 0),
					Location = "Convention Center",
					Image = "career_fair.png",
					Category = "Career",
					IsRegistered = true
				},
				new Event
				{
					Id = Guid.NewGuid(),
					Title = "Workshop: UI/UX Design Principles",
					Description = "Hands-on workshop covering modern UI/UX design fundamentals.",
					Date = new DateTime(2026, 4, 5, 14, 0, 0),
					Location = "Lab 3 - Building 2",
					Image = "uiux_workshop.png",
					Category = "Workshop",
					IsRegistered = true
				},
				new Event
				{
					Id = Guid.NewGuid(),
					Title = "Volleyball Tournament",
					Description = "Inter-department volleyball tournament. All skill levels welcome!",
					Date = new DateTime(2026, 3, 25, 15, 0, 0),
					Location = "Sports Complex",
					Image = "volleyball.png",
					Category = "Sports",
					IsRegistered = true
				}
			};
		}

		public Task<List<Event>> GetMyEventsAsync()
		{
			return Task.FromResult(_registeredEvents.ToList());
		}

		public Task<bool> UnregisterEventAsync(Guid eventId)
		{
			var eventItem = _registeredEvents.FirstOrDefault(e => e.Id == eventId);
			if (eventItem != null)
			{
				_registeredEvents.Remove(eventItem);
				return Task.FromResult(true);
			}
			return Task.FromResult(false);
		}
	}
}
