using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;

namespace VisionistPortal.Content.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string content = System.IO.File.ReadAllText("./content/Index.html");
            return base.Content(content, new MediaTypeHeaderValue("text/html"));
        }
    }
}
