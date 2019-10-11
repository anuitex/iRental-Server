using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Text;

namespace iRental.Domain.FirestoreConverters
{
    public sealed class EnumNameConverter<T> : IFirestoreConverter<T>
    {
        public T FromFirestore(object value)
        {
            Type type = value.GetType();
            return (T) value;
        }

        public object ToFirestore(T value)
        {
            throw new NotImplementedException();
        }
    }
}
