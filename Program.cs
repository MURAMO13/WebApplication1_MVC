using Microsoft.EntityFrameworkCore; // Не забудь подключить для UseSqlServer
using WebApplication1_MVC.Interfaces;
using WebApplication1_MVC.Middlewares;
using WebApplication1_MVC.Models;
using WebApplication1_MVC.Repositories;

namespace WebApplication1_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Получаем строку подключения из конфигурации
            string? connection = builder.Configuration.GetConnectionString("DefaultConnection");

            // Регистрируем контекст базы данных
            builder.Services.AddDbContext<BlogContext>(options =>options.UseSqlServer(connection));

            // Добавляем поддержку контроллеров и представлений (MVC)
            builder.Services.AddControllersWithViews();
            // регистрация сервиса репозитория для взаимодействия с базой данных
            builder.Services.AddScoped<IBlogRepository, BlogRepository>();
            builder.Services.AddScoped<IRequestRepository, RequestRepository>();

            var app = builder.Build();

            // Конфигурация middleware
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // Подключаем логирование через middleware
            app.UseMiddleware<LoggingMiddleware>();

            app.UseRouting();

            app.UseAuthorization();

            // Настройка маршрутов
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
