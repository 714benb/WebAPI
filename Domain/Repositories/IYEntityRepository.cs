using System.Threading.Tasks;
using System.Collections.Generic;
using WebAPI.API.Domain.Models;

namespace WebAPI.API.Domain.Repositories
{
    public interface IYEntityRepository
    {
        Task<IEnumerable<YEntity>> ListAsync();
        Task AddAsync(YEntity yEntity);
        void Update(YEntity yEntity);
        Task<YEntity> FindByIdAsync(int id);

        YEntity Remove(YEntity yEntity);
    }

    
}