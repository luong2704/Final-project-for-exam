<<<<<<< HEAD
using Campus.Models;

namespace Campus.Services
{
	public interface IEventService
	{
		Task<List<Event>> GetAllEventsAsync();
		Task<List<Event>> GetEventsByCategoryAsync(int categoryId);
		Task<List<Event>> GetMyEventsAsync();
		Task<bool> RegisterEventAsync(Guid eventId, string? status = null);
		Task<bool> UnregisterEventAsync(Guid eventId);
	}
=======
﻿using Campus.Models;
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
>>>>>>> 29c81fb4142b7538155217c2e6615a940834df42
}
