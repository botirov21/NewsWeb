using Microsoft.AspNetCore.Mvc;
using NewsWeb.AdminDashboard.ViewModels;
using NewsWeb.Models;
using NewsWeb.Repositories;

namespace NewsWeb.AdminDashboard.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryInterface categoryinter;

        public CategoryController(ICategoryInterface category)
        {
            this.categoryinter = categoryinter;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await categoryinter.GetCategoriesAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Add(Category category)
        {
            Category category1 = new Category()
            {
                Id = Guid.NewGuid(),
                Name = category.Name
            };
            await categoryinter.AddCategoryAsync(category1);
            return RedirectToAction("index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var item = await categoryinter.GetCategoryAsync(id);
            return View((CategoryViewModel)item);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CategoryViewModel category)
        {
            await categoryinter.UpdateCategoryAsync((Category)category);
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            categoryinter.DeleteCategoryAsync(id);
            return RedirectToAction("index");
        }
    }
}
