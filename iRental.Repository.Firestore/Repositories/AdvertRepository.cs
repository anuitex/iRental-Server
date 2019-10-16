using Google.Cloud.Firestore;
using iRental.BusinessLogicLayer.Interfaces.Repositories;
using iRental.Common.Constant;
using iRental.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iRental.Repository.Firestore.Repositories
{
    public class AdvertRepository : BaseRepository<AdvertEntity>, IAdvertRepository
    {
        public AdvertRepository(FirestoreDb dbContext) : base(dbContext, Constants.Collections.Advert)
        {
        }

        public async Task<IEnumerable<AdvertEntity>> GetAllForUserAsync(string userId)
        {
            QuerySnapshot allItemsQuerySnapshot = await _dbContext.Collection(_collectionName)
                .WhereEqualTo("UserId", userId)
                .GetSnapshotAsync();

            List<AdvertEntity> itemsResult = new List<AdvertEntity>();
            foreach (DocumentSnapshot documentSnapshot in allItemsQuerySnapshot.Documents)
            {
                itemsResult.Add(documentSnapshot.ConvertTo<AdvertEntity>());
            }
            return itemsResult;
        }
    }
}
