using Google.Cloud.Firestore;
using System;

namespace iRental.Firestore.Identity.Identities
{
    [FirestoreData]
    public class RoleIdentity
    {
        [FirestoreDocumentId]
        public string Id { get; set; }
        [FirestoreProperty]
        public string Name { get; set; }
        [FirestoreProperty]
        public string NormalizedName { get; set; }

        public RoleIdentity()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
