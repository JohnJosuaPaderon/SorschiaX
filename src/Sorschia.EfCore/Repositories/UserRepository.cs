using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Sorschia.Entities;
using Sorschia.Linq;
using Sorschia.Security;
using Sorschia.Utilities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Repositories
{
    internal sealed class UserRepository : IUserRepository
    {
        private readonly IDbContextFactory<SorschiaDbContext> _contextFactory;
        private readonly IFullNameBuilder _fullNameBuilder;
        private readonly IUserPasswordCryptoHash _passwordCryptoHash;

        public UserRepository(IDbContextFactory<SorschiaDbContext> contextFactory, IFullNameBuilder fullNameBuilder, IUserPasswordCryptoHash passwordCryptoHash)
        {
            _contextFactory = contextFactory;
            _fullNameBuilder = fullNameBuilder;
            _passwordCryptoHash = passwordCryptoHash;
        }

        public async Task<User> AddAsync(AddUserModel model, CancellationToken cancellationToken = default)
        {
            using var context = _contextFactory.CreateDbContext();
            using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

            var entry = await context.Users.AddAsync(new User
            {
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                NameSuffix = model.NameSuffix,
                FullName = _fullNameBuilder.Build(model.FirstName, model.MiddleName, model.LastName, model.NameSuffix),
                Username = model.Username,
                SecurePassword = _passwordCryptoHash.Compute(model.Password),
                IsActive = model.IsActive,
                IsPasswordChangeRequired = model.IsPasswordChangeRequired,
                IsEmailAddressVerified = model.IsEmailAddressVerified,
                IsMobileNumberVerified = model.IsMobileNumberVerified
            }, cancellationToken);

            if (model.ApplicationIds is not null && model.ApplicationIds.Any())
            {
                foreach (var applicationId in model.ApplicationIds)
                {
                    await context.UserApplications.AddAsync(new UserApplication
                    {
                        UserId = entry.Entity.Id,
                        ApplicationId = applicationId
                    }, cancellationToken);
                }
            }

            if (model.PermissionIds is not null && model.PermissionIds.Any())
            {
                foreach (var permissionId in model.PermissionIds)
                {
                    await context.UserPermissions.AddAsync(new UserPermission
                    {
                        UserId = entry.Entity.Id,
                        PermissionId = permissionId
                    }, cancellationToken);
                }
            }

            await context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);

            return await context
                .Users
                .AsNoTracking()
                .Where(_ => _.Id == entry.Entity.Id)
                .Select(_ => new User
                {
                    Id = _.Id,
                    FirstName = _.FirstName,
                    MiddleName = _.MiddleName,
                    LastName = _.LastName,
                    NameSuffix = _.NameSuffix,
                    FullName = _.FullName,
                    Username = _.Username,
                    EmailAddress = _.EmailAddress,
                    MobileNumber = _.MobileNumber,
                    IsActive = _.IsActive,
                    IsPasswordChangeRequired = _.IsPasswordChangeRequired,
                    IsEmailAddressVerified = _.IsEmailAddressVerified,
                    IsMobileNumberVerified = _.IsMobileNumberVerified
                })
                .Include(_ => _.Permissions)
                .ThenInclude(_ => _.Permission)
                .Include(_ => _.Applications)
                .ThenInclude(_ => _.Application)
                .SingleOrDefaultAsync(cancellationToken);
        }

        public async Task ChangePasswordAsync(ChangeUserPasswordModel model, CancellationToken cancellationToken = default)
        {
            using var context = _contextFactory.CreateDbContext();
            using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);
            var cryptoHash = context.GetService<IUserPasswordCryptoHash>();
            var secureOldPassword = cryptoHash.Compute(model.OldPassword);
            var secureNewPassword = cryptoHash.Compute(model.NewPassword);
            var user = await GetAsync(model.UserId, cancellationToken);

            if (user is null)
                throw new SorschiaException("User is invalid", true);

            if (user.SecurePassword != secureOldPassword)
                throw new SorschiaException("Old password is incorrect", true);

            if (string.IsNullOrWhiteSpace(secureNewPassword))
                throw new SorschiaException("New password is invalid", true);

            user.SecurePassword = secureNewPassword;
            await context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
        }

        public async Task<User> EditAsync(EditUserModel model, CancellationToken cancellationToken = default)
        {
            using var context = _contextFactory.CreateDbContext();
            using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

            var user = await GetAsync(model.Id, cancellationToken);

            if (user is null)
                throw new SorschiaException("Invalid user", true);

            await context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);

            return user;
        }

        public async Task<User> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            using var context = _contextFactory.CreateDbContext();
            return await GetAsync(id, context, cancellationToken);
        }

        public async Task<User> LoginAsync(LoginUserModel model, CancellationToken cancellationToken = default)
        {
            using var context = _contextFactory.CreateDbContext();
            var cryptoHash = context.GetService<IUserPasswordCryptoHash>();
            var securePassword = cryptoHash.Compute(model.Password);
            var user = await context
                .Users
                .AsNoTracking()
                .Where(_ => _.Username == model.Username && _.SecurePassword == securePassword)
                .SingleOrDefaultAsync(cancellationToken);

            if (user is null)
                throw new SorschiaException("Invalid username and/or password", true);

            return user;
        }

        public async Task<SearchUserResult> SearchUserAsync(SearchUserModel model, CancellationToken cancellationToken = default)
        {
            using var context = _contextFactory.CreateDbContext();
            var query = context
                .Users
                .AsNoTracking()
                .WhereIf(_ => _.FullName.Contains(model.FullNameFilter), !string.IsNullOrWhiteSpace(model.FullNameFilter))
                .WhereIf(_ => _.IsActive == model.IsActive, model.IsActive is not null)
                .WhereIf(_ => _.IsPasswordChangeRequired == model.IsPasswordChangeRequired, model.IsPasswordChangeRequired is not null)
                .WhereIf(_ => _.IsEmailAddressVerified == model.IsEmailAddressVerified, model.IsEmailAddressVerified is not null)
                .WhereIf(_ => _.IsMobileNumberVerified == model.IsMobileNumberVerified, model.IsMobileNumberVerified is not null);

            return new SearchUserResult
            {
                Users = await query.TrySkip(model.SkippedCount).TryTake(model?.TakenCount).ToListAsync(cancellationToken),
                TotalCount = await query.CountAsync(cancellationToken),
                ActiveCount = await query.CountIfAsync(_ => _.IsActive, model.IncludeActiveCount, cancellationToken),
                PasswordChangeRequiredCount = await query.CountIfAsync(_ => _.IsPasswordChangeRequired, model.IncludeRequiredPasswordChangeCount, cancellationToken),
                EmailAddressVerifiedCount = await query.CountIfAsync(_ => _.IsEmailAddressVerified, model.IncludeVerifiedEmailAddressCount, cancellationToken),
                MobileNumberVerifiedCount = await query.CountIfAsync(_ => _.IsMobileNumberVerified, model.IncludeVerifiedMobileNumberCount, cancellationToken)
            };
        }

        private static async Task<User> GetAsync(int id, SorschiaDbContext context, CancellationToken cancellationToken = default)
        {
            return await context.Users.FindAsync(new object[] { id }, cancellationToken: cancellationToken);
        }
    }
}
