using Google.Cloud.Firestore;

namespace iRental.Domain.Entities
{
    public class AdvertEntity : BaseEntity
    {
        [FirestoreProperty]
        public string Name { get; set; }
        [FirestoreProperty]
        public Enum.Enums.AdvertType AdvertType { get; set; }
        [FirestoreProperty]
        public string CurrencyId { get; set; }
        [FirestoreProperty]
        public int Price { get; set; }
        [FirestoreProperty]
        public GeoPoint GeoPosition { get; set; }
        [FirestoreProperty]
        public int CountBeds { get; set; }
        [FirestoreProperty]
        public int CountRooms { get; set; }
        [FirestoreProperty]
        public int CountBathrooms { get; set; }
        [FirestoreProperty]
        public Enum.Enums.AdvertComfort[] ComfortOptions { get; set; }
        [FirestoreProperty]
        public string[] PhotoIds { get; set; }
        [FirestoreProperty]
        public string Description { get; set; }
        [FirestoreProperty]
        public string UserId { get; set; }
    }
}
