using iRental.BusinessLogicLayer.Services;
using Microsoft.Extensions.DependencyInjection;

namespace iRental.BusinessLogicLayer.DependencyInjection
{
    public static class ServiceExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<AdvertService>();
            services.AddTransient<AdvertsHomeService>();
            services.AddTransient<AccountService>();
        }
    }
}
