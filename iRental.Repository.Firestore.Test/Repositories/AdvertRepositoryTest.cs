using iRental.Common.Enum;
using iRental.Domain.Entities;
using iRental.Repository.Firestore.Repositories;
using System.Threading.Tasks;
using Xunit;

namespace iRental.Repository.Firestore.Test.Repositories
{
    public class AdvertRepositoryTest : BaseRepositoryTest
    {
        public AdvertRepository _advertTestedRepository;
        private const string _advertId = "";

        public AdvertRepositoryTest()
        {
            _advertTestedRepository = new AdvertRepository(_firestoreContext, Constants.Constants.Collections.Advert);
        }

        [Fact]
        public async Task CreateAsyncTest()
        {
            var advert = new AdvertEntity()
            {
                Title = "",
                SaleType = Enums.AdvertSalesType.Rent,
                HouseType = Enums.AdvertHouseType.House,
                CurrencyName = "",
                Price = 11.0f,
                GeoPosition = new Google.Cloud.Firestore.GeoPoint(0, 0),
                Address = "",
                Description = "DEsc",
                Area = 10,
                UserId = "c98ae5bd-01a8-4a3d-9f69-da0e05bb242c"
            };

            await _advertTestedRepository.CreateAsync(advert);
        }

        [Fact]
        public async Task GetAllForUser()
        {
            string userId = "c98ae5bd-01a8-4a3d-9f69-da0e05bb242c";
            var advertsForUser = await _advertTestedRepository.GetAllForUserAsync(userId);
        }

        [Fact]
        public async Task GetAllAsyncTest()
        {
            var adverts = await _advertTestedRepository.GetAllAsync();
        }

        [Fact]
        public async Task FindByIdAsyncTest()
        {
            var advert = await _advertTestedRepository.FindByIdAsync(_advertId);
        }

        [Fact]
        public async Task DeleteByIdAsyncTest()
        {
            await _advertTestedRepository.DeleteByIdAsync(_advertId);
        }

        [Fact]
        public async Task UpdateAsyncTest()
        {
            var advert = await _advertTestedRepository.FindByIdAsync(_advertId);
            await _advertTestedRepository.UpdateAsync(advert);
        }
    }
}
