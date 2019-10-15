using iRental.Common.Enum;
using Microsoft.AspNetCore.Http;
using System;

namespace iRental.ViewModel.ViewModels
{
    public class UserCreateRequest
    {
        public IFormFile Avatar { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordRepeat { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public Enums.UserGender Gender { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
