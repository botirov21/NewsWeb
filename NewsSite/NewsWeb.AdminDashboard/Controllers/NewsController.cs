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
            NewsIndexViewModel viewModels = new()
            {
                NewsList = await newInterface.GetAllNewsAsync(),
                Categories = await categoryInterface.GetAllCategoriesAsync()
            };

            return View(viewModels);            
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddNewsViewModel v)
        {
            News news = new News()
            {
                Id=Guid.NewGuid(),
                Title=v.Title,
                Body=v.Body,
                Images=saveDeleteInterface.SaveImage(v.Images),
                CreatedTime=DateTime.Now,
                NumberOfViewers=0,
                CategoryId=v.CategoryId,
                Links = ""
            };
            await newInterface.AddNewsAsync(news);
            return RedirectToAction("Index");
            
        }
    }
}
