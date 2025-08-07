using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1_MVC.Models;
using WebApplication1_MVC.Models.Db;

namespace WebApplication1_MVC.Controllers
{
    public class FeedbackController : Controller
    {
        /// <summary>
        ///  Метод, возвращающий страницу с отзывами
        /// </summary>
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// Метод для Ajax-запросов
        /// </summary>
        [HttpPost]
        public IActionResult Add(Feedback feedback)
        {
            return StatusCode(200, $"{feedback.From}, спасибо за отзыв!");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
