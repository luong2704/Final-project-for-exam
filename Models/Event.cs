<<<<<<< HEAD
using CommunityToolkit.Mvvm.ComponentModel;

namespace Campus.Models
{
    public partial class Event : ObservableObject
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;

        // ObservableProperty: fires PropertyChanged when set
        // → CollectionView badge updates in real-time without list reload
        [ObservableProperty]
        private bool _isRegistered;

        [ObservableProperty]
        private string _status = "Upcoming";
=======
﻿using System;

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
>>>>>>> 29c81fb4142b7538155217c2e6615a940834df42
    }
}
