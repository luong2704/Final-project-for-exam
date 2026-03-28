using Campus.Models;

namespace Campus.Services;

public class CategoryService : ICategoryService
{
    public Task<List<Category>> GetAllCategoriesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Category?> GetCategoryByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Category>> GetCategoriesByTypeAsync(CategoryType type)
    {
        throw new NotImplementedException();
    }

    public Task AddCategoryAsync(Category category)
    {
        throw new NotImplementedException();
    }

    public Task UpdateCategoryAsync(Category category)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCategoryAsync(int id)
    {
        throw new NotImplementedException();
    }
}
