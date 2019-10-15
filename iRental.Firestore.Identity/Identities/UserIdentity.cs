﻿using Google.Cloud.Firestore;
using System.Collections.Generic;

namespace iRental.Firestore.Identity.Identities
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
        public string Email { get; set; }
        [FirestoreProperty]
        public string NormalizedEmail { get; set; }
        [FirestoreProperty]
        public bool EmailConfirmed { get; set; }
        [FirestoreProperty]
        public string PasswordHash { get; set; }
        [FirestoreProperty]
        public string PhoneNumber { get; set; }
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
