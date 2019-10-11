using Google.Cloud.Firestore;

namespace iRental.Domain.Entities.User
{
    [FirestoreData]
    public class UserSaveListEntity : BaseEntity
    {
        [FirestoreProperty]
        public string Name { get; set; }
    }
}
