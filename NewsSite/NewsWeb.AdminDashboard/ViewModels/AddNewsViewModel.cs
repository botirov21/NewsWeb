namespace NewsWeb.AdminDashboard.ViewModels
{
    public class AddNewsViewModel
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public IFormFile Images { get; set; }
        public Guid CategoryId { get; set; }
        public string Links { get; set; }
    }
}
