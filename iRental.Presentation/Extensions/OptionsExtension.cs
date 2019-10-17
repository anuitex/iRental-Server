using iRental.BusinessLogicLayer.Options;
using iRental.Common.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace iRental.Presentation.Extensions
{
    public static class OptionsExtension
    {
        public static void SetOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtAuthOption>(configuration.GetSection("JwtAuthOptions"));
            services.Configure<FirestoreOptions>(configuration.GetSection("FirestoreOptions"));
        }
    }
}
