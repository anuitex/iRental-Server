using iRental.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iRental.BusinessLogicLayer.Interfaces.Repositories
{
    public interface IUserSaveListRepository : IBaseRepository<UserSaveListEntity>
    {
        Task<bool> ContainsAdvert(string userId, string advertId);
    }
}
