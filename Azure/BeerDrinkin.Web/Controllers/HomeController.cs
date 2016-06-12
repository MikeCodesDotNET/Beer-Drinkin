using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace BeerDrinkin.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Features()
        {
            ViewData["Message"] = "Your features page.";

            return View();
        }

        public IActionResult Beers()
        {
            ViewData["Message"] = "Your beers page.";

            return View("~/Views/Beers/Index.cshtml");
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult LogIn()
        {
            ViewData["Message"] = "Your login page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
