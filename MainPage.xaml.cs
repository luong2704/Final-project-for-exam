using Campus.Services;
using System.Diagnostics;
using System.Linq;

namespace Campus
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            // Run validation test for Task 4
            TestEventDataRetrieval();
        }

        private async void TestEventDataRetrieval()
        {
            // 1. Initialize Service instance
            IEventService eventService = new MockEventService();

            // 2. Fetch mock data asynchronously
            var events = await eventService.GetEventsAsync();

            // 3. Verify data in the Visual Studio Output Window
            Debug.WriteLine("-------------------------------------------");
            Debug.WriteLine("TEAM 2 SYSTEM TEST: Event Data Retrieval");
            Debug.WriteLine($"Items Found: {events.Count()}");

            foreach (var ev in events)
            {
                Debug.WriteLine($">> Event: {ev.Title} | Location: {ev.Location}");
            }
            Debug.WriteLine("-------------------------------------------");
        }
    }
}
