using Microsoft.AspNetCore.Mvc;
using NewsWeb.AdminDashboard.ViewModels;
using NewsWeb.Models;
using NewsWeb.Repositories.Interfaces;

namespace NewsWeb.AdminDashboard.Controllers
{
    public class LinksController1 : Controller
    {
        private readonly ILinksInterface linksInterface;

        public LinksController1(ILinksInterface linksInterface)
        {
            this.linksInterface = linksInterface;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var ListOfLinks = await linksInterface.GetAllLinksAsync();
            return View(ListOfLinks);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add( Links v)
        {
            Links links = new Links()
            {
                Id = Guid.NewGuid(),
                Text = v.Text,
                Url = v.Url

            };
            await linksInterface.AddLinksAsync(links);
            return RedirectToAction("index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var model = await linksInterface.GetLinksAsync(id);
            return View((LinksViewModel)model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(LinksViewModel v)
        {
            await linksInterface.UpdateLinksAsync((Links)v);
            return RedirectToAction("index");
        }
    }
}

