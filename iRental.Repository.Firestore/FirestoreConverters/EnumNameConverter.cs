using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Text;

namespace iRental.Repository.Firestore.FirestoreConverters
{
    public sealed class EnumNameConverter<T> : IFirestoreConverter<T> where T : struct, Enum
    {
        public T FromFirestore(object value)
        {
            throw new NotImplementedException();
        }

        public object ToFirestore(T value)
        {
            throw new NotImplementedException();
        }
    }
}
