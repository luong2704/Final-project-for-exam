using Campus.Models;

namespace Campus.Services;

public class CategoryService : ICategoryService
{
    private static readonly List<Category> _categories = new()
    {
        new Category { CategoryId = 1, CategoryName = "Academic", CategoryDescription = "Academic events and seminars", Color = "#2196F3", Icon = "📚", CategoryType = CategoryType.Academic },
        new Category { CategoryId = 2, CategoryName = "Sports", CategoryDescription = "Sports events and competitions", Color = "#4CAF50", Icon = "⚽", CategoryType = CategoryType.Sports },
        new Category { CategoryId = 3, CategoryName = "Cultural", CategoryDescription = "Cultural performances and exhibitions", Color = "#9C27B0", Icon = "🎭", CategoryType = CategoryType.Cultural },
        new Category { CategoryId = 4, CategoryName = "Social", CategoryDescription = "Social gatherings and networking", Color = "#FF9800", Icon = "🎉", CategoryType = CategoryType.Social },
        new Category { CategoryId = 5, CategoryName = "Volunteer", CategoryDescription = "Volunteer opportunities", Color = "#F44336", Icon = "🤝", CategoryType = CategoryType.Volunteer }
    };

    public Task<List<Category>> GetAllCategoriesAsync()
    {
        return Task.FromResult(_categories.ToList());
    }

    public Task<List<Category>> GetCategoriesByTypeAsync(CategoryType type)
    {
        return Task.FromResult(_categories.Where(c => c.CategoryType == type).ToList());
    }

    public static List<Event> FilterEventsByType(IEnumerable<Event> events, CategoryType type)
    {
        if (events == null)
        {
            return new List<Event>();
        }
        
        var categoryNamesOfType = _categories
            .Where(c => c.CategoryType == type)
            .Select(c => c.CategoryName.ToLowerInvariant())
            .ToHashSet();
        
        return events
            .Where(e => !string.IsNullOrEmpty(e.Category) && 
                        categoryNamesOfType.Contains(e.Category.ToLowerInvariant()))
            .ToList();
    }

    public static List<Event> FilterEventsByCategory(IEnumerable<Event> events, string categoryName)
    {
        if (events == null || string.IsNullOrWhiteSpace(categoryName))
        {
            return events?.ToList() ?? new List<Event>();
        }
        
        return events
            .Where(e => e.Category?.Equals(categoryName, StringComparison.OrdinalIgnoreCase) == true)
            .ToList();
    }
}
