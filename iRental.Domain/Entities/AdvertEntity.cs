using Google.Cloud.Firestore;
using iRental.Common.Enum;

namespace iRental.Domain.Entities
{
    public class AdvertEntity : BaseEntity
    {
        [FirestoreProperty]
        public string Name { get; set; }
        [FirestoreProperty]
        public Enums.AdvertSalesType AdvertType { get; set; }
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
        public Enums.AdvertComfort[] ComfortOptions { get; set; }
        [FirestoreProperty]
        public string[] PhotoIds { get; set; }
        [FirestoreProperty]
        public string Description { get; set; }
        [FirestoreProperty]
        public string UserId { get; set; }
    }
}
