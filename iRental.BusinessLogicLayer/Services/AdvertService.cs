using iRental.BusinessLogicLayer.Identity;
using iRental.BusinessLogicLayer.Interfaces.Repositories;
using iRental.BusinessLogicLayer.Mappers;
using iRental.ViewModel.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iRental.BusinessLogicLayer.Services
{
    public class AdvertService
    {
        private readonly IAdvertRepository _advertRepository;
        private readonly ApplicationUserManager _userManager;


        public AdvertService(IAdvertRepository advertRepository, ApplicationUserManager userManager)
        {
            _advertRepository = advertRepository;
            _userManager = userManager;
        }


        public async Task CreateAsync(AdvertCreateRequest request, string userId)
        {
            var newAdvert = AdvertMapper.Map(request);
            newAdvert.UserId = userId;

            await _advertRepository.CreateAsync(newAdvert);
        }

        public async Task<IEnumerable<AdvertListResponse>> GetAllForUserAsync(string userId)
        {
            var adverts = await _advertRepository.GetAllAsync();
            var advertsViewModels = adverts.Select(advart => AdvertListMapper.Map(advart));
            return advertsViewModels;
        }

        public async Task<AdvertsDetailsResponse> GetMoreByIdAsync(string advertId, string userId)
        {
            var advert = await _advertRepository.FindByIdAsync(advertId);
            var advertViewModel = AdvertDetailsMapper.Map(advert);

            var owner = await _userManager.FindByIdAsync(userId);

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
