using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiddleWare.Models;

namespace MiddleWare.Controllers
{
    public class vickyController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Welcome = "Hi my name is vivek.Welcome to My Page, Thanks For Visiting";
            ViewData["Message"] = "Hello MVC vicky!";
            ViewBag.welcome = ViewData["welcome"];
            TempData["mykey"] = "vicky index data";
            TempData.Keep("mykey");
            TempData.Peek("mykey");
            TempData["CurrTime"] = DateTime.Now;
            return View();

        }
        public IActionResult Index2()
        {

            // TempData.Keep("mykey");
            return View();
        }
        public IActionResult Index3()
        {
            //TempData.Keep("mykey");
            // ViewBag.Mykey = TempData["mykey"];
            return View();
        }

        public IActionResult GetStudentName()
        {
            //  TempData.Keep("mykey");
            // ViewBag.Mykey = TempData["mykey"];
            // return View();
            IList<string> student = new List<string>()
            { "vivek",
                "vicky",
                 "vishal",
                "vikas"
                    };

            ViewData["students"] = student;

            return View();

        }
        Student studentdetails = new Student()
        {
            StudentName = "vivek",
            StudentEmail = "vivek@gmail.com ",
            StudentPhoneNumber = "7383559109",
            StudentAddress = "valsad"
        };
        Student studentdetails1 = new Student()
        {
            StudentName = "vicky",
            StudentEmail = "vicky@gmail.com ",
            StudentPhoneNumber = "7383559109",
            StudentAddress = "Abrama"
        };
        Student studentdetails2 = new Student()
        {
            StudentName = "vishal",
            StudentEmail = "vishal@gmail.com ",
            StudentPhoneNumber = "7383559109",
            StudentAddress = "Ahmedabad"
        };

        public IActionResult Index4()
        {
            var abc = new List<Student>()
            {
                studentdetails, studentdetails1, studentdetails2
            };
            return View(abc);
        }

        public IActionResult Index5()
        {
            return View(studentdetails);

        }



        College college = new College()
        {

            CollegeName = "vivek Alpha college Enginnering",
            CollegeAddress = "Gandhinagar",
            CollegeEmail = "vivekcollege@gmail.com ",
            CollegePhoneNumber = "7383559109"
        };

        public IActionResult Index6()
        {
            var tapleModel = new Tuple<Student, College>(studentdetails, college);
            return View(tapleModel);
        }
        public IActionResult Index7()
        {

            return RedirectToAction("Index6");
        }
        [ActionName("HI")]
        public IActionResult Index8()
        {

            return View();
        }

    //  [AcceptVerbs(HttpVerbs.Post, HttpVerbs.Get)]
        public IActionResult Index9()
        {

            return View();
        }
        public IActionResult Index10()
        {

            return View("Vrazorpage");
        }
        public IActionResult Index11()
        {

            return View();
           
        }
        public IActionResult Index12()
        {

            return View();
        }
        public IActionResult Index13()
        {

            return View();
        }

    }
}
