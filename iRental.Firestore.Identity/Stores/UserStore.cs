using Google.Cloud.Firestore;
using iRental.Common.Constant;
using iRental.Common.Options;
using iRental.Domain.Entities.User;
using iRental.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace iRental.Firestore.Identity.Stores
{
    public class UserStore : IUserStore<UserIdentity>, IUserEmailStore<UserIdentity>, IUserPhoneNumberStore<UserIdentity>,
        IUserTwoFactorStore<UserIdentity>, IUserPasswordStore<UserIdentity>, IUserRoleStore<UserIdentity>
    {
        public readonly FirestoreDb _dbContext;

        public UserStore(IOptions<FirestoreOptions> options)
        {
            if (options.Value == null)
            {
                throw new ArgumentNullException("options", "Options can`t be null");
            }

            _dbContext = FirestoreDb.Create(options.Value.ProjectId);
        }


        public async Task AddToRoleAsync(UserIdentity user, string roleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            user.Roles.Add(roleName);

            await _dbContext.Collection(Constants.Collections.UserIdentity)
                .Document(user.UserId)
                .SetAsync(user, cancellationToken: cancellationToken);
        }

        public async Task<IdentityResult> CreateAsync(UserIdentity user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await _dbContext.Collection(Constants.Collections.UserIdentity)
                .Document(user.UserId)
                .CreateAsync(user);

            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteAsync(UserIdentity user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await _dbContext.Collection(Constants.Collections.UserIdentity)
                .Document(user.UserId)
                .DeleteAsync(cancellationToken: cancellationToken);

            return IdentityResult.Success;
        }

        public void Dispose()
        {
        }

        public async Task<UserIdentity> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var querySnapshot = await _dbContext.Collection(Constants.Collections.UserIdentity)
                .WhereEqualTo("NormalizedEmail", normalizedEmail)
                .GetSnapshotAsync(cancellationToken);

            var user = querySnapshot.Documents.Select(doc => doc.ConvertTo<UserIdentity>()).FirstOrDefault();
            return user;
        }

        public async Task<UserIdentity> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var docRef = await _dbContext.Collection(Constants.Collections.UserIdentity)
                .Document(userId)
                .GetSnapshotAsync(cancellationToken);

            var userIdentity = docRef.ConvertTo<UserIdentity>();
            return userIdentity;
        }

        public async Task<UserIdentity> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var querySnapshot = await _dbContext.Collection(Constants.Collections.UserIdentity)
                .WhereEqualTo("NormalizedUserName", normalizedUserName)
                .GetSnapshotAsync(cancellationToken);

            var user = querySnapshot.Documents.Select(doc => doc.ConvertTo<UserIdentity>()).FirstOrDefault();
            return user;
        }

        public async Task<string> GetEmailAsync(UserIdentity user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var userEntity = await GetUserEntity(user.UserId, cancellationToken);
            return userEntity.Email;
        }

        public Task<bool> GetEmailConfirmedAsync(UserIdentity user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult(user.EmailConfirmed);
        }

        public Task<string> GetNormalizedEmailAsync(UserIdentity user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult(user.NormalizedEmail);
        }

        public Task<string> GetNormalizedUserNameAsync(UserIdentity user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult($"{user.NormalizedFirstName} {user.NormalizedLastName}");
        }

        public async Task<string> GetPasswordHashAsync(UserIdentity user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var userEnitity = await GetUserEntity(user.UserId, cancellationToken);
            return userEnitity.PasswordHash;
        }

        public async Task<string> GetPhoneNumberAsync(UserIdentity user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var userEnitity = await GetUserEntity(user.UserId, cancellationToken);
            return userEnitity.PhoneNumber;
        }

        public Task<bool> GetPhoneNumberConfirmedAsync(UserIdentity user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult(user.PhoneNumberConfirmed);
        }

        public async Task<IList<string>> GetRolesAsync(UserIdentity user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return user.Roles;
        }

        public Task<bool> GetTwoFactorEnabledAsync(UserIdentity user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult(user.TwoFactorEnabled);
        }

        public Task<string> GetUserIdAsync(UserIdentity user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult(user.UserId);
        }

        public Task<string> GetUserNameAsync(UserIdentity user, CancellationToken cancellationToken)
        {
            return Task.FromResult($"{user.FirstName} {user.LastName}");
        }

        public async Task<IList<UserIdentity>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var docSnapshots = await _dbContext.Collection(Constants.Collections.UserIdentity)
                .WhereArrayContains("Roles", roleName)
                .GetSnapshotAsync(cancellationToken: cancellationToken);

            var users = docSnapshots.Documents.Select(doc => doc.ConvertTo<UserIdentity>()).ToList();
            return users;
        }

        public async Task<bool> HasPasswordAsync(UserIdentity user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var userEnitity = await GetUserEntity(user.UserId, cancellationToken);

            bool hasPassword = !string.IsNullOrEmpty(userEnitity.PasswordHash);
            return hasPassword;
        }

        public Task<bool> IsInRoleAsync(UserIdentity user, string roleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult(user.Roles.Contains(roleName));
        }

        public async Task RemoveFromRoleAsync(UserIdentity user, string roleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            user.Roles.Remove(roleName);
            await _dbContext.Collection(Constants.Collections.UserIdentity).Document(user.UserId).SetAsync(user, cancellationToken: cancellationToken);
        }

        public async Task SetEmailAsync(UserIdentity user, string email, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var userEntity = await GetUserEntity(user.UserId, cancellationToken);

            userEntity.Email = email;
            await SaveUserEntity(userEntity, cancellationToken);
        }

        public Task SetEmailConfirmedAsync(UserIdentity user, bool confirmed, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            user.EmailConfirmed = confirmed;
            return Task.CompletedTask;
        }

        public Task SetNormalizedEmailAsync(UserIdentity user, string normalizedEmail, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            user.NormalizedEmail = normalizedEmail;
            return Task.CompletedTask;
        }

        public Task SetNormalizedUserNameAsync(UserIdentity user, string normalizedName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var splistString = normalizedName.Split(' ');
            user.NormalizedFirstName = splistString[0];
            user.NormalizedLastName = splistString[1];
            return Task.CompletedTask;
        }

        public async Task SetPasswordHashAsync(UserIdentity user, string passwordHash, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var userEntity = await GetUserEntity(user.UserId, cancellationToken);
            userEntity.PasswordHash = passwordHash;
            await SaveUserEntity(userEntity, cancellationToken);
        }

        public async Task SetPhoneNumberAsync(UserIdentity user, string phoneNumber, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var userEntity = await GetUserEntity(user.UserId, cancellationToken);
            userEntity.PhoneNumber = phoneNumber;
            await SaveUserEntity(userEntity, cancellationToken);
        }

        public Task SetPhoneNumberConfirmedAsync(UserIdentity user, bool confirmed, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            user.PhoneNumberConfirmed = confirmed;
            return Task.CompletedTask;
        }

        public Task SetTwoFactorEnabledAsync(UserIdentity user, bool enabled, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            user.TwoFactorEnabled = enabled;
            return Task.CompletedTask;
        }

        public Task SetUserNameAsync(UserIdentity user, string userName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var splistString = userName.Split(' ');
            user.FirstName = splistString[0];
            user.LastName = splistString[1];
            return Task.CompletedTask;
        }

        public async Task<IdentityResult> UpdateAsync(UserIdentity user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await _dbContext.Collection(Constants.Collections.UserIdentity).Document(user.UserId).SetAsync(user, cancellationToken: cancellationToken);

            return IdentityResult.Success;
        }

        #region helpers

        private async Task<UserEntity> GetUserEntity(string userId, CancellationToken cancellationToken)
        {
            var docRef = await _dbContext.Collection(Constants.Collections.User)
                .Document(userId)
                .GetSnapshotAsync(cancellationToken);
            var userEnitity = docRef.ConvertTo<UserEntity>();
            return userEnitity;
        }

        private async Task SaveUserEntity(UserEntity userEntity, CancellationToken cancellationToken)
        {
            await _dbContext.Collection(Constants.Collections.User)
                .Document(userEntity.Id)
                .SetAsync(userEntity, cancellationToken: cancellationToken);
        }

        #endregion
    }
}
