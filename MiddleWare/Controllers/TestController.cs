using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace MiddleWare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("List")]
        public string List()
        {
            return "This is Process page. made by vivek jaiswal";
        
        }
        [HttpGet("fruit")]
        public string fruit()
        {
            return "my favourite fruit is pineapple";

        }
        [HttpGet("v")]
        public string v(string name)
        {
            return "my favourite fruit is pineapple" +name;
           // return View();
        }
        [HttpGet("v1")]
        public string v(string name,string last)
        {
            return "my favourite fruit is pineapple" + name+last;
          //  return View();
        }

        // [HttpPost("qwerty")]
        [HttpPost("qwerty")]
        public string qwerty(string name)
        {
            return "This is Process page for" + name;
        }

    }
}