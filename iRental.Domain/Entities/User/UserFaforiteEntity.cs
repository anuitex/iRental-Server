using Google.Cloud.Firestore;

namespace iRental.Domain.Entities.User
{
    [FirestoreData]
    public class UserFaforiteEntity : BaseEntity
    {
        [FirestoreProperty]
        public string UserId { get; set; }
        [FirestoreProperty]
        public string[] AdvertIds { get; set; }
    }
}
