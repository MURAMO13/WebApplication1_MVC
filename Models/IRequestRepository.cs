using MvcStartApp.Models.Db;
using WebApplication1_MVC.Models.Db;

namespace WebApplication1_MVC.Interfaces
{
    public interface IRequestRepository
    {
        Task SaveRequestAsync(Request request);
    }
}
