using Google.Cloud.Firestore;
using iRental.BusinessLogicLayer.Interfaces.Repositories;
using iRental.Common.Constant;
using iRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iRental.Repository.Firestore.Repositories
{
    public class AdvertRepository : BaseRepository<AdvertEntity>, IAdvertRepository
    {
        public AdvertRepository(FirestoreDb dbContext) : base(dbContext, Constants.Collections.Advert)
        {
        }

        public async Task<IEnumerable<AdvertEntity>> GetAllWithoutUserAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("advertId");
            }

            QuerySnapshot allItemsQuerySnapshot = await _dbContext.Collection(_collectionName).GetSnapshotAsync();

            List<AdvertEntity> itemsResult = new List<AdvertEntity>();
            foreach (DocumentSnapshot documentSnapshot in allItemsQuerySnapshot.Documents)
            {
                var advertEntity = documentSnapshot.ConvertTo<AdvertEntity>();
                if (!advertEntity.UserId.Equals(userId))
                {
                    itemsResult.Add(advertEntity);
                }
            }
            return itemsResult;
        }

        public async Task<IEnumerable<AdvertEntity>> GetAllWithUserAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("advertId");
            }

            QuerySnapshot allItemsQuerySnapshot = await _dbContext.Collection(_collectionName)
                .WhereEqualTo(nameof(AdvertEntity.UserId), userId)
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
