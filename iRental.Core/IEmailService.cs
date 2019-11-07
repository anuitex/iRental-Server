using iRental.Core.Models;
using System.Threading.Tasks;

namespace iRental.Core
{
    public interface IEmailService
    {
        Task SendAsync(Email email);
    }
}
