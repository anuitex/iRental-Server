using iRental.Domain.Entities.User;
using System.Threading.Tasks;

namespace iRental.BusinessLogicLayer.Interfaces.Repositories
{
    public interface IUserFavoriteRepository : IBaseRepository<UserFavoritesEntity>
    {
        Task<UserFavoritesEntity> FindByUserIdAsync(string userId);
        Task<bool> IsAdvertInFavorites(string userId, string advertId);
    }
}
