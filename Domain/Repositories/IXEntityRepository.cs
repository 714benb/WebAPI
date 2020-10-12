using System.Threading.Tasks;
using System.Collections.Generic;
using WebAPI.API.Domain.Models;

namespace WebAPI.API.Domain.Repositories
{
    public interface IXEntityRepository
    {
        Task<IEnumerable<XEntity>> ListAsync();
        Task AddAsync(XEntity xEntity);
        void Update(XEntity xEntity);
        Task<XEntity> FindByIdAsync(int id);

        XEntity Remove(XEntity xEntity);
    }

    
}