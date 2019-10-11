using Google.Cloud.Firestore;
using iRental.Common.Enum;
using iRental.Domain.FirestoreConverters;
using System.Collections.Generic;

namespace iRental.Domain.Entities
{
    [FirestoreData]
    public class AdvertEntity : BaseEntity
    {
        [FirestoreProperty]
        public string Title { get; set; }
        [FirestoreProperty]
        public Enums.AdvertSalesType SaleType { get; set; }
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
        [FirestoreProperty(ConverterType = typeof(EnumNameConverter<IEnumerable<Enums.AdvertComfort>>))]
        public List<Enums.AdvertComfort> ComfortOptions { get; set; }
        [FirestoreProperty]
        public string MainPhotoId { get; set; }
        [FirestoreProperty]
        public IEnumerable<string> PhotoIds { get; set; }
        [FirestoreProperty]
        public string Description { get; set; }
        [FirestoreProperty]
        public string UserId { get; set; }
        [FirestoreProperty]
        public int Area { get; set; }

        public AdvertEntity()
        {
            ComfortOptions = new List<Enums.AdvertComfort>();
            PhotoIds = new List<string>();
        }
    }
}
