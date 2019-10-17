using iRental.BusinessLogicLayer.Interfaces.Repositories;
using iRental.Repository.Firestore.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace iRental.Repository.Firestore.DependencyInjection
{
    public static class RepositoryExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IAdvertRepository, AdvertRepository>();
            services.AddTransient<IPhotoRepository, PhotoRepository>();
        }
    }
}
