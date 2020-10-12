using System.Threading.Tasks;
using System.Collections.Generic;
using WebAPI.API.Domain.Models;
using WebAPI.API.Domain.Services.Communication;


namespace WebAPI.API.Domain.Services
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