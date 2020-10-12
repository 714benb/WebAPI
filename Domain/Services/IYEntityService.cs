using System.Threading.Tasks;
using System.Collections.Generic;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services.Communication;


namespace Supermarket.API.Domain.Services
{
    public interface IYEntitieservice
    {
        Task<IEnumerable<YEntity>> ListAsync();
        Task<YEntityResponse> SaveAsync(YEntity yEntity);
        Task<YEntityResponse> UpdateAsync(int id, YEntity yEntity);
        Task<YEntityResponse> FindByIdAsync(int id);
        Task<YEntityResponse> DeleteAsync(int id);
    }
}