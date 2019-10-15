using Google.Cloud.Firestore;
using System.Collections.Generic;

namespace iRental.Domain.Identities
{
    [FirestoreData]
    public class UserIdentity
    {
        [FirestoreDocumentId]
        public string UserId { get; set; }
        [FirestoreProperty]
        public string UserName { get; set; }
        [FirestoreProperty]
        public string NormalizedUserName { get; set; }
        [FirestoreProperty]
        public string NormalizedEmail { get; set; }
        [FirestoreProperty]
        public bool EmailConfirmed { get; set; }
        [FirestoreProperty]
        public bool PhoneNumberConfirmed { get; set; }
        [FirestoreProperty]
        public bool TwoFactorEnabled { get; set; }
        [FirestoreProperty]
        public List<string> Roles { get; set; }

        public UserIdentity()
        {
            Roles = new List<string>();
        }
    }
}
