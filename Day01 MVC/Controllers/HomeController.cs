using Day01_MVC.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace Day01_MVC.Controllers
{
    //each method in controller has special type(a class for this specific type)
    //the generalization that has all these types is called IActionResult
    //helper method--> solution for the redundancy problem 
    public class HomeController : Controller       //a new instance of HomeController is created with each request and disposed after sending the response
                                                   //controller inherites from ControllerBase
                                                   //ControllerBase has request/response configurations inside
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public ViewResult view()
        {
            return View();
        }

        public ContentResult showMsg()
        {
            ContentResult content = new ContentResult();
            content.Content = "Hello!!";
            return content;
        }

        public IActionResult mix(int x)          //   home/mix?x=1  (or any number)
        {
            if (x % 2 == 0)
                return View("view1");        //view1 is in Views
            else
                return Content("Hi from Content");
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
