using NewsWeb.Models;

namespace NewsWeb.AdminDashboard.ViewModels
{
    public class AddNewsViewModel
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public IFormFile Images { get; set; }
        public DateTime CreatedTime { get; set; }
        public int NumberOfViewers { get; set; }
        public List<string> Category { get; set; }
        public string CategoryName { get; set; }
        public string Links { get; set; }
    }
}
