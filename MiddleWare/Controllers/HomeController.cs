using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiddleWare.Models;

namespace MiddleWare.Controllers
{
    public class HomeController : Controller
    {
        //GET: Process
        [HttpGet]
        public string List()
        {
            return "This is Process page";
        }
        [HttpGet("Index")]
        public IActionResult Index()
        {
            ViewBag.Welcome = "Welcome to My page";
            //    return View();
            return View();
        }
        [HttpGet("About")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
