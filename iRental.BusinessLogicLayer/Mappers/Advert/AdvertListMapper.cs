using iRental.Domain.Entities;
using iRental.ViewModel.ViewModels;

namespace iRental.BusinessLogicLayer.Mappers
{
    public static class AdvertListMapper
    {
        public static AdvertListResponse Map(AdvertEntity entity)
        {
            var mappedModel = new AdvertListResponse();
            mappedModel.AdvertId = entity.Id;
            mappedModel.Title = entity.Title;
            mappedModel.Address = entity.Address;
            mappedModel.Price = $"{entity.CurrencyName} {entity.Price}";
            mappedModel.CountBeds = entity.CountBeds;
            mappedModel.CountRooms = entity.CountRooms;
            mappedModel.CountBathrooms = entity.CountBathrooms;
            return mappedModel;
        }
    }
}
