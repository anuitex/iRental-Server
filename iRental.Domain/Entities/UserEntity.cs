using Google.Cloud.Firestore;
using iRental.Domain.Enum.User;
using System;

namespace iRental.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        [FirestoreProperty]
        public DateTime Birthday { get; set; }
        [FirestoreProperty]
        public string FirstName { get; set; }
        [FirestoreProperty]
        public string LastName { get; set; }
        [FirestoreProperty]
        public string PhoneNumber { get; set; }
        [FirestoreProperty]
        public string Email { get; set; }
        [FirestoreProperty]
        public string PasswordHash { get; set; }
        [FirestoreProperty]
        public string AvatarId { get; set; }
        [FirestoreProperty]
        public Enums.UserGender GenderType { get; set; }
        [FirestoreProperty]
        public string Country { get; set; }
        [FirestoreProperty]
        public string City { get; set; }
        [FirestoreProperty]
        public string Address { get; set; }
        [FirestoreProperty]
        public string NumberHouse { get; set; }
    }
}
