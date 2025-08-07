using Microsoft.AspNetCore.Mvc;
using MvcStartApp.Models.Db;
using WebApplication1_MVC.Interfaces;
using WebApplication1_MVC.Models.Db;

namespace WebApplication1_MVC.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Метод InvokeAsync с внедрением BlogContext
        /// </summary>
        public async Task InvokeAsync(HttpContext context, IRequestRepository repo )
        {
            // Лог в консоль
            Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");

            var request = new Request
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Url = $"{context.Request.Scheme}://{context.Request.Host}{context.Request.Path}"
            };

            await repo.SaveRequestAsync(request);
            await _next(context);
        }
    }
}
