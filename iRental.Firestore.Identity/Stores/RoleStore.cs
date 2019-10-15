using Google.Cloud.Firestore;
using iRental.Common.Options;
using iRental.Firestore.Identity.Identities;
using iRental.Repository.Firestore.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace iRental.Firestore.Identity.Stores
{
    public class RoleStore : IRoleStore<RoleIdentity>
    {
        private readonly FirestoreDb _dbContext;

        public RoleStore(IOptions<FirestoreOptions> options)
        {
            if (options.Value == null)
            {
                throw new ArgumentNullException("options", "Options can`t be null");
            }

            _dbContext = FirestoreDb.Create(options.Value.ProjectId);
        }

        public async Task<IdentityResult> CreateAsync(RoleIdentity role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _dbContext.Collection(Constants.Collections.RoleIdentity).Document(role.Id).CreateAsync(role, cancellationToken);
            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteAsync(RoleIdentity role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _dbContext.Collection(Constants.Collections.RoleIdentity).Document(role.Id).DeleteAsync(cancellationToken: cancellationToken);
            return IdentityResult.Success;
        }

        public void Dispose()
        {
        }

        public async Task<RoleIdentity> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var snapshot = await _dbContext.Collection(Constants.Collections.RoleIdentity).Document(roleId).GetSnapshotAsync(cancellationToken);
            var role = snapshot.ConvertTo<RoleIdentity>();
            return role;
        }

        public async Task<RoleIdentity> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var colRef = await _dbContext.Collection(Constants.Collections.RoleIdentity).GetSnapshotAsync(cancellationToken);
            var selectQuery = colRef.Query.WhereEqualTo("NormalizedName", normalizedRoleName);
            var querySnapshot = await selectQuery.GetSnapshotAsync(cancellationToken);

            var role = querySnapshot.Documents[0].ConvertTo<RoleIdentity>();
            return role;
        }

        public async Task<string> GetNormalizedRoleNameAsync(RoleIdentity role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return role.NormalizedName;
        }

        public async Task<string> GetRoleIdAsync(RoleIdentity role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return role.Id;
        }

        public async Task<string> GetRoleNameAsync(RoleIdentity role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return role.Name;
        }

        public async Task SetNormalizedRoleNameAsync(RoleIdentity role, string normalizedName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            role.NormalizedName = normalizedName;
        }

        public async Task SetRoleNameAsync(RoleIdentity role, string roleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            role.Name = roleName;
        }

        public async Task<IdentityResult> UpdateAsync(RoleIdentity role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _dbContext.Collection(Constants.Collections.RoleIdentity).Document(role.Id).SetAsync(role, cancellationToken: cancellationToken);
            return IdentityResult.Success;
        }
    }
}
