using Microsoft.AspNetCore.Mvc;
using NewsWeb.AdminDashboard.Service;
using NewsWeb.AdminDashboard.ViewModels;
using NewsWeb.Models;
using NewsWeb.Repositories;
using NewsWeb.Repositories.Interfaces;

namespace NewsWeb.AdminDashboard.Controllers
{
   
    public class NewsController : Controller
    {
        private readonly INewsInterface newInterface;
        private readonly ISaveDeleteInterface saveDeleteInterface;
        private readonly ICategoryInterface categoryInterface;

        public NewsController( INewsInterface newInterface,
            ISaveDeleteInterface saveDeleteInterface,
            ICategoryInterface categoryInterface)
        {
            this.newInterface = newInterface;
            this.saveDeleteInterface = saveDeleteInterface;
            this.categoryInterface = categoryInterface;
        }
        public async Task<IActionResult> Index(NewsIndexViewModel v)
        {
           var categoryName = categoryInterface.GetAllCategoriesAsync();
            var newsForCategory = newInterface.GetAllNewsAsync();
            Category category = new Category();
            var item = await newInterface.GetCategoryNameById(category.Id);
            NewsIndexViewModel newsIndexViewModel = new NewsIndexViewModel();
            item.
          
            return View(item);
            
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            List<string> Categories = new List<string>();
            var list = await categoryInterface.GetAllCategoriesAsync();
            foreach (var item in list)
            {
                Categories.Add(item.Name);
            }

            AddNewsViewModel viewModel = new AddNewsViewModel()
            {
                Category = Categories
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddNewsViewModel v)
        {
            var item = await categoryInterface.GetAllCategoriesAsync();
            var category = item.FirstOrDefault(t => t.Name == v.CategoryName);
            News news = new News()
            {
                Id=Guid.NewGuid(),
                Title=v.Title,
                Body=v.Body,
                Images=saveDeleteInterface.SaveImage(v.Images),
                CreatedTime=DateTime.Now,
                NumberOfViewers=0,
                CategoryId=category.Id,
                Links=v.Links
            };
            await newInterface.AddNewsAsync(news);
            return RedirectToAction("Index");
            
        }
    }
}
