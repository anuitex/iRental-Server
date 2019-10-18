using Google.Cloud.Firestore;
using System.Collections.Generic;

namespace iRental.Domain.Entities.User
{
    [FirestoreData]
    public class UserFavoritesEntity : BaseEntity
    {
        public string UserId { get; set; }
        public IEnumerable<string> AdvertIds { get; set; }

        public UserFavoritesEntity()
        {
            AdvertIds = new List<string>();
        }
    }
}
