﻿using Google.Cloud.Firestore;
using System.Collections.Generic;

namespace iRental.Domain.Entities.User
{
    [FirestoreData]
    public class UserSaveListEntity : BaseEntity
    {
        [FirestoreProperty]
        public string Name { get; set; }
        [FirestoreProperty]
        public string UserId { get; set; }
        [FirestoreProperty]
        public IEnumerable<string> AdvertIds { get; set; }

        public UserSaveListEntity()
        {
            AdvertIds = new List<string>();
        }
    }
}
