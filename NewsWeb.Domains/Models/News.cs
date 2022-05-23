namespace NewsWeb.Models
{
    public class News
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Images { get; set; }
        public DateTime CreatedTime { get; set; }
        public int NumberOfViewers { get; set; }
        public int CategoryId { get; set; }
        public string Links { get; set; }

    }
}
