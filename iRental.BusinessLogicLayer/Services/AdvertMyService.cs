﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iRental.BusinessLogicLayer.Interfaces.Repositories;
using iRental.BusinessLogicLayer.Mappers;
using iRental.Domain.Entities.User;
using iRental.ViewModel.ViewModels;

namespace iRental.BusinessLogicLayer.Services
{
    public class AdvertMyService
    {
        private readonly IAdvertRepository _advertRepository;
        private readonly IPhotoRepository _photoRepository;
        private readonly IUserFavoriteRepository _favoritesRepository;
        private readonly IUserSaveListRepository _userSaveListRepository;

        public AdvertMyService(
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

        public async Task<IEnumerable<AdvertListResponse>> GetAllAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("userId");
            }

            var adverts = await _advertRepository.GetAllWithUserAsync(userId);

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

        public async Task<AdvertsDetailsResponse> GetByIdAsync(string advertId, UserEntity owner)
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
            var advertViewModel = AdvertDetailsMapper.Map(advert, owner);

            advertViewModel.IsFavorite = await _favoritesRepository.IsAdvertInFavorites(owner.Id, advertId);
            advertViewModel.IsInSaveList = await _userSaveListRepository.ContainsAdvert(owner.Id, advertId);

            //get and set photosUrl
            var mainPhotoEntity = await _photoRepository.FindByIdAsync(advert.MainPhotoId);
            var photoUrls = await _photoRepository.GetUrlsByIds(advert.PhotoIds);

            var photos = advertViewModel.PhotosUrl.ToList();
            photos.Add(mainPhotoEntity.Url);
            photos.AddRange(photoUrls);

            return advertViewModel;
        }
    }
}
