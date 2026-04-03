using Campus.Models;

namespace Campus.Services;

public interface ICategoryService
{
    Task<List<Category>> GetAllCategoriesAsync();
    Task<List<Category>> GetCategoriesByTypeAsync(CategoryType type);
}
