using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace bootcamp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string location)
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
