using iRental.Domain.Entities.User;
using iRental.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;

namespace iRental.Infrastructure.Entities
{
    public class ApplicationUser : IdentityUser, IApplicationUser
    {
        public IUserProfile Profile { get; set; }
        public iRentalEnums.UserRole UserRole { get; set; }

        public ApplicationUser(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException(nameof(email));
            }
        }
    }
}
