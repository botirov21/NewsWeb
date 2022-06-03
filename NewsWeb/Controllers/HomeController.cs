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
            var list2 = (await newsInterface.GetAllNewsAsync()).OrderByDescending(n => n.CreatedTime).ToList();


            if (list.Count >= 0)
            {
                IndexViewModel viewModel = new IndexViewModel()
                {
                    Categories = await categoryInterface.GetCategoriesAsync(),
                    Top1 = list[0],
                    Top4 = null,
                    Top9 = null,
                    Weekly5 = list2.GetRange(0, 5),
                };

                if (list.Count > 1)
                {
                    viewModel.Top4 = list.GetRange(1, 3).ToList();
                }

                if (list.Count > 4)
                {
                    if (list.Count < 10)
                    {
                        viewModel.Top9 = list.GetRange(4, list.Count-4).ToList();
                    }
                    else
                    {
                        viewModel.Top9 = list.GetRange(4, 8).ToList();
                    }
                }

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
            var list = await categoryInterface.GetCategoriesAsync();
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
            var list = await categoryInterface.GetCategoriesAsync();
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