using NewsWeb.Models;

namespace NewsWeb.AdminDashboard.ViewModels
{
    public class LinksViewModel
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string Url { get; set; }



        public static explicit operator LinksViewModel(Links v)
        {
            return new LinksViewModel()
            {
                Id = v.Id,
                Text = v.Text,
                Url = v.Url,
            };
        }
        public static explicit operator Links(LinksViewModel v)
        {
            return new Links()
            {
               Id =v.Id,
               Text=v.Text,
               Url=v.Url,
            };
        }

    }
}
