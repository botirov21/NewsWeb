using Microsoft.AspNetCore.Mvc;
using NewsWeb.Repositories;
using NewsWeb.Repositories.Interfaces;
using NewsWeb.ViewModels;

namespace NewsWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryInterface categoryInterface;
        private readonly INewsInterface newsInterface;

        public HomeController(ICategoryInterface categoryInterface,
                              INewsInterface newsInterface)
        {
            this.categoryInterface = categoryInterface;
            this.newsInterface = newsInterface;
        }

        public async Task<IActionResult> Index()
        {
            var list = (await newsInterface.GetAllNewsAsync()).OrderByDescending(n => n.NumberOfViewers).ToList();
            
            
            if (list.Count >= 0)
            {
                IndexViewModel viewModel = new IndexViewModel()
                {
                    Categories = await categoryInterface.GetAllCategoriesAsync(),
                    Top1 = list[0],
                    Top4 = list.GetRange(1, 3).ToList()
                };

                return View(viewModel);
            }

            return View();
        }
        public IActionResult About()
        {
            return View();

        }
        public IActionResult Blog()
        {
            return View();
        }

        public async Task<IActionResult> Categori()
        {
            var list = await categoryInterface.GetAllCategoriesAsync();
            var newsList = await newsInterface.GetAllNewsAsync();

            CategoryViewModel viewModel = new CategoryViewModel()
            {
                News = newsList.Take(4).ToList(),
                Categories = list
            };

            return View(viewModel);
        }

        public async Task<IActionResult> CategorySelect(Guid id)
        {
            var list = await categoryInterface.GetAllCategoriesAsync();
            var newsList = await newsInterface.GetAllNewsAsync();

            CategoryViewModel viewModel = new CategoryViewModel()
            {
                News = newsList.Where(n => n.CategoryId == id).ToList(),
                Categories = list
            };

            return View("Categori", viewModel);
        }

        public IActionResult Contact()
        {
            return View();

        }
        public IActionResult Details(Guid id)
        {
            var news = newsInterface.GetNewsAsync(id);
            return View(news);

        }
        public IActionResult Elements()
        {
            return View();

        }
        public IActionResult Latest_news()
        {
            return View();

        }
        public IActionResult Main()
        {
            return View();

        }
        public IActionResult Single_blog()
        {
            return View();

        }
    }
}