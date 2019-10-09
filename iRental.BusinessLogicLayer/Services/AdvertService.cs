using iRental.BusinessLogicLayer.Interfaces;
using iRental.Domain.Entities;
using iRental.ViewModel.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iRental.BusinessLogicLayer.Services
{
    public class AdvertService
    {
        private readonly IUnitOfWork _dbContext;


        public AdvertService(IUnitOfWork dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<AdvertViewModel>> GetAllAsync()
        {
            var advarts = await _dbContext.Adverts.GetAllAsync();
            var advartsViewModels = advarts.Select(advart => new AdvertViewModel
            {
            });
            return advartsViewModels;
        }

        public async Task<>
    }
}
