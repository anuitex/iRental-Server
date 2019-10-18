using iRental.BusinessLogicLayer.Interfaces.Repositories;
using iRental.BusinessLogicLayer.Mappers;
using iRental.Domain.Entities.User;
using iRental.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iRental.BusinessLogicLayer.Services
{
    public class HomeService
    {
        private readonly IAdvertRepository _advertRepository;
        private readonly IPhotoRepository _photoRepository;
        private readonly IUserFavoriteRepository _favoritesRepository;
        private readonly IUserSaveListRepository _userSaveListRepository;

        public HomeService(
            IAdvertRepository advertRepository, 
            IPhotoRepository photoRepository, 
            IUserFavoriteRepository favoritesRepository,
            IUserSaveListRepository userSaveListRepository
            )
        {
            _advertRepository = advertRepository;
            _photoRepository = photoRepository;
            _favoritesRepository = favoritesRepository;
            _userSaveListRepository = userSaveListRepository;
        }

        public async Task<IEnumerable<AdvertListResponse>> GetAllForUserAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("userId");
            }

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
            if (owner == null)
            {
                throw new ArgumentNullException("owner");
            }
            if (string.IsNullOrEmpty(advertId))
            {
                throw new ArgumentNullException("advertId");
            }

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

            advertViewModel.IsFavorite = await _favoritesRepository.IsAdvertInFavorites(owner.Id, advertId);
            advertViewModel.IsInSaveList = await _userSaveListRepository.ContainsAdvert(owner.Id, advertId);

            //get and set photosUrl
            var photoEntity = await _photoRepository.FindByIdAsync(advert.MainPhotoId);
            advertViewModel.PhotosUrl.ToList().Add(photoEntity.Url);
            var photoUrls = await _photoRepository.GetUrlsByIds(advert.PhotoIds);
            advertViewModel.PhotosUrl.ToList().AddRange(photoUrls);

            return advertViewModel;
        }
    }
}
