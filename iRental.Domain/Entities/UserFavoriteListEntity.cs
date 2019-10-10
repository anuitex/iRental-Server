using Google.Cloud.Firestore;

namespace iRental.Domain.Entities
{
    public class UserFavoriteListEntity : BaseEntity
    {
        [FirestoreProperty]
        public string Name { get; set; }
        [FirestoreProperty]
        public string UserId { get; set; }
    }
}
