using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WorkWithMe.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

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
        public JsonResult GetUser([FromBody] User user)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
                User? userHard = db.Users.FirstOrDefault(u => u.Name == user.Name);
                string responseText = "null";
                if (userHard != null)
                    responseText = JsonSerializer.Serialize(user);//$"Name: {userHard.Name} LastName: {userHard.LastName}";
                return Json(new { text = responseText });
            }
        }

        public List<User> GetUsers()
        {
            
            using (ApplicationContext db = new ApplicationContext())
            {
                string responseText = "null";
                List<User> users = new List<User>();
                foreach (var user in db.Users.Where(u => true))
                {
                    responseText += JsonSerializer.Serialize(user);
                    users.Add(user);
                }
                return users;
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}