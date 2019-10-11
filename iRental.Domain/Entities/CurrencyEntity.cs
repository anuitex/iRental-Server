using Google.Cloud.Firestore;

namespace iRental.Domain.Entities
{
    public class CurrencyEntity : BaseEntity
    {
        [FirestoreProperty]
        public string Name { get; set; }
        [FirestoreProperty]
        public double Price { get; set; }
    }
}
