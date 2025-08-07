using Microsoft.AspNetCore.Mvc;
using WebApplication1_MVC.Models.Db;
using WebApplication1_MVC.Interfaces;

namespace WebApplication1_MVC.Controllers
{
    public class LogsController : Controller
    {
        private readonly BlogContext _context;

        public LogsController(BlogContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var requests = _context.Requests
                .OrderByDescending(r => r.Date)
                .ToList();

            return View(requests);
        }
    }
}
