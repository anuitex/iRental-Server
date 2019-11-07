using iRental.Domain.Entities.Base;
using iRental.Domain.Repositories.Base;
using iRental.Infrastructure.Configurations.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iRental.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IBaseEntity
    {
        protected readonly ApplicationContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task DeleteAsync(long id)
        {
            if (id.Equals(default(long)))
            {
                throw new ArgumentNullException();
            }

            TEntity item = await _dbSet.FindAsync(id);

            if (item is null)
            {
                throw new NullReferenceException();
            }

            EntityEntry dbEntry = _dbSet.Remove(item);

            if (dbEntry.State == EntityState.Deleted)
            {
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(TEntity item)
        {
            if (item is null)
            {
                throw new NullReferenceException();
            }

            EntityEntry dbEntry = _dbSet.Remove(item);

            if (dbEntry.State == EntityState.Deleted)
            {
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteRangeAsync(IEnumerable<long> ids)
        {
            if (!ids.Any())
            {
                throw new Exception();
            }

            IQueryable<TEntity> items = _dbSet.Where(item => ids.Contains(item.Id));

            _dbSet.RemoveRange(items);

            await _context.SaveChangesAsync();

        }

        public async Task DeleteRangeAsync(IEnumerable<TEntity> items)
        {
            if (!items.Any())
            {
                throw new Exception();
            }

            _dbSet.RemoveRange(items);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(IEnumerable<long> ids)
        {
            if (!ids.Any())
            {
                throw new Exception();
            }

            IEnumerable<TEntity> result = await _dbSet.Where(item => ids.Contains(item.Id)).ToListAsync();

            return result;
        }

        public Task<IEnumerable<TEntity>> GetAllAsync(IEnumerable<Guid> guids)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> GetSingleAsync(long id)
        {
            if (!Equals(id, default(long)))
            {
                throw new Exception();
            }

            TEntity result = await _dbSet.FirstOrDefaultAsync(item => item.Id == id);

            return result;
        }

        public Task<TEntity> GetSingleAsync(Guid guid)
        {
            throw new NotImplementedException();
        }

        public async Task<long> InsertAsync(TEntity item)
        {
            if (item is null)
            {
                throw new ArgumentNullException();
            }

            await _dbSet.AddAsync(item);

            return item.Id;
        }

        public async Task InsertRangeAsync(IEnumerable<TEntity> items)
        {
            if (!items.Any())
            {
                throw new ArgumentNullException();
            }

            await _dbSet.AddRangeAsync(items);
        }

        public async Task UpdateAsync(TEntity item)
        {
            if (item is null)
            {
                return;
            }

            _dbSet.Update(item);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateRangeAsync(IEnumerable<TEntity> items)
        {
            if (items is null || !items.Any())
            {
                throw new ArgumentNullException();
            }

            _dbSet.UpdateRange(items);

            await _context.SaveChangesAsync();
        }
    }
}
