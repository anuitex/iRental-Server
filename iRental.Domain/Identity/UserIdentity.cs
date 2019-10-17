﻿using Google.Cloud.Firestore;
using iRental.Domain.Entities;
using System;
using System.Collections.Generic;

namespace iRental.Domain.Identity
{
    public abstract class UserIdentity : IEntity
    {
        [FirestoreDocumentId]
        public string Id { get; set; }
        [FirestoreProperty]
        public string Login { get; set; }
        [FirestoreProperty]
        public string NormalizedLogin { get; set; }
        [FirestoreProperty]
        public string Email { get; set; }
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
        [FirestoreProperty]
        public DateTimeOffset CreatedAt { get; set; }

        public UserIdentity()
        {
            Id = Guid.NewGuid().ToString();
            CreatedAt = DateTime.UtcNow;
            Roles = new List<string>();
        }
    }
}
