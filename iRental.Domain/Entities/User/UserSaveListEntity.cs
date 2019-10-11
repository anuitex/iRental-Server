using Google.Cloud.Firestore;

namespace iRental.Domain.Entities.User
{
    public class UserSaveListEntity : BaseEntity
    {
        [FirestoreProperty]
        public string Name { get; set; }
    }
}
