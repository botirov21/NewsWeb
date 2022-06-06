using NewsWeb.Models;

namespace NewsWeb.AdminDashboard.ViewModels
{
    public class NewsIndexViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Images { get; set; }
        public DateTime CreatedTime { get; set; }
        public int NumberOfViewers { get; set; }
        public Guid CategoryId { get; set; }
        public string Links { get; set; }
        public List<News> NewsForIndex { get; set; }
        public List<string> CategoryForIndex { get; set; }

    }
}
