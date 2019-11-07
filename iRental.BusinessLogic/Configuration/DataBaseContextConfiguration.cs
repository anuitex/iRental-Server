using iRental.Core.DbContext;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace iRental.BusinessLogic.Configuration
{
    public static class DataBaseConfiguration
    {
        public static void InjectDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EFContext>(options => 
                    options.)
        }
    }
}
