using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WorkWithMe.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public record Person(string Name, string LastName);
        private readonly ILogger<HomeController> _logger;
        Person _person;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(JsonResult res)
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetUser([FromBody] Person person)
        {
            string responseText = $"Name: {person.Name} LastName: {person.LastName}";
            return Json(new { text = responseText });
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}