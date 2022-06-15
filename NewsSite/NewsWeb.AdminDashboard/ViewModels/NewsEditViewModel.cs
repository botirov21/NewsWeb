using NewsWeb.Models;
using System.ComponentModel.DataAnnotations;

namespace NewsWeb.AdminDashboard.ViewModels
{
    public class NewsEditViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
        public string Images { get; set; }
        public IFormFile? NewImage { get; set; }

        public DateTime CreatedTime { get; set; }

        public Guid CategoryId { get; set; }
        public string Links { get; set; }

        public static explicit operator NewsEditViewModel(News v)
        {
            return new NewsEditViewModel()
            {
                Id = v.Id,
                Title = v.Title,
                Body = v.Body,
                Images=v.Images,
                CreatedTime = v.CreatedTime,
                CategoryId=v.CategoryId,
                Links=v.Links,

            };
        }

        public static explicit operator News(NewsEditViewModel v)
        {
            return new News()
            {
                Id = v.Id,
                Title = v.Title,
                Body = v.Body,
                Images = v.Images,
                CreatedTime = v.CreatedTime,
                CategoryId = v.CategoryId,
                Links = v.Links,
             
            };
        }
    }
}