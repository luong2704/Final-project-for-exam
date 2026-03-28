using Campus.Models;

namespace Campus.Services
{
	public interface IEventService
	{
		Task<List<Event>> GetMyEventsAsync();
		Task<bool> RegisterEventAsync(Guid eventId);
		Task<bool> UnregisterEventAsync(Guid eventId);
	}
}
