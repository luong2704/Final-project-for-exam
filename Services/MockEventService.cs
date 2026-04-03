using Campus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Campus.Services
{
    public class MockEventService : IEventService
    {
        private List<Event> _events;

        public MockEventService()
        {
            // Initialize sample data for Team 2
            _events = new List<Event>
            {
                new Event {
                    Title = "Tech Workshop 2026",
                    Description = "Deep dive into .NET MAUI architecture.",
                    Date = DateTime.Now.AddDays(5),
                    Location = "Innovation Lab",
                    Category = "Education",
                    ImageUrl = "workshop.png",
                    Status = "Upcoming"
                },
                new Event {
                    Title = "Campus Marathon",
                    Description = "Annual 5km run for all students.",
                    Date = DateTime.Now.AddDays(12),
                    Location = "Main Square",
                    Category = "Sports",
                    ImageUrl = "marathon.png",
                    Status = "Registration Open"
                },
                new Event {
                    Title = "Spring Music Gala",
                    Description = "A night of live music and performances.",
                    Date = DateTime.Now.AddDays(20),
                    Location = "Grand Hall",
                    Category = "Entertainment",
                    ImageUrl = "music_gala.png",
                    Status = "Upcoming"
                }
            };
        }

        public async Task<IEnumerable<Event>> GetEventsAsync()
        {
            // Simulate a short network delay
            await Task.Delay(500);
            return await Task.FromResult(_events);
        }

        public async Task<Event> GetEventByIdAsync(string id)
        {
            var eventItem = _events.FirstOrDefault(e => e.Id == id);
            return await Task.FromResult(eventItem);
        }
    }
}
