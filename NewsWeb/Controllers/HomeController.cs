using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace NewsWeb.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
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

        public IActionResult Categori()
        {
            return View();

        }

        public IActionResult Contact()
        {
            return View();

        }

        public IActionResult Details()
        {
            return View();

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