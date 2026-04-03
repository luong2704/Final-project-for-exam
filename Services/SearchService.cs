using System.Net.Http.Json;
using Campus.Models;

public class SearchService
{
	HttpClient _http = new HttpClient();

	public async Task<List<Event>> Search(string keyword)
	{
		var url = $"https://localhost:5001/api/events/search?q={keyword}";
		return await _http.GetFromJsonAsync<List<Event>>(url);
	}
}