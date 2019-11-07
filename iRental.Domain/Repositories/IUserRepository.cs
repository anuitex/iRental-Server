using iRental.Domain.Entities.User;
using iRental.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iRental.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<IApplicationUser>> QueryAsync(BaseQuery query);
    }
}
