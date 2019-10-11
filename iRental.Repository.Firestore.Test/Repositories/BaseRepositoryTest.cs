using Google.Cloud.Firestore;

namespace iRental.Repository.Firestore.Test.Repositories
{
    public abstract class BaseRepositoryTest
    {
        protected FirestoreDb _firestoreContext;

        public BaseRepositoryTest()
        {
            string projectId = SettingRepository.ProjectId;
            var client = SettingRepository.GetClient();
            _firestoreContext = FirestoreDb.Create(projectId, client);
        }
    }
}
