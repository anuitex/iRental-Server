using iRental.BusinessLogicLayer.Interfaces.Repositories;
using iRental.Domain.Entities;
using iRental.Domain.Entities.User;

namespace iRental.BusinessLogicLayer.Interfaces
{
    public interface IUnitOfWork
    {
        IBaseRepository<AdvertEntity> Adverts { get; }
        IBaseRepository<PhotoEntity> Photos { get; }
        IBaseRepository<UserEntity> Users { get; }
    }
}
