using NewsWeb.Models;

namespace NewsWeb.Repositories
{
    public interface ICategoryInterface
    {
        Task<List<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryAsync(Guid categoryId);
        Task<Category> AddCategoryAsync(Category category);
        Task<Category> UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(Guid categoryId);
    }
}
