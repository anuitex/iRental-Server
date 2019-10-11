using iRental.Common.Enum;
using iRental.Domain.Entities.User;
using iRental.Repository.Repositories;
using System;
using System.Threading.Tasks;
using Xunit;

namespace iRental.Repository.Firestore.Test.Repositories
{
    public class UserRepositoryTest : BaseRepositoryTest
    {
        public BaseRepository<UserEntity> _baseTestedRepository;

        public UserRepositoryTest()
        {
            _baseTestedRepository = new BaseRepository<UserEntity>(_firestoreContext, Constants.Constants.Collections.User);
        }

        [Fact]
        public async Task CreateAsyncTest()
        {
            var user = new UserEntity
            {
                Birthday = DateTime.UtcNow,
                FirstName = "first",
                LastName = "las",
                PhoneNumber = "ph",
                Email = "mail",
                PasswordHash = "hash",
                GenderType = Enums.UserGender.Male,
                Country = "Ukr",
                City = "Kha",
                Address = "adrs",
                NumberAddressHouse = 1
            };
            user.Favorites = new UserFaforiteEntity { UserId = user.Id };

            await _baseTestedRepository.CreateAsync(user);
        }

        [Fact]
        public async Task GetAllAsyncTest()
        {
            var users = await _baseTestedRepository.GetAllAsync();
        }

        [Fact]
        public async Task FindByIdAsyncTest()
        {
            var user = await _baseTestedRepository.FindByIdAsync("19ed68f1-6da3-43bf-abb8-2614434269ec");
        }

        [Fact]
        public async Task DeleteByIdAsyncTest()
        {
            await _baseTestedRepository.DeleteByIdAsync("19ed68f1-6da3-43bf-abb8-2614434269ec");
        }

        [Fact]
        public async Task UpdateAsyncTest()
        {
            var user = await _baseTestedRepository.FindByIdAsync("19ed68f1-6da3-43bf-abb8-2614434269ec");
            user.LastName = "UpdNam";
            await _baseTestedRepository.UpdateAsync(user);
            var updatedUser = await _baseTestedRepository.FindByIdAsync(user.Id);
        }
    }
}
