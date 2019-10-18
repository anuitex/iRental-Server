using Google.Cloud.Firestore;
using iRental.BusinessLogicLayer.Interfaces.Repositories;
using iRental.Common.Constant;
using iRental.Domain.Entities.User;
using System.Linq;
using System.Threading.Tasks;

namespace iRental.Repository.Firestore.Repositories
{
    public class UserFavoriteRepository : BaseRepository<UserFavorites>, IUserFavoriteRepository
    {
        public UserFavoriteRepository(FirestoreDb dbContext) : base(dbContext, Constants.Collections.UserFavorite)
        {
        }

        public async Task<UserFavorites> FindByUserIdAsync(string userId)
        {
            var querySnapshot = await _dbContext.Collection(_collectionName).WhereEqualTo("UserId", userId).GetSnapshotAsync();
            var docSnapshot = querySnapshot.Documents.FirstOrDefault();
            if (docSnapshot == null)
            {
                return null;
            }

            var userFavorite = docSnapshot.ConvertTo<UserFavorites>();
            return userFavorite;
        }

        public async Task<bool> IsAdvertInFavorites(string userId, string advertId)
        {
            var querySnapshot = await _dbContext.Collection(_collectionName).WhereEqualTo("UserId", userId).GetSnapshotAsync();
            var docSnapshot = querySnapshot.Documents.FirstOrDefault();
            if (docSnapshot == null)
            {
                return false;
            }

            var userFavorite = docSnapshot.ConvertTo<UserFavorites>();
            bool isFavorite = userFavorite.AdvertIds.Contains(advertId);
            return isFavorite;
        }
    }
}
