using Campus.Models;

namespace Campus.Services
{
	public interface IEventService
	{
		Task<List<Event>> GetMyEventsAsync();
		Task<bool> UnregisterEventAsync(Guid eventId);
	}
}
