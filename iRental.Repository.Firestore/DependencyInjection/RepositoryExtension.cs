using iRental.Domain.Entities;
using iRental.Domain.Entities.User;
using iRental.Repository.Firestore.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace iRental.Repository.Firestore.DependencyInjection
{
    public static class RepositoryExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<BaseRepository<AdvertEntity>>();
            services.AddTransient<BaseRepository<PhotoEntity>>();
            services.AddTransient<BaseRepository<UserEntity>>();
        }
    }
}
