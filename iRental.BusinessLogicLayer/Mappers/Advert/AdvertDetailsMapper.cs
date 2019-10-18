using iRental.Domain.Entities;
using iRental.Domain.Entities.User;
using iRental.ViewModel.ViewModels;

namespace iRental.BusinessLogicLayer.Mappers
{
    public static class AdvertDetailsMapper
    {
        public static AdvertsDetailsResponse Map(AdvertEntity entity, UserEntity owner)
        {
            var viewModel = new AdvertsDetailsResponse();

            viewModel.Id = entity.Id;
            viewModel.Title = entity.Title;
            viewModel.Address = entity.Address;
            viewModel.Price = $"{entity.CurrencyName} {entity.Price}";
            viewModel.CountBeds = entity.CountBeds;
            viewModel.CountRooms = entity.CountRooms;
            viewModel.CountBathrooms = entity.CountBathrooms;
            viewModel.Area = entity.Area;

            viewModel.Owner = new AdvertOwner
            {
                UserId = owner.Id,
                FirstName = owner.FirstName,
                LastName = owner.LastName,
                Rating = owner.Rating,
                CountRated = owner.CountRated,
                AvatarUrl = owner.Avatar?.Url
            };

            return viewModel;
        }
    }
}
