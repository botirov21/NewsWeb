
using Microsoft.AspNetCore.Mvc;
using NewsWeb.AdminDashboard.Service;
using NewsWeb.AdminDashboard.Services;
using NewsWeb.AdminDashboard.ViewModels;
using NewsWeb.Models;
using NewsWeb.Repositories;
using NewsWeb.Repositories.Interfaces;
using Telegram.Bot;

namespace NewsWeb.AdminDashboard.Controllers
{
   
    public class NewsController : Controller
    {
        private TelegramBotClient client = new TelegramBotClient("2116797944:AAGP2DCaZa4rXqCJoo7OwiuUr5OlBCYs10E");
        
        private readonly INewsInterface newInterface;
        private readonly ISaveDeleteInterface saveDeleteInterface;
        private readonly ICategoryInterface categoryInterface;
        private readonly IWebHostEnvironment environment;
        private readonly IImageControllerInterface imageController;

        public NewsController( INewsInterface newInterface,
                                ISaveDeleteInterface saveDeleteInterface,
                                ICategoryInterface categoryInterface,
                                IWebHostEnvironment environment,
                                IImageControllerInterface imageController )
        {
            this.newInterface = newInterface;
            this.saveDeleteInterface = saveDeleteInterface;
            this.categoryInterface = categoryInterface;
            this.environment = environment;
            this.imageController = imageController;
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
        public IActionResult Add()
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
                Links =v.Links
            };
            await newInterface.AddNewsAsync(news);

            using (var stream = System.IO.File.Open(Path.Combine(environment.WebRootPath, "Images", news.Images), FileMode.Open))
            {
                await client.SendPhotoAsync(
                    chatId: "@snsnshdh",
                    photo: stream,
                    caption: $"<b>{news.Title}</b> \n\n {news.Body}",
                    parseMode: Telegram.Bot.Types.Enums.ParseMode.Html
                );
            }

            return RedirectToAction("Index");            
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var item = await newInterface.GetNewsAsync(id);
            return View((NewsEditViewModel)item);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(NewsEditViewModel v)
        {
            if (v.NewImage is not null)
            {
                string img = Path.Combine(environment.WebRootPath, "Images", v.Images);
                FileInfo info = new FileInfo(img);
                if (info != null)
                {
                    System.IO.File.Delete(img);
                }
                v.Images = imageController.SaveImage(v.NewImage);
            }

            await newInterface.UpdateNews((News)v);
            return RedirectToAction("index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var item = await newInterface.GetNewsAsync(id);
            string img = Path.Combine(environment.WebRootPath, "images", item.Images);
            FileInfo info = new FileInfo(img);
            if (info != null)
            {
                System.IO.File.Delete(img);
            }
            await newInterface.DeleteNewsAsync(id);
            return RedirectToAction("index");

        }
    }
}
