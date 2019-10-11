using Google.Cloud.Firestore;
using iRental.Common.Enum;

namespace iRental.Domain.Entities
{
    public class AdvertEntity : BaseEntity
    {
        [FirestoreProperty]
        public string Title { get; set; }
        [FirestoreProperty]
        public Enums.AdvertSalesType SalesType { get; set; }
        [FirestoreProperty]
        public Enums.AdvertHouseType HouseType { get; set; }
        [FirestoreProperty]
        public string CurrencyName { get; set; }
        [FirestoreProperty]
        public float Price { get; set; }
        [FirestoreProperty]
        public GeoPoint GeoPosition { get; set; }
        [FirestoreProperty]
        public string Address { get; set; }
        [FirestoreProperty]
        public int CountBeds { get; set; }
        [FirestoreProperty]
        public int CountRooms { get; set; }
        [FirestoreProperty]
        public int CountBathrooms { get; set; }
        [FirestoreProperty]
        public Enums.AdvertComfort[] ComfortOptions { get; set; }
        [FirestoreProperty]
        public string MainPhotoId { get; set; }
        [FirestoreProperty]
        public string[] PhotoIds { get; set; }
        [FirestoreProperty]
        public string Description { get; set; }
        [FirestoreProperty]
        public string UserId { get; set; }
        [FirestoreProperty]
        public int Area { get; set; }
    }
}
