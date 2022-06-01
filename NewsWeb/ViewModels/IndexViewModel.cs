using NewsWeb.Models;

namespace NewsWeb.ViewModels
{
    public class IndexViewModel
    {
        public List<Category> Categories { get; set; }
        public News Top1 { get; set; }
        public List<News> Top4 { get; set;}
        public List<News> Top9 { get; set;}
    }
}
