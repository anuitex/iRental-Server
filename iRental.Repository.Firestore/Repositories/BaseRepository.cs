using Google.Cloud.Firestore;
using iRental.BusinessLogicLayer.Interfaces.Repositories;
using iRental.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iRental.Repository.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected CollectionReference _collection;

        public BaseRepository(FirestoreDb dbContext, string collectionName)
        {
            _collection = dbContext.Collection(collectionName);
        }
        public async Task CreateAsync(T model)
        {
            DocumentReference docReference = _collection.Document(model.Id);
            await docReference.SetAsync(model);
        }

        public async Task DeleteByIdAsync(string id)
        {
            DocumentReference docReference = _collection.Document(id);
            await docReference.DeleteAsync();
        }

        public async Task<T> FindByIdAsync(string id)
        {
            DocumentReference docReference = _collection.Document(id);
            DocumentSnapshot snapshot = await docReference.GetSnapshotAsync();
            var result = snapshot.ConvertTo<T>();
            return result;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            Query collectionQuery = _collection;
            QuerySnapshot allItemsQuerySnapshot = await collectionQuery.GetSnapshotAsync();
            List<T> itemsResult = new List<T>();
            foreach (DocumentSnapshot documentSnapshot in allItemsQuerySnapshot.Documents)
            {
                itemsResult.Add(documentSnapshot.ConvertTo<T>());
            }
            return itemsResult;
        }

        public async Task UpdateAsync(T model)
        {
            DocumentReference docReference = _collection.Document(model.Id);
            await docReference.SetAsync(model);
        }
    }
}
