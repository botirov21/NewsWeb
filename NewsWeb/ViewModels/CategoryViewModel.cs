using NewsWeb.Models;

namespace NewsWeb.ViewModels
{
    public class CategoryViewModel
    {
        public List<Category> Categories { get; set; }
        public List<News> News { get; set; }
    }
}
