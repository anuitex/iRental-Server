using iRental.Domain.Entities.User;
using iRental.Domain.Identity;
using iRental.Firestore.Identity.Stores;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace iRental.Firestore.Identity.DependencyInjection
{
    public static class IdentityExtension
    {
        public static void AddApplicationIdentity(this IServiceCollection services)
        {
            services.AddTransient<IUserStore<UserEntity>, UserStore>();
            services.AddTransient<IRoleStore<RoleIdentity>, RoleStore>();
        }
    }
}
