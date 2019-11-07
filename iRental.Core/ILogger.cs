using System.Threading.Tasks;

namespace iRental.Core
{
    public interface ILogger
    {
        Task LogErrorAsync(string message, object exception);
    }
}
