using iRental.Domain.Entities;
using iRental.ViewModel.ViewModels;
using System.Linq;

namespace iRental.BusinessLogicLayer.Mappers
{
    public static class AdvertMapper
    {
        public static AdvertEntity Map(AdvertCreateRequest request)
        {
            var result = new AdvertEntity
            {
                Title = request.Title,
                SaleType = request.SaleType,
                HouseType = request.HouseType,
                CurrencyName = request.CurrencyName,
                Price = request.Price,
                Area = request.Area,
                Address = request.Address,
                CountBeds = request.CountBeds,
                CountBathrooms = request.CountBathrooms,
                CountRooms = request.CountRooms,
                ComfortOptions = request.AdvertComforts,
                Description = request.Description
            };

            result.GeoPosition = new Google.Cloud.Firestore.GeoPoint(request.Lat, request.Lng);

            return result;
        }
    }
}
