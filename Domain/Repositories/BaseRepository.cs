using WebAPI.API.Persistence.Contexts;

namespace WebAPI.API.Domain.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;    
        }
    }
}