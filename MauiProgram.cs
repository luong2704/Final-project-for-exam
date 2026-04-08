using Microsoft.Extensions.Logging;
using Campus.Services;
using Campus.ViewModels;
using Campus.Views;

namespace Campus
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<ICategoryService, CategoryService>();
            builder.Services.AddSingleton<IEventService, MockEventService>();
            builder.Services.AddTransient<EventViewModels>();
            builder.Services.AddTransient<RegistrationViewModel>();
            builder.Services.AddTransient<Views.RegistrationPage>();
            builder.Services.AddTransient<Views.MyEventsPage>();
            builder.Services.AddTransient<EventDetailViewModel>();
            builder.Services.AddTransient<EventDetailPage>();  // Team 3
            builder.Services.AddTransient<CategoryViewModel>();
            builder.Services.AddTransient<EventListViewModel>();              // Team 2 — Event List (Thao)
            builder.Services.AddTransient<Views.EventListPage>();
            builder.Services.AddSingleton<CampusService>();
            builder.Services.AddTransient<MainPage>();

            

#if DEBUG
            builder.Logging.AddDebug();
#endif

            Routing.RegisterRoute("EventDetailPage", typeof(EventDetailPage));          // Team 3
            Routing.RegisterRoute("categoryfilter", typeof(CategoryFilterView));
            Routing.RegisterRoute("EventRegistrationPage", typeof(Views.RegistrationPage)); // Team 4

            return builder.Build();
        }
    }
}