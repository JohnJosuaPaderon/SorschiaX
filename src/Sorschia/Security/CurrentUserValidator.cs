﻿using Sorschia.Utilities;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Security
{
    internal sealed class CurrentUserValidator : ICurrentUserValidator
    {
        private readonly IUserValidator _userValidator;
        private readonly ICurrentUserIdProvider _currentUserIdProvider;

        public CurrentUserValidator(IUserValidator userValidator, ICurrentUserIdProvider currentUserIdProvider)
        {
            _userValidator = userValidator;
            _currentUserIdProvider = currentUserIdProvider;
        }

        public async Task<bool> ValidateApplicationAsync(int applicationId, CancellationToken cancellationToken = default)
        {
            var currentUserId = _currentUserIdProvider.CurrentUserId ?? throw new SorschiaException("Current User ID is unavailable");
            return await _userValidator.ValidateApplicationAsync(currentUserId, applicationId, cancellationToken);
        }

        public async Task<bool> ValidatePermissionAsync(int permissionId, CancellationToken cancellationToken = default)
        {
            var currentUserId = _currentUserIdProvider.CurrentUserId ?? throw new SorschiaException("Current User ID is unavailable");
            return await _userValidator.ValidatePermissionAsync(currentUserId, permissionId, cancellationToken);
        }

        public async Task<bool> ValidateRoleAsync(int roleId, CancellationToken cancellationToken = default)
        {
            var currentUserId = _currentUserIdProvider.CurrentUserId ?? throw new SorschiaException("Current User ID is unavailable");
            return await _userValidator.ValidateRoleAsync(currentUserId, roleId, cancellationToken);
        }
    }
}
