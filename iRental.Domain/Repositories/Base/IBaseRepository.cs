using iRental.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iRental.Domain.Repositories.Base
{
    public interface IBaseRepository<TEntity> where TEntity : IBaseEntity
    {
        Task<TEntity> GetSingleAsync(long id);
        Task<TEntity> GetSingleAsync(Guid guid);

        Task<IEnumerable<TEntity>> GetAllAsync(IEnumerable<long> ids);
        Task<IEnumerable<TEntity>> GetAllAsync(IEnumerable<Guid> guids);

        Task<long> InsertAsync(TEntity item);
        Task InsertRangeAsync(IEnumerable<TEntity> items);

        Task UpdateAsync(TEntity item);
        Task UpdateRangeAsync(IEnumerable<TEntity> items);

        Task DeleteAsync(long id);
        Task DeleteAsync(TEntity item);

        Task DeleteRangeAsync(IEnumerable<long> ids);
        Task DeleteRangeAsync(IEnumerable<TEntity> items);
    }
}
