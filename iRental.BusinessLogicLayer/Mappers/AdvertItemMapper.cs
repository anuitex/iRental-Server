using iRental.Domain.Entities;
using iRental.ViewModel.ViewModels;

namespace iRental.BusinessLogicLayer.Mappers
{
    public static class AdvertItemMapper
    {
        public static AdvertItemResponse Map(AdvertEntity entity)
        {
            var viewModel = new AdvertItemResponse();

            viewModel.Id = entity.Id;
            viewModel.Title = entity.Title;
            viewModel.Address = entity.Address;
            viewModel.Price = $"{entity.CurrencyName} {entity.Price}";
            viewModel.CountBeds = entity.CountBeds;
            viewModel.CountRooms = entity.CountRooms;
            viewModel.CountBathrooms = entity.CountBathrooms;
            viewModel.Area = entity.Area;

            return viewModel;
        }
    }
}
