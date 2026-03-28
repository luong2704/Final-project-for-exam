using Campus.Models;

public interface IEventService
{
    Task<List<Event>> GetAllEventsAsync();
    Task<List<Event>> GetEventsByCategoryAsync(int? categoryId);
    Task<Event?> GetEventByIdAsync(int id);
}
