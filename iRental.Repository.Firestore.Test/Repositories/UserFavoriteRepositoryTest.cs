using iRental.BusinessLogicLayer.Interfaces.Repositories;
using iRental.Common.Constant;
using iRental.Domain.Entities.User;
using iRental.Repository.Firestore.Repositories;
using System.Threading.Tasks;
using Xunit;

namespace iRental.Repository.Firestore.Test.Repositories
{
    public class UserFavoriteRepositoryTest : BaseRepositoryTest
    {
        public IUserFavoriteRepository _baseTestedRepository;

        public UserFavoriteRepositoryTest()
        {
            _baseTestedRepository = new UserFavoriteRepository(_firestoreContext);
        }

        [Fact]
        public async Task FindByUserIdTest()
        {
            var userId = "fa956f43-e2f9-4299-8d53-f0d0e98c5f20";
            await _baseTestedRepository.FindByUserIdAsync(userId);
        }
    }
}
