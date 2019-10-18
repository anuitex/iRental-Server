using Google.Cloud.Firestore;
using iRental.BusinessLogicLayer.Interfaces.Repositories;
using iRental.Common.Constant;
using iRental.Domain.Entities.User;
using System.Linq;
using System.Threading.Tasks;

namespace iRental.Repository.Firestore.Repositories
{
    public class UserFavoriteRepository : BaseRepository<UserFavoritesEntity>, IUserFavoriteRepository
    {
        public UserFavoriteRepository(FirestoreDb dbContext) : base(dbContext, Constants.Collections.UserFavorite)
        {
        }

        public async Task<UserFavoritesEntity> FindByUserIdAsync(string userId)
        {
            var querySnapshot = await _dbContext.Collection(_collectionName).WhereEqualTo(nameof(UserFavoritesEntity), userId).GetSnapshotAsync();
            var docSnapshot = querySnapshot.Documents.FirstOrDefault();
            if (docSnapshot == null)
            {
                return null;
            }

            var userFavorite = docSnapshot.ConvertTo<UserFavoritesEntity>();
            return userFavorite;
        }

        public async Task<bool> IsAdvertInFavorites(string userId, string advertId)
        {
            var querySnapshot = await _dbContext.Collection(_collectionName).WhereEqualTo(nameof(UserFavoritesEntity), userId).GetSnapshotAsync();
            var docSnapshot = querySnapshot.Documents.FirstOrDefault();
            if (docSnapshot == null)
            {
                return false;
            }

            var userFavorite = docSnapshot.ConvertTo<UserFavoritesEntity>();
            bool isFavorite = userFavorite.AdvertIds.Contains(advertId);
            return isFavorite;
        }
    }
}
