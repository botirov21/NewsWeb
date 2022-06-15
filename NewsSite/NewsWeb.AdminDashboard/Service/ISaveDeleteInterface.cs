using NewsWeb.Models;

namespace NewsWeb.AdminDashboard.Service
{
    public interface ISaveDeleteInterface
    {
        string SaveImage(IFormFile newFile);

        News UpdateNews(News news);
        void DeleteImage(Guid id);
    }
}
