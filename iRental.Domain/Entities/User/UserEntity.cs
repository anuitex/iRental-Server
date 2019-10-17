using Google.Cloud.Firestore;
using iRental.Common.Enum;
using iRental.Domain.Identity;
using System;
using System.Collections.Generic;

namespace iRental.Domain.Entities.User
{
    [FirestoreData]
    public class UserEntity : UserIdentity
    {
        [FirestoreProperty]
        public string FirstName { get; set; }
        [FirestoreProperty]
        public string LastName { get; set; }
        [FirestoreProperty]
        public DateTime Birthday { get; set; }
        [FirestoreProperty]
        public string PhoneNumber { get; set; }
        [FirestoreProperty]
        public string PasswordHash { get; set; }
        [FirestoreProperty]
        public Enums.UserGender GenderType { get; set; }
        [FirestoreProperty]
        public string Country { get; set; }
        [FirestoreProperty]
        public string City { get; set; }
        [FirestoreProperty]
        public string Address { get; set; }
        [FirestoreProperty]
        public float Rating { get; set; }
        [FirestoreProperty]
        public int CountRated { get; set; }
        [FirestoreProperty]
        public List<string> AdvertFavoritesIds { get; set; }
        [FirestoreProperty]
        public PhotoEntity Avatar { get; set; }

        public UserEntity()
        {
            AdvertFavoritesIds = new List<string>();
        }
    }
}
