using Campus.Models;

namespace Campus.Services;

public class CategoryService : ICategoryService
{
    public Task<List<Category>> GetAllCategoriesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<Category>> GetCategoriesByTypeAsync(CategoryType type)
    {
        throw new NotImplementedException();
    }
}
