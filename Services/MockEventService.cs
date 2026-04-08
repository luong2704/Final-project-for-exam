using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campus.Models;

namespace Campus.Services
{
    public class MockEventService : IEventService
    {
        private readonly List<Event> _allEvents;

        public MockEventService()
        {
            _allEvents = new List<Event>
            {
                new Event
                {
                    Id = Guid.NewGuid(),
                    Title = "Tech Talk: Introduction to .NET MAUI",
                    Description = "Learn the basics of .NET MAUI for cross-platform mobile development.",
                    Date = DateTime.Now.AddHours(2),
                    Location = "Hall A - Building 1",
                    Image = "dotnet_maui.png",
                    Category = "Academic",
                    IsRegistered = true,
                    Status = "Live"
                },
                new Event
                {
                    Id = Guid.NewGuid(),
                    Title = "Campus Music Festival",
                    Description = "Annual music festival featuring student bands and solo performers.",
                    Date = DateTime.Now.AddDays(2),
                    Location = "Open Air Theater",
                    Image = "music_fest.png",
                    Category = "Cultural",
                    IsRegistered = true,
                    Status = "Featured"
                },
                new Event
                {
                    Id = Guid.NewGuid(),
                    Title = "Career Fair 2026",
                    Description = "Meet top employers and explore internship opportunities.",
                    Date = DateTime.Now.AddDays(15),
                    Location = "Convention Center",
                    Image = "career_fair.png",
                    Category = "Social",
                    IsRegistered = true,
                    Status = "Popular"
                },
                new Event
                {
                    Id = Guid.NewGuid(),
                    Title = "Workshop: UI/UX Design Principles",
                    Description = "Hands-on workshop covering modern UI/UX design fundamentals.",
                    Date = DateTime.Now.AddDays(5),
                    Location = "Lab 3 - Building 2",
                    Image = "uiux_workshop.png",
                    Category = "Academic",
                    IsRegistered = true,
                    Status = "Limited"
                },
                new Event
                {
                    Id = Guid.NewGuid(),
                    Title = "Volleyball Tournament",
                    Description = "Inter-department volleyball tournament. All skill levels welcome!",
                    Date = DateTime.Now.AddDays(3),
                    Location = "Sports Complex",
                    Image = "volleyball.png",
                    Category = "Sports",
                    IsRegistered = true,
                    Status = "Soon"
                }
            };
        }

        public Task<List<Event>> GetAllEventsAsync()
        {
            return Task.FromResult(_allEvents.ToList());
        }

        public Task<List<Event>> GetEventsByCategoryAsync(int categoryId)
        {
            return Task.FromResult(_allEvents.ToList());
        }

        public Task<List<Event>> GetMyEventsAsync()
        {
            return Task.FromResult(_allEvents.Where(e => e.IsRegistered).ToList());
        }

        public Task<bool> RegisterEventAsync(Guid eventId, string? status = null)
        {
            var eventItem = _allEvents.FirstOrDefault(e => e.Id == eventId);
            if (eventItem != null)
            {
                eventItem.IsRegistered = true;
                if (!string.IsNullOrEmpty(status))
                {
                    eventItem.Status = status;
                }
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public Task<bool> UnregisterEventAsync(Guid eventId)
        {
            var eventItem = _allEvents.FirstOrDefault(e => e.Id == eventId);
            if (eventItem != null)
            {
                eventItem.IsRegistered = false;
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}