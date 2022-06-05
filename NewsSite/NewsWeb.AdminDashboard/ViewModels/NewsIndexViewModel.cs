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
        public Category Category { get; set; }
        public string CategoryName { get; set; }
        public string Links { get; set; }

    }
}
