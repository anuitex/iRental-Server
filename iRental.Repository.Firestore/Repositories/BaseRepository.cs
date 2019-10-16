﻿using Google.Cloud.Firestore;
using iRental.BusinessLogicLayer.Interfaces.Repositories;
using iRental.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iRental.Repository.Firestore.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : IEntity
    {
        protected readonly FirestoreDb _dbContext;
        protected readonly string _collectionName;

        public BaseRepository(FirestoreDb dbContext, string collectionName)
        {
            _dbContext = dbContext;
            _collectionName = collectionName;
        }

        public virtual async Task CreateAsync(T model)
        {
            DocumentReference docReference = _dbContext.Collection(_collectionName).Document(model.Id);
            await docReference.CreateAsync(model);
        }

        public virtual async Task DeleteByIdAsync(string id)
        {
            DocumentReference docReference = _dbContext.Collection(_collectionName).Document(id);
            await docReference.DeleteAsync();
        }

        public virtual async Task<T> FindByIdAsync(string id)
        {
            DocumentReference docReference = _dbContext.Collection(_collectionName).Document(id);
            DocumentSnapshot snapshot = await docReference.GetSnapshotAsync();
            var result = snapshot.ConvertTo<T>();
            return result;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            QuerySnapshot allItemsQuerySnapshot = await _dbContext.Collection(_collectionName).GetSnapshotAsync();
            List<T> itemsResult = new List<T>();
            foreach (DocumentSnapshot documentSnapshot in allItemsQuerySnapshot.Documents)
            {
                itemsResult.Add(documentSnapshot.ConvertTo<T>());
            }
            return itemsResult;
        }

        public virtual async Task UpdateAsync(T model)
        {
            DocumentReference docReference = _dbContext.Collection(_collectionName).Document(model.Id);
            await docReference.SetAsync(model);
        }
    }
}
