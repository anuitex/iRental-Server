using iRental.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace iRental.Domain.Entities.User
{
    public interface IUserProfile
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        iRentalEnums.UserGenderType Gender { get; set; }
        string Email { get; set; }
        DateTime BirthdayDate { get; set; }
        string Country { get; set; }
        string City { get; set; }
        string Address { get; set; }
        string PhoneNumber { get; set; }

        //[NotMapped]
        //string FullName { get; set; }
        //[NotMapped]
        //string Location { get; set; }
    }
}
