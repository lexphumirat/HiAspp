using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HiAspp.Models;

namespace HiAspp.Controllers
{
    public class HelloController : Controller
    {
     [HttpGet("")]
     public IActionResult Index()
     {
         return View();
     }   

    [HttpGet("info")]
    public IActionResult Info()
    {
        List<string> fruit = new List<string>()
        {
            "Apples",
            "Oranges",
            "Mangoes"
        };

        List<Dictionary<string, object>> users = DbConnector.Query("select * from users");

        ViewBag.Users = users;

        ViewBag.Fruit = fruit;
        return View();
    }

    [HttpPost("create")]
    public IActionResult Create(Friend friend)
        {
            string query = $@"INSERT INTO users (first_name, last_name, created_at) VALUES ('{friend.first_name}', '{friend.last_name}', NOW())";
            DbConnector.Execute(query);
            
            return RedirectToAction("Info");
        }
    }
}