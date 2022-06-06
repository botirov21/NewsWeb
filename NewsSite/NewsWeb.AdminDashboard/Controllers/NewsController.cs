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
        public async Task<IActionResult> Index()
        {
            var NewsList = await newInterface.GetAllNewsAsync();
            var CategoryList = await categoryInterface.GetAllCategoriesAsync();
            List<string> CategoryName = new List<string>();
            foreach(var item in CategoryList)
            {
                CategoryName.Add(item.Name);
            }
            News news = new News();
            List<NewsIndexViewModel> viewModels = new List<NewsIndexViewModel>();
            foreach(var item2 in viewModels)
            {
                item2.CategoryForIndex = CategoryName;
                item2.Title = news.Title;
                item2.Body = news.Body;
            }


            return View(viewModels);
            
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
