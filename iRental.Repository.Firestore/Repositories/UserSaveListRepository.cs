using Google.Cloud.Firestore;
using iRental.BusinessLogicLayer.Interfaces.Repositories;
using iRental.Common.Constant;
using iRental.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iRental.Repository.Firestore.Repositories
{
    public class UserSaveListRepository : BaseRepository<UserSaveListEntity>, IUserSaveListRepository
    {
        public UserSaveListRepository(FirestoreDb dbContext) : base(dbContext, Constants.Collections.UserSaveList)
        {
        }

        public async Task<bool> ContainsAdvert(string userId, string advertId)
        {
            var documentSnapshots = await _dbContext.Collection(_collectionName)
                .WhereEqualTo(nameof(UserSaveListEntity.UserId), userId)
                .WhereArrayContains(nameof(UserSaveListEntity.AdvertIds), advertId)
                .GetSnapshotAsync();

            return documentSnapshots.Documents.Count >= 1;
        }
    }
}
