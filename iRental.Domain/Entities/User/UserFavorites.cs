using Google.Cloud.Firestore;
using System.Collections.Generic;

namespace iRental.Domain.Entities.User
{
    [FirestoreData]
    public class UserFavorites : BaseEntity
    {
        public string UserId { get; set; }
        public IEnumerable<string> AdvertIds { get; set; }

        public UserFavorites()
        {
            AdvertIds = new List<string>();
        }
    }
}
