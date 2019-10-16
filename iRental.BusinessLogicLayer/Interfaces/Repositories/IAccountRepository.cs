using iRental.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace iRental.BusinessLogicLayer.Interfaces.Repositories
{
    public interface IAccountRepository : IBaseRepository<UserEntity>
    {
    }
}
