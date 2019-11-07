using iRental.Domain.Entities.User;
using iRental.Domain.Enums;
using System;

namespace iRental.Infrastructure.Entities
{
    public class UserProfile : IUserProfile
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public iRentalEnums.UserGenderType Gender { get; set; }
        public string Email { get; set; }
        public DateTime BirthdayDate { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
