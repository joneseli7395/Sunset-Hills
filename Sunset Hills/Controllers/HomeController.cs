using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sunset_Hills.Models;

namespace Sunset_Hills.Controllers
{
    public class HomeController : Controller
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

        public IActionResult Solve()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Solve(int input1, int input2, int input3, int input4, int input5)
        {
            int[] inArray = new int[] { input1, input2, input3, input4, input5 };
            List<int> newArray = new List<int>();
            int count = 1;
            int currentMax = inArray[0];
            newArray.Add(currentMax);

            for (int i = 0; i < inArray.Length; i++)
            {
                if (inArray[i] > currentMax)
                {
                    count++;
                    newArray.Add(inArray[i]);
                    currentMax = inArray[i];
                }


            }

            ViewData["Output"] = ($"{count} buildings can see the sun with heights of [{string.Join(", ", newArray)}]");
            return View();
        }

        public IActionResult Code()
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
