using Google.Cloud.Firestore.V1;

namespace iRental.Repository.Firestore.Test
{
    public static class SettingRepository
    {
        public const string ProjectId = "realestatetestapp-717da";
        public static FirestoreClient GetClient()
        {
            var clientBuilder = new FirestoreClientBuilder
            {
                CredentialsPath = "./iRentalServiceAccount.json"
            };
            var client = clientBuilder.Build();
            return client;
        }
    }
}
