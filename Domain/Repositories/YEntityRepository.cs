using System.Threading.Tasks;
using System.Collections.Generic;
using Supermarket.API.Domain.Models;
using Supermarket.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Supermarket.API.Domain.Repositories
{
    public class YEntityRepository: BaseRepository, IYEntityRepository
    {

        public YEntityRepository(AppDbContext context):base(context){}

        public async Task<IEnumerable<YEntity>> ListAsync()
        {
            return await _context.YEntities.ToListAsync();
        }
        public async Task AddAsync(YEntity yEntity)
        {
            await _context.YEntities.AddAsync(yEntity);
        }
        public async Task<YEntity> FindByIdAsync(int id)
        {
            return await _context.YEntities.FindAsync(id);
        }

        public void Update(YEntity yEntity)
        {
            _context.YEntities.Update(yEntity);
        }

        public YEntity Remove(YEntity yEntity)
        {
            _context.YEntities.Remove(yEntity);
            return yEntity;

        
        }
    }

    
}