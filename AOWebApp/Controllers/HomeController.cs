using AOWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace AOWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int?itemID, string itemName)
        {
            //throw new Exception("This is an error");
            ViewBag.itemID = itemID;
            ViewBag.itemName = itemName;
            var items = new List<Items>();
            return View(items);
        }

        public IActionResult Test(int? id, string text)
        {
            // get the id from the Request url
            //var id = Request.RouteValues["id"];

            // pass the id value to the view
            ViewBag.id = id;
            ViewBag.searchText = text;

            return View();
        }
        public IActionResult RazorTest(string name, int?id)
        {
            //throw new Exception("This is an error");

            ViewBag.id = id;
            ViewBag.name = name;
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
