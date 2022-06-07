using NewsWeb.Models;

namespace NewsWeb.AdminDashboard.ViewModels
{
    public class NewsIndexViewModel
    {
        public List<News> NewsList { get; set; }
        public List<Category> Categories { get; set; }

    }
}
