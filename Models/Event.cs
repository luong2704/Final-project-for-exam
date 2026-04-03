using System;

namespace Campus.Models
{
    public class Event
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string ImageUrl { get; set; }
        public string Category { get; set; }
        public string Status { get; set; } // e.g., "Upcoming", "Registered"

        // For easy display on UI
        public string FormattedDate => Date.ToString("MMM dd, yyyy HH:mm");
    }
}
