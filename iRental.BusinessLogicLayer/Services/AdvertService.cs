using iRental.BusinessLogicLayer.Identity;
using iRental.BusinessLogicLayer.Interfaces.Repositories;
using iRental.BusinessLogicLayer.Mappers;
using iRental.ViewModel.ViewModels;
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
    }
}
