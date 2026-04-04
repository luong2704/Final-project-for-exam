using Campus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Campus.Services
{
    public class MockEventService : IEventService
    {
        private readonly List<Event> _events;

        public MockEventService()
        {
            _events = new List<Event>
            {
                new Event
                {
                    Id = Guid.NewGuid(),
                    Title = "Tech Talk: Introduction to .NET MAUI",
                    Description = "Learn the basics of .NET MAUI.",
                    Date = DateTime.Now.AddDays(2),
                    Location = "Hall A",
                    Category = "Academic",
                    Status = "Live",
                    IsRegistered = false
                },
                new Event
                {
                    Id = Guid.NewGuid(),
                    Title = "Campus Marathon",
                    Description = "Annual 5km run.",
                    Date = DateTime.Now.AddDays(5),
                    Location = "Main Square",
                    Category = "Sports",
                    Status = "Upcoming",
                    IsRegistered = false
                }
            };
        }

        public Task<List<Event>> GetAllEventsAsync()
        {
            return Task.FromResult(_events.ToList());
        }

        public Task<List<Event>> GetEventsByCategoryAsync(int categoryId)
        {
            // TEMP: Adjust when CategoryId exists
            return Task.FromResult(_events.ToList());
        }

        public Task<List<Event>> GetMyEventsAsync()
        {
            return Task.FromResult(_events.Where(e => e.IsRegistered).ToList());
        }

        public Task<Event> GetEventByIdAsync(Guid id)
        {
            var ev = _events.FirstOrDefault(e => e.Id == id);
            return Task.FromResult(ev);
        }

        public Task<bool> RegisterEventAsync(Guid eventId, string? status = null)
        {
            var ev = _events.FirstOrDefault(e => e.Id == eventId);
            if (ev == null) return Task.FromResult(false);

            ev.IsRegistered = true;
            if (!string.IsNullOrEmpty(status))
                ev.Status = status;

            return Task.FromResult(true);
        }

        public Task<bool> UnregisterEventAsync(Guid eventId)
        {
            var ev = _events.FirstOrDefault(e => e.Id == eventId);
            if (ev == null) return Task.FromResult(false);

            ev.IsRegistered = false;
            return Task.FromResult(true);
        }
    }
}