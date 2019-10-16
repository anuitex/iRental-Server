using iRental.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iRental.BusinessLogicLayer.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : IEntity
    {
        Task CreateAsync(T model);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> FindByIdAsync(string id);
        Task DeleteByIdAsync(string id);
        Task UpdateAsync(T model);
    }
}
