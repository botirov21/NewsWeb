using Microsoft.EntityFrameworkCore;
using NewsWeb.Data;
using NewsWeb.Models;
using POS_System.Domains.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsWeb.Repositories.Repos
{
    public class CategoryRepo : ICategoryInterface
    {

        private readonly ApplicationDbContext _dbContext;

        public CategoryRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Category> AddCategoryAsync(Category category)
        {
           _dbContext.Categories.Add(category);
           _dbContext.SaveChanges();
            return Task.FromResult(category);

        }

        public Task DeleteCategoryAsync(Guid categoryId)
        {
#pragma warning disable CS8604 // Possible null reference argument for parameter 'entity' in 'EntityEntry<Category> DbSet<Category>.Remove(Category entity)'.
            _dbContext.Categories.Remove(_dbContext.Categories.FirstOrDefault(p => p.Id == categoryId));
#pragma warning restore CS8604 // Possible null reference argument for parameter 'entity' in 'EntityEntry<Category> DbSet<Category>.Remove(Category entity)'.
            _dbContext.SaveChanges();
            return Task.FromResult(0);
        }

        public Task<List<Category>> GetAllCategoriesAsync()
        {
            return Task.FromResult(_dbContext.Categories.OrderBy(c => c.Name).ToList());
        }

        public Task<PagedList<Category>> GetCategories(QueryStringParameters parameters)
        {
            return Task.FromResult(PagedList<Category>.ToPagedList(_dbContext.Categories, parameters.PageNumber, parameters.PageSize));
        }


        public Task<List<Category>> GetCategoriesAsync()
        {
            throw new Exception();
        }
          
        public Task<Category> GetCategoryAsync(Guid categoryId) =>
#pragma warning disable CS8619 // Nullability of reference types in value of type 'Task<Category?>' doesn't match target type 'Task<Category>'.
            _dbContext.Categories.FirstOrDefaultAsync(p => p.Id == categoryId);
#pragma warning restore CS8619 // Nullability of reference types in value of type 'Task<Category?>' doesn't match target type 'Task<Category>'.

        public Task<Category> GetCategoryByNewsCategoryId(string newCategoryName)
        {
#pragma warning disable CS8619 // Nullability of reference types in value of type 'Task<Category?>' doesn't match target type 'Task<Category>'.
            return Task.FromResult(_dbContext.Categories.FirstOrDefault(p => p.Name == newCategoryName));
#pragma warning restore CS8619 // Nullability of reference types in value of type 'Task<Category?>' doesn't match target type 'Task<Category>'.
        }

        public Task<Category> UpdateCategoryAsync(Category categoryId)
        {
            _dbContext.Categories.Update(categoryId);
            _dbContext.SaveChanges();
            return Task.FromResult(categoryId);
        }
    }
}
