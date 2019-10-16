using iRental.BusinessLogicLayer.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace iRental.BusinessLogicLayer.DependencyInjection
{
    public static class ManagerExtension
    {
        public static void AddManagers(this IServiceCollection services)
        {
            services.AddScoped<JwtManager>();
        }
    }
}
