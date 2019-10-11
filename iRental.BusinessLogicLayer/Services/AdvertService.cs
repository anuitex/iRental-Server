using iRental.BusinessLogicLayer.Interfaces;
using iRental.BusinessLogicLayer.Mappers;
using iRental.BusinessLogicLayer.Mappers.EntityMapper;
using iRental.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iRental.BusinessLogicLayer.Services
{
    public class AdvertService
    {
        private readonly IUnitOfWork _dbContext;


        public AdvertService(IUnitOfWork dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task CreateAsync(AdvertCreateRequest request, string userId)
        {
            var newAdvert = AdvertMapper.Map(request);
            newAdvert.UserId = userId;

            await _dbContext.Adverts.CreateAsync(newAdvert);
        }

        public async Task<IEnumerable<AdvertListResponse>> GetAllForUserAsync(string userId)
        {
            var adverts = await _dbContext.Adverts.GetAllAsync();
            var advertsViewModels = adverts.Select(advart => AdvertListMapper.Map(advart));
            return advertsViewModels;
        }

        public async Task<AdvertItemResponse> GetMoreByIdAsync(string advertId, string userId)
        {
            var advert = await _dbContext.Adverts.FindByIdAsync(advertId);
            var advertViewModel = AdvertItemMapper.Map(advert);

            var owner = await _dbContext.Users.FindByIdAsync(userId);

            advertViewModel.Owner = new AdvertOwner
            {
                FirstName = owner.FirstName,
                LastName = owner.LastName,
                Rating = owner.Rating,
                CountRated = owner.CountRated,
                AvatarUrl = owner.Avatar?.Url
            };

            //todo: set isFavorite for user
            //todo: get and set photosUrl
            return advertViewModel;
        }
    }
}
