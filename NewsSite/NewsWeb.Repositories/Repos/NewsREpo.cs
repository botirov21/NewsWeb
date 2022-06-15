using Microsoft.EntityFrameworkCore;
using NewsWeb.Data;
using NewsWeb.Models;
using NewsWeb.Repositories.Interfaces;
using POS_System.Domains.Pagination;

namespace NewsWeb.Repositories.Repos
{
    public class NewsRepo : INewsInterface
    {

        private readonly ApplicationDbContext _dbContext;

        public NewsRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<News> AddNewsAsync(News news)
        {

            _dbContext.News.Add(news);
            _dbContext.SaveChanges();
            return Task.FromResult(news);
        }

        public Task DeleteNewsAsync(Guid newsId)
        {
            _dbContext.News.Remove(_dbContext.News.FirstOrDefault(p => p.Id == newsId));
            _dbContext.SaveChanges();
            return Task.FromResult(0);
        }

        public Task<List<News>> GetAllNewsAsync() =>
            _dbContext.News.ToListAsync();

        public Task<News> GetCategoryNameById(Guid catagoryId)
        {
            return Task.FromResult(_dbContext.News.FirstOrDefault(i => i.CategoryId == catagoryId));
        }

        public Task<PagedList<News>> GetNews(QueryStringParameters parameters)
        {
            return Task.FromResult(PagedList<News>.ToPagedList(_dbContext.News, parameters.PageNumber, parameters.PageSize));
        }

        public Task<News> GetNewsAsync(Guid newsId) =>
            _dbContext.News.FirstOrDefaultAsync(p => p.Id == newsId);

        public Task NewViewer(Guid newsId)
        {
            var news = _dbContext.News.FirstOrDefault(n => n.Id == newsId);
            news.NumberOfViewers++;
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task<List<News>> SearchByText(string text)
        {
            var list = _dbContext.News.Where(n => n.Title.ToLower().Contains(text.ToLower()) || n.Body.ToLower().Contains(text.ToLower())).ToList();

            return Task.FromResult(list);
        }

        public Task<News> UpdateNews(News news)
        {
            _dbContext.News.Update(news);
            _dbContext.SaveChanges();
            return Task.FromResult(news);
        }


    }
}