using NewsWeb.Models;
using POS_System.Domains.Pagination;

namespace NewsWeb.Repositories
{
    public interface ICategoryInterface
    {
        Task<PagedList<Category>> GetCategories(QueryStringParameters parameters);
        Task<List<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryAsync(Guid categoryId);
        Task<Category> AddCategoryAsync(Category category);
        Task<Category> UpdateCategoryAsync(Category categoryId);
        Task DeleteCategoryAsync(Guid categoryId);
        Task<Category> GetCategoryByNewsCategoryId(string newCategoryName);
    }
}
