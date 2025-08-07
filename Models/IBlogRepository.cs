using MvcStartApp.Models.Db;
using WebApplication1_MVC.Models.Db;

namespace WebApplication1_MVC.Models
{
    public interface IBlogRepository
    {
        Task AddUser(User user);

        Task<User[]> GetUsers();// Получить всех пользователей из базы данных

    }
}
