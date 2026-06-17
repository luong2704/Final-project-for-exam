using Campus.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Campus.Services
{
    public interface IEventService
    {
        Task<List<Event>> GetAllEventsAsync();
        Task<List<Event>> GetEventsByCategoryAsync(int categoryId);
        Task<List<Event>> GetMyEventsAsync();
        Task<Event> GetEventByIdAsync(Guid id);
        Task<bool> RegisterEventAsync(Guid eventId, string? status = null);
        Task<bool> UnregisterEventAsync(Guid eventId);
    }
}
