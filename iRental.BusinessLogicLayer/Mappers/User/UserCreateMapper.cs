using iRental.Domain.Entities.User;
using iRental.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace iRental.BusinessLogicLayer.Mappers.User
{
    public static class UserCreateMapper
    {
        public static UserEntity Map(UserCreateRequest request)
        {
            var userEntity = new UserEntity()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Birthday = request.Birthday.ToUniversalTime(),
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                GenderType = request.Gender,
                Country = request.Country,
                City = request.City,
                Address = request.Address
            };

            return userEntity;
        }
    }
}
