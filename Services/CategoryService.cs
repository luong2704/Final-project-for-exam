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

    public Task<Category?> GetCategoryByIdAsync(int id)
    {
        return Task.FromResult(_categories.FirstOrDefault(c => c.CategoryId == id));
    }

    public Task<List<Category>> GetCategoriesByTypeAsync(CategoryType type)
    {
        return Task.FromResult(_categories.Where(c => c.CategoryType == type).ToList());
    }

    public Task AddCategoryAsync(Category category)
    {
        _categories.Add(category);
        return Task.CompletedTask;
    }

    public Task UpdateCategoryAsync(Category category)
    {
        var existing = _categories.FirstOrDefault(c => c.CategoryId == category.CategoryId);
        if (existing != null)
        {
            _categories.Remove(existing);
            _categories.Add(category);
        }
        return Task.CompletedTask;
    }

    public Task DeleteCategoryAsync(int id)
    {
        var category = _categories.FirstOrDefault(c => c.CategoryId == id);
        if (category != null)
            _categories.Remove(category);
        return Task.CompletedTask;
    }
}
