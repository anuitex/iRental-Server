using iRental.BusinessLogicLayer.Interfaces.Clients;
using Microsoft.Extensions.DependencyInjection;

namespace iRental.Client.DependencyInjection
{
    public static class FileUploaderExtension
    {
        public static void AddClients(this IServiceCollection services)
        {
            services.AddTransient<IFileUploader, FileUploader>();
        }
    }
}
