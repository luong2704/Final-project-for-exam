namespace Campus_Activity_Manager.Models
{
	public class Event
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime Date { get; set; }
		public string Location { get; set; }
		public string Image { get; set; }
		public string Category { get; set; }
		public bool IsRegistered { get; set; }
	}
}
