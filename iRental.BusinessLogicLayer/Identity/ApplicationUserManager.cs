using iRental.Domain.Entities.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace iRental.BusinessLogicLayer.Identity
{
    public class ApplicationUserManager : UserManager<UserEntity>
    {
        public ApplicationUserManager(
            IUserStore<UserEntity> store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<UserEntity> passwordHasher,
            IEnumerable<IUserValidator<UserEntity>> userValidators,
            IEnumerable<IPasswordValidator<UserEntity>> passwordValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            IServiceProvider services,
            ILogger<UserManager<UserEntity>> logger
            ) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        { }
    }
}
