using Google.Cloud.Firestore;

namespace iRental.Domain.Entities
{
    [FirestoreData]
    public class PhotoEntity : BaseEntity
    {
        [FirestoreProperty]
        public string Url { get; set; }
        [FirestoreProperty]
        public string BucketName { get; set; }
    }
}
