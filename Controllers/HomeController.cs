using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CRUDelicious.Models;
using CRUDelicious.Contexts;

namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dBContext;
        public HomeController(MyContext context)
        {
            dBContext = context;
        }
        public IActionResult Index()
        {
            List<Dishes> dishes = dBContext.Dish.OrderByDescending(dishes => dishes.CreatedAt).ToList();
            return View(dishes);
        }

        [HttpPost("process")]
        public IActionResult Process(Dishes newbie)
        {
            if(ModelState.IsValid)
            {
                dBContext.Dish.Add(newbie);
                dBContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Add");
            }
        }
        [HttpGet("add")]
        public IActionResult Add()
        {
            return View("Add");
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet("/show/{dishId}")]
        public IActionResult Show(int dishId)
        {
            Dishes Show = dBContext.Dish.FirstOrDefault(l => l.DishId == dishId);
            return View(Show);
        }
        [HttpGet("/edit/{dishId}")]
        public IActionResult Edit(int dishId)
        {
            Dishes Edit = dBContext.Dish.FirstOrDefault(l => l.DishId == dishId);
            return View(Edit);
        }

        [HttpPost("update")]
        public IActionResult Update(Dishes update)
        {
            if(ModelState.IsValid)
            {
                Dishes lToUpdate = dBContext.Dish.FirstOrDefault(l => l.DishId == update.DishId);
                Console.WriteLine(lToUpdate);
                Console.WriteLine("*******************************");
                lToUpdate.Name = update.Name;
                lToUpdate.Chef = update.Chef;
                lToUpdate.Calories = update.Calories;
                lToUpdate.Tastiness = update.Tastiness;
                lToUpdate.Description = update.Description;
                lToUpdate.UpdatedAt = DateTime.Now;
                dBContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Edit",update);
            }
        }
        [HttpGet("destroy/{dishId}")]
        public IActionResult Destroy(int dishId)
        {
            Dishes delete= dBContext.Dish.FirstOrDefault(l => l.DishId == dishId);
            dBContext.Dish.Remove(delete);
            dBContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
