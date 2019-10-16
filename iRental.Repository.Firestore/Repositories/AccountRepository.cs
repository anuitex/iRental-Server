using Google.Cloud.Firestore;
using iRental.BusinessLogicLayer.Interfaces.Repositories;
using iRental.Common.Constant;
using iRental.Domain.Entities.User;

namespace iRental.Repository.Firestore.Repositories
{
    public class AccountRepository : BaseRepository<UserEntity>, IAccountRepository
    {
        public AccountRepository(FirestoreDb dbContext) : base(dbContext, Constants.Collections.User)
        {
        }
    }
}
