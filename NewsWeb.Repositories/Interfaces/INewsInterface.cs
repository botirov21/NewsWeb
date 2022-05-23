using NewsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsWeb.Repositories.Interfaces
{
    public interface INewsInterface
    {
        Task<List<News>> GetAllNewsAsync();
        Task<News> GetNewsAsync(Guid newsId);
        Task<News> AddNewsAsync(News news);
        Task<News> UpdateNewsAsync(News news);
        Task DeleteNewsAsync(Guid newsId);
    }
}
