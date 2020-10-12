using System.Threading.Tasks;
using System.Collections.Generic;
using WebAPI.API.Domain.Models;
using WebAPI.API.Domain.Services.Communication;


namespace WebAPI.API.Domain.Services
{
    public interface IXEntityService
    {
        Task<IEnumerable<XEntity>> ListAsync();
        Task<XEntityResponse> SaveAsync(XEntity xEntity);
        Task<XEntityResponse> UpdateAsync(int id, XEntity xEntity);
        Task<XEntityResponse> FindByIdAsync(int id);
        Task<XEntityResponse> DeleteAsync(int id);
    }
}