using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MiddleWare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class vivekController : Controller
    {
        [HttpGet("index")]
        public IActionResult Index()
        {
             ViewBag.Welcome = "Hi my name is vivek.Welcome to My Page, Thanks For Visiting";
            TempData["Data"] = "I am from Index action vivek";
            return View();

        }

        [HttpGet("index1")]
        public IActionResult Index1()
        {
            ViewBag.Data = TempData["Data"];
            TempData.Keep("Data");

            return View();
        }
        [HttpGet("index2")]
        public IActionResult Index2()
        {
           
            //ViewBag.Data = TempData["Data"];
            //TempData["mykey"] = "Welcome";
            //TempData.Keep("mykey");
            return View();
        }
        public IActionResult Index3()
        {
            ViewBag.Data = TempData["Data"];


            return View();
        }


        [HttpGet("v")]
        public IActionResult v(string name)
        {
            ViewData["name"] = "vivek";
            return View();
            //return "my favourite fruit is pineapple" + name;

        }

      [HttpGet("List")]
      //[HttpGet,ActionName("List")]
        public string List()
        {
            return "This is Process page. made by vivek jaiswal";

        }
        [HttpGet("fruit")]
        public string fruit()
        {
            return "my favourite fruit is pineapple";

        }
       
        [HttpGet("v1")]
        public string v(string name, string last)
        {
            return "my favourite fruit is pineapple" + name + last;

        }

        // [HttpPost("qwerty")]
        [HttpPost, ActionName("qwerty")]
        public string qwerty(string name)
        {
            return "This is Process page for" + name;
        }

        [HttpGet("fullname")]
        public string name(string name, string last)
        {
            return "My full name is " + name + "\t" + last;

        }
      
    }
  


}
