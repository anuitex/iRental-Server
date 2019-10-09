﻿using Google.Cloud.Firestore;

namespace iRental.Domain.Entities
{
    public class PhotoEntity : BaseEntity
    {
        [FirestoreProperty]
        public string Name { get; set; }
        [FirestoreProperty]
        public string Url { get; set; }
    }
}
