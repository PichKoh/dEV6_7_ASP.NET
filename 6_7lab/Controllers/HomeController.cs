using _6_7lab.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Linq;

namespace _6_7lab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Product peperoniProduct = new Product("Peperoni", 25, 17.4);
        private Product hawaiianProduct = new Product("hawaiian", 27, 20.5);
        private Product chickenbbqProduct = new Product("chickenbbq", 20, 30);
        private Product margheritaProduct = new Product("margherita", 30, 50);

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Message = "";
            return View();
        }
        [HttpPost]
        public IActionResult Index(UserModel user)
        {
            ViewBag.Message = "";
            if (user.Age < 16)
            {
                ViewBag.Message = "Should be less than 16";
                return View();
            }
            return Redirect("/Home/Order");
        }
        [HttpGet]
        public IActionResult Order()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Submit()
        {
            return Redirect("/Home/Order");
        }

        [HttpPost]
        public IActionResult Submit(int pepperoni, int hawaiian, int chickenbbq, int margherita)
        {
            List<Product> products = new List<Product> { };

            if (pepperoni != 0)
            {
                for (int i = 0; i < pepperoni; i++)
                {
                    products.Add(peperoniProduct);
                }
            }
            if (hawaiian != 0)
            {
                for (int i = 0; i < hawaiian; i++)
                {
                    products.Add(hawaiianProduct);
                }
            }
            if (chickenbbq != 0)
            {
                for (int i = 0; i < chickenbbq; i++)
                {
                    products.Add(chickenbbqProduct);
                }
            }
            if (margherita != 0)
            {
                for (int i = 0; i < margherita; i++)
                {
                    products.Add(margheritaProduct);
                }
            }

            return View(products);
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