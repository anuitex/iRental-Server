using iRental.Common.Enum;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace iRental.ViewModel.ViewModels
{
    public class AdvertCreateRequest
    {
        public IFormFile MainPhoto { get; set; }
        public List<IFormFile> Photos { get; set; }
        public string Title { get; set; }
        public Enums.AdvertSalesType SaleType { get; set; }
        public Enums.AdvertHouseType HouseType { get; set; }
        public string CurrencyName { get; set; }
        public int Price { get; set; }
        public int Area { get; set; }
        public string Address { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public int CountBeds { get; set; }
        public int CountRooms { get; set; }
        public int CountBathrooms { get; set; }
        public IEnumerable<Enums.AdvertComfort> AdvertComforts { get; set; }
        public string Description { get; set; }

        public AdvertCreateRequest()
        {
            Photos = new List<IFormFile>();
        }
    }
}
