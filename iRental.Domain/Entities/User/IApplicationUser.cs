using iRental.Domain.Enums;

namespace iRental.Domain.Entities.User
{
    public interface IApplicationUser
    {
        IUserProfile Profile { get;  set; }
        iRentalEnums.UserRole UserRole { get;  set; }
    }
}
