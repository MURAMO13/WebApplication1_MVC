using Microsoft.AspNetCore.Mvc;
using WebApplication1_MVC.Models;
using WebApplication1_MVC.Models.Db;

namespace WebApplication1_MVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly IBlogRepository _repo;

        public UsersController(IBlogRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            var authors = await _repo.GetUsers();
            return View(authors);
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }


        //[HttpPost]
        //public async Task<IActionResult> Register(User user)
        //{
        //    user.JoinDate = DateTime.Now;
        //    user.Id = Guid.NewGuid();

        //    await _repo.AddUser(user); // используем _repo, а не _context

        //    return Content($"Registration successful, {user.FirstName}");
        //}

        [HttpPost]
        public async Task<IActionResult> Register(User newUser)
        {
            await _repo.AddUser(newUser);
            return View(newUser);
        }
    }
}
