using iRental.Domain.Entities;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iRental.BusinessLogicLayer.Interfaces.Repositories
{
    public interface IAdvertRepository : IBaseRepository<AdvertEntity>
    {
        Task<IEnumerable<AdvertEntity>> GetAllForUserAsync(string userId);
    }
}
