using iRental.Common.Constant;
using iRental.Common.Enum;
using iRental.Domain.Entities;
using iRental.Repository.Firestore.Repositories;
using System;
using System.Threading.Tasks;
using Xunit;

namespace iRental.Repository.Firestore.Test.Repositories
{
    public class AdvertRepositoryTest : BaseRepositoryTest
    {
        public AdvertRepository _advertTestedRepository;

        public AdvertRepositoryTest()
        {
            _advertTestedRepository = new AdvertRepository(_firestoreContext);
        }

        [Fact]
        public async Task CreateAsyncTest()
        {
            var advert = new AdvertEntity()
            {
                Title = "title3",
                SaleType = Enums.AdvertSalesType.Rent,
                HouseType = Enums.AdvertHouseType.House,
                CurrencyName = "USD",
                Price = 11.0f,
                GeoPosition = new Google.Cloud.Firestore.GeoPoint(0, 0),
                Address = "",
                Description = "Desc",
                Area = 10,
                UserId = "c98ae5bd-01a8-4a3d-9f69-da0e05bb242c"
            };

            advert.PhotoIds.Add(Guid.NewGuid().ToString());

            advert.ComfortOptions.Add(Enums.AdvertComfort.Gas);
            advert.ComfortOptions.Add(Enums.AdvertComfort.Lift);

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
            string advertId = "52d7c9fa-ac70-426f-b922-2e48abdd43a0";
            var advert = await _advertTestedRepository.FindByIdAsync(advertId);
        }

        [Fact]
        public async Task UpdateAsyncTest()
        {
            string advertId = "d27bb851-889b-4f20-bea9-8d5f3dd4e42e";
            var advert = await _advertTestedRepository.FindByIdAsync(advertId);
            advert.Title = "Custom";
            await _advertTestedRepository.UpdateAsync(advert);
        }

        [Fact]
        public async Task DeleteByIdAsyncTest()
        {
            string advertId = "d27bb851-889b-4f20-bea9-8d5f3dd4e42e";
            await _advertTestedRepository.DeleteByIdAsync(advertId);
        }
    }
}
