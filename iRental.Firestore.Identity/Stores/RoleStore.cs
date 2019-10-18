using Google.Cloud.Firestore;
using iRental.Common.Constant;
using iRental.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace iRental.Firestore.Identity.Stores
{
    public class RoleStore : IRoleStore<RoleIdentity>
    {
        private readonly FirestoreDb _dbContext;

        public RoleStore(FirestoreDb dbContext)
        {
            _dbContext = dbContext;
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

            var snapshot = querySnapshot.Documents.FirstOrDefault();
            if (snapshot == null)
            {
                return null;
            }

            var role = snapshot.ConvertTo<RoleIdentity>();
            return role;
        }

        public Task<string> GetNormalizedRoleNameAsync(RoleIdentity role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return Task.FromResult(role.NormalizedName);
        }

        public Task<string> GetRoleIdAsync(RoleIdentity role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return Task.FromResult(role.Id);
        }

        public Task<string> GetRoleNameAsync(RoleIdentity role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return Task.FromResult(role.Name);
        }

        public Task SetNormalizedRoleNameAsync(RoleIdentity role, string normalizedName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            role.NormalizedName = normalizedName;
            return Task.CompletedTask;
        }

        public Task SetRoleNameAsync(RoleIdentity role, string roleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            role.Name = roleName;
            return Task.CompletedTask;
        }

        public async Task<IdentityResult> UpdateAsync(RoleIdentity role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _dbContext.Collection(Constants.Collections.RoleIdentity).Document(role.Id).SetAsync(role, cancellationToken: cancellationToken);
            return IdentityResult.Success;
        }
    }
}
