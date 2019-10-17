using iRental.BusinessLogicLayer.Interfaces.Repositories;
using iRental.BusinessLogicLayer.Mappers;
using iRental.Domain.Entities.User;
using iRental.ViewModel.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iRental.BusinessLogicLayer.Services
{
    public class HomeService
    {
        private readonly IAdvertRepository _advertRepository;
        private readonly IPhotoRepository _photoRepository;

        public HomeService(IAdvertRepository advertRepository, IPhotoRepository photoRepository)
        {
            _advertRepository = advertRepository;
            this._photoRepository = photoRepository;
        }

        public async Task<IEnumerable<AdvertListResponse>> GetAllForUserAsync(string userId)
        {
            var adverts = await _advertRepository.GetAllForUserAsync(userId);

            var advertsViewModels = new List<AdvertListResponse>();
            foreach (var advert in adverts)
            {
                var advertViewModel = AdvertListMapper.Map(advert);
                var photoEntity = await _photoRepository.FindByIdAsync(advert.MainPhotoId);
                advertViewModel.MainPhotoUrl = photoEntity.Url;
                advertsViewModels.Add(advertViewModel);
            }

            return advertsViewModels;
        }

        public async Task<AdvertsDetailsResponse> GetMoreByIdAsync(string advertId, UserEntity owner)
        {
            var advert = await _advertRepository.FindByIdAsync(advertId);
            var advertViewModel = AdvertDetailsMapper.Map(advert);

            advertViewModel.Owner = new AdvertOwner
            {
                UserId = owner.Id,
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
