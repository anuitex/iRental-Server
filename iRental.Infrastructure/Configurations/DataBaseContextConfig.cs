using iRental.Infrastructure.Configurations.DatabaseContext;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace iRental.Infrastructure.Configurations
{
    public static class DataBaseContextConfig
    {
        public static void InjectDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
