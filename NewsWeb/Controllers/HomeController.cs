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

    }
}