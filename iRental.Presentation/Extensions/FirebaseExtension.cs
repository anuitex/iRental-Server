using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using iRental.Common.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iRental.Presentation.Extensions
{
    public static class FirebaseExtension
    {
        public static void AddFirestore(this IServiceCollection services, IOptions<FirestoreOptions> firestoreOptions)
        {
            services.AddTransient<FirestoreDb>(_ =>
            {
                var clientBuilder = new FirestoreClientBuilder() { CredentialsPath = "./iRentalServiceAccount.json" };
                var client = clientBuilder.Build();
                var dbContext = FirestoreDb.Create(firestoreOptions.Value.ProjectId, client);
                return dbContext;
            });
        }

        public static void AddFileStore(this IServiceCollection services)
        {
            services.AddSingleton<GoogleCredential>(_ => GoogleCredential.FromFile($"./iRentalServiceAccount.json"));
        }
    }
}
