using Google.Cloud.Firestore;
using System;

namespace iRental.Domain.Entities
{
    public abstract class BaseEntity : IEntity
    {
        [FirestoreDocumentId]
        public string Id { get; set; }
        [FirestoreProperty]
        public DateTimeOffset CreatedAt { get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid().ToString();
            //CreatedAt = new DateTimeOffset(DateTime.UtcNow);
            CreatedAt = DateTime.UtcNow;
        }
    }
}
