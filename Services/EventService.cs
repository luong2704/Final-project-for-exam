using Campus.Models;

public class EventService : IEventService
{
    private static readonly List<Event> _events = new()
    {
        new Event { EventId = 1, EventName = "Physics Seminar", EventDescription = "Introduction to Quantum Mechanics", EventDate = DateTime.Now.AddDays(5), Location = "Science Hall 101", CategoryId = 1 },
        new Event { EventId = 2, EventName = "Basketball Tournament", EventDescription = "Inter-department basketball competition", EventDate = DateTime.Now.AddDays(3), Location = "Sports Complex", CategoryId = 2 },
        new Event { EventId = 3, EventName = "Art Exhibition", EventDescription = "Student art showcase", EventDate = DateTime.Now.AddDays(7), Location = "Gallery A", CategoryId = 3 },
        new Event { EventId = 4, EventName = "Welcome Party", EventDescription = "New semester welcome gathering", EventDate = DateTime.Now.AddDays(2), Location = "Student Center", CategoryId = 4 },
        new Event { EventId = 5, EventName = "Campus Cleanup", EventDescription = "Volunteer campus beautification", EventDate = DateTime.Now.AddDays(10), Location = "Main Campus", CategoryId = 5 },
        new Event { EventId = 6, EventName = "Math Workshop", EventDescription = "Problem solving techniques", EventDate = DateTime.Now.AddDays(4), Location = "Math Building 202", CategoryId = 1 },
        new Event { EventId = 7, EventName = "Soccer Match", EventDescription = "Friendly soccer game", EventDate = DateTime.Now.AddDays(6), Location = "Football Field", CategoryId = 2 },
        new Event { EventId = 8, EventName = "Music Concert", EventDescription = "Student band performance", EventDate = DateTime.Now.AddDays(8), Location = "Auditorium", CategoryId = 3 },
        new Event { EventId = 9, EventName = "Networking Event", EventDescription = "Meet and greet with alumni", EventDate = DateTime.Now.AddDays(12), Location = "Conference Room B", CategoryId = 4 },
        new Event { EventId = 10, EventName = "Food Drive", EventDescription = "Collect food for local shelter", EventDate = DateTime.Now.AddDays(15), Location = "Volunteer Center", CategoryId = 5 }
    };

    public Task<List<Event>> GetAllEventsAsync()
    {
        return Task.FromResult(_events.ToList());
    }

    public Task<List<Event>> GetEventsByCategoryAsync(int? categoryId)
    {
        if (categoryId == null)
            return GetAllEventsAsync();
        return Task.FromResult(_events.Where(e => e.CategoryId == categoryId).ToList());
    }

    public Task<Event?> GetEventByIdAsync(int id)
    {
        return Task.FromResult(_events.FirstOrDefault(e => e.EventId == id));
    }
}
