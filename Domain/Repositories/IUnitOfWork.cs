using System.Threading.Tasks;

namespace WebAPI.API.Domain.Repositories
{
    public interface IUnitOfWork
    {
         Task CompleteAsync();
    }
}