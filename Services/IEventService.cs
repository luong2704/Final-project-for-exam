using Campus.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Campus.Services
{
    public interface IEventService
    {
        // Define the contract for retrieving events
        Task<IEnumerable<Event>> GetEventsAsync();

        // Define the contract for getting a specific event by ID
        Task<Event> GetEventByIdAsync(string id);
    }
}
