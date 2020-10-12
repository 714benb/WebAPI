using System.Threading.Tasks;
using System.Collections.Generic;
using WebAPI.API.Domain.Models;
using WebAPI.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.API.Domain.Repositories
{
    public class XEntityRepository: BaseRepository, IXEntityRepository
    {

        public XEntityRepository(AppDbContext context):base(context){}

        public async Task<IEnumerable<XEntity>> ListAsync()
        {
            return await _context.XEntities.ToListAsync();
        }
        public async Task AddAsync(XEntity xEntity)
        {
            await _context.XEntities.AddAsync(xEntity);
        }
        public async Task<XEntity> FindByIdAsync(int id)
        {
            return await _context.XEntities.FindAsync(id);
        }

        public void Update(XEntity xEntity)
        {
            _context.XEntities.Update(xEntity);
        }

        public XEntity Remove(XEntity xEntity)
        {
            _context.XEntities.Remove(xEntity);
            return xEntity;

        
        }
    }

    
}