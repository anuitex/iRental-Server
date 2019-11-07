using System.Threading.Tasks;

namespace iRental.Domain.Services
{
    public interface IUserManager
    {
        Task SignInAsyn(string email, string password, bool isLocked = true);
        Task SignUpAsyn();
    }
}