using Google.Cloud.Firestore;
using iRental.Common.Constant;
using iRental.Domain.Entities.User;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace iRental.Firestore.Identity.Stores
{
    public class UserStore :
        IUserStore<UserEntity>,
        IUserEmailStore<UserEntity>,
        IUserPhoneNumberStore<UserEntity>,
        IUserTwoFactorStore<UserEntity>,
        IUserPasswordStore<UserEntity>,
        IUserRoleStore<UserEntity>
    {
        public readonly FirestoreDb _dbContext;

        public UserStore(FirestoreDb dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task AddToRoleAsync(UserEntity user, string roleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            user.Roles.Add(roleName);

            await _dbContext.Collection(Constants.Collections.User)
                .Document(user.Id)
                .SetAsync(user, cancellationToken: cancellationToken);
        }

        public async Task<IdentityResult> CreateAsync(UserEntity user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _dbContext.Collection(Constants.Collections.User)
                .Document(user.Id)
                .CreateAsync(user);

            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteAsync(UserEntity user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await _dbContext.Collection(Constants.Collections.User)
                .Document(user.Id)
                .DeleteAsync(cancellationToken: cancellationToken);

            return IdentityResult.Success;
        }

        public void Dispose()
        {
        }

        public async Task<UserEntity> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var querySnapshot = await _dbContext.Collection(Constants.Collections.User)
                .WhereEqualTo("NormalizedEmail", normalizedEmail)
                .GetSnapshotAsync(cancellationToken);

            var user = querySnapshot.Documents.Select(doc => doc.ConvertTo<UserEntity>()).FirstOrDefault();
            return user;
        }

        public async Task<UserEntity> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var docRef = await _dbContext.Collection(Constants.Collections.User)
                .Document(userId)
                .GetSnapshotAsync(cancellationToken);

            var userIdentity = docRef.ConvertTo<UserEntity>();
            return userIdentity;
        }

        public async Task<UserEntity> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var querySnapshot = await _dbContext.Collection(Constants.Collections.User)
                .WhereEqualTo("NormalizedLogin", normalizedUserName)
                .GetSnapshotAsync(cancellationToken);

            var user = querySnapshot.Documents.Select(doc => doc.ConvertTo<UserEntity>()).FirstOrDefault();
            return user;
        }

        public Task<string> GetEmailAsync(UserEntity user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(UserEntity user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult(user.EmailConfirmed);
        }

        public Task<string> GetNormalizedEmailAsync(UserEntity user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult(user.NormalizedEmail);
        }

        public Task<string> GetNormalizedUserNameAsync(UserEntity user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult(user.NormalizedLogin);
        }

        public Task<string> GetPasswordHashAsync(UserEntity user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult(user.PasswordHash);
        }

        public Task<string> GetPhoneNumberAsync(UserEntity user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult(user.PhoneNumber);
        }

        public Task<bool> GetPhoneNumberConfirmedAsync(UserEntity user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult(user.PhoneNumberConfirmed);
        }

        public async Task<IList<string>> GetRolesAsync(UserEntity user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return user.Roles;
        }

        public Task<bool> GetTwoFactorEnabledAsync(UserEntity user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult(user.TwoFactorEnabled);
        }

        public Task<string> GetUserIdAsync(UserEntity user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult(user.Id);
        }

        public Task<string> GetUserNameAsync(UserEntity user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Login);
        }

        public async Task<IList<UserEntity>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var docSnapshots = await _dbContext.Collection(Constants.Collections.User)
                .WhereArrayContains("Roles", roleName)
                .GetSnapshotAsync(cancellationToken: cancellationToken);

            var users = docSnapshots.Documents.Select(doc => doc.ConvertTo<UserEntity>()).ToList();
            return users;
        }

        public Task<bool> HasPasswordAsync(UserEntity user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            bool hasPassword = !string.IsNullOrEmpty(user.PasswordHash);
            return Task.FromResult(hasPassword);
        }

        public Task<bool> IsInRoleAsync(UserEntity user, string roleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult(user.Roles.Contains(roleName));
        }

        public Task RemoveFromRoleAsync(UserEntity user, string roleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            user.Roles.Remove(roleName);
            return Task.CompletedTask;
        }

        public Task SetEmailAsync(UserEntity user, string email, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            user.Email = email;
            return Task.CompletedTask;
        }

        public Task SetEmailConfirmedAsync(UserEntity user, bool confirmed, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            user.EmailConfirmed = confirmed;
            return Task.CompletedTask;
        }

        public Task SetNormalizedEmailAsync(UserEntity user, string normalizedEmail, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            user.NormalizedEmail = normalizedEmail;
            return Task.CompletedTask;
        }

        public Task SetNormalizedUserNameAsync(UserEntity user, string normalizedName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            user.NormalizedLogin = normalizedName;
            return Task.CompletedTask;
        }

        public Task SetPasswordHashAsync(UserEntity user, string passwordHash, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            user.PasswordHash = passwordHash;
            return Task.CompletedTask;
        }

        public Task SetPhoneNumberAsync(UserEntity user, string phoneNumber, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            user.PhoneNumber = phoneNumber;
            return Task.CompletedTask;
        }

        public Task SetPhoneNumberConfirmedAsync(UserEntity user, bool confirmed, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            user.PhoneNumberConfirmed = confirmed;
            return Task.CompletedTask;
        }

        public Task SetTwoFactorEnabledAsync(UserEntity user, bool enabled, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            user.TwoFactorEnabled = enabled;
            return Task.CompletedTask;
        }

        public Task SetUserNameAsync(UserEntity user, string userName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            user.Login = userName;
            return Task.CompletedTask;
        }

        public async Task<IdentityResult> UpdateAsync(UserEntity user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await _dbContext.Collection(Constants.Collections.User).Document(user.Id).SetAsync(user, cancellationToken: cancellationToken);

            return IdentityResult.Success;
        }
    }
}
