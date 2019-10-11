using Google.Cloud.Firestore;
using System;

namespace iRental.Domain.Entities
{
    public abstract class BaseEntity
    {
        [FirestoreDocumentId]
        public string Id { get; set; }
        [FirestoreProperty]
        public DateTime CreatedAt { get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid().ToString();
            CreatedAt = DateTime.UtcNow;
        }
    }
}
