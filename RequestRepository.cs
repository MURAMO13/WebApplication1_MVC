using WebApplication1_MVC.Models.Db;
using WebApplication1_MVC.Interfaces;
using MvcStartApp.Models.Db;

namespace WebApplication1_MVC.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly BlogContext _context;

        public RequestRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task SaveRequestAsync(Request request)
        {
            await _context.Requests.AddAsync(request);
            await _context.SaveChangesAsync();
        }
    }
}
