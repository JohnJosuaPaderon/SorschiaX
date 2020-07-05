using Sorschia.Data;
using Sorschia.SystemCore.Entities;
using Sorschia.SystemCore.Queries;
using Sorschia.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Processes
{
    internal sealed class SavePermissionGroup : ProcessBase, ISavePermissionGroup
    {
        private readonly SavePermissionGroupQuery _query;
        private readonly SavePermissionQuery _savePermissionQuery;
        private readonly SaveApiPermissionQuery _saveApiPermissionQuery;
        private readonly DeletePermissionGroupQuery _deletePermissionGroupQuery;
        private readonly DeletePermissionQuery _deletePermissionQuery;

        public SavePermissionGroupModel Model { get; set; }

        public SavePermissionGroup(IConnectionStringProvider connectionStringProvider,
            SavePermissionGroupQuery query,
            SavePermissionQuery savePermissionQuery,
            SaveApiPermissionQuery saveApiPermissionQuery,
            DeletePermissionGroupQuery deletePermissionGroupQuery,
            DeletePermissionQuery deletePermissionQuery) : base(connectionStringProvider)
        {
            _query = query;
            _savePermissionQuery = savePermissionQuery;
            _saveApiPermissionQuery = saveApiPermissionQuery;
            _deletePermissionGroupQuery = deletePermissionGroupQuery;
            _deletePermissionQuery = deletePermissionQuery;
        }

        public async Task<SavePermissionGroupResult> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var model = ObjectCopy.Copy(Model);
                var result = new SavePermissionGroupResult();
                using var connection = await OpenConnectionAsync(cancellationToken);
                using var transaction = connection.BeginTransaction();
                await SaveAsync(model, result, connection, transaction, cancellationToken);
                transaction.Commit();
                return result;
            }
            catch (Exception ex)
            {
                ThrowError(ex);
                return default;
            }
        }

        private async Task SaveAsync(SavePermissionGroupModel model, SavePermissionGroupResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            await SaveAsync(model.Group, result, connection, transaction, cancellationToken);
            await SavePermissionsAsync(model.Permissions, result, connection, transaction, cancellationToken);
            await SaveApiPermissionsAsync(model.ApiPermissions, result, connection, transaction, cancellationToken);
            await DeletePermissionsAsync(model.DeletedPermissions, result, connection, transaction, cancellationToken);
            await DeleteSubGroupsAsync(model.DeletedSubGroups, result, connection, transaction, cancellationToken);
            await SaveSubGroupsAsync(model.SubGroups, result, connection, transaction, cancellationToken);
        }

        private async Task SaveAsync(PermissionGroup group, SavePermissionGroupResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            var _group = await _query.ExecuteAsync(group, connection, transaction, cancellationToken);

            if (_group is null)
                throw SorschiaException.VariableIsNull<PermissionGroup>(nameof(_group));

            result.Group = _group;
        }

        private async Task SavePermissionsAsync(IList<Permission> permissions, SavePermissionGroupResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (permissions != null && permissions.Count > 0)
                foreach (var permission in permissions)
                {
                    permission.GroupId = result.Group.Id;
                    await SavePermissionAsync(permission, result, connection, transaction, cancellationToken);
                }
        }

        private async Task SavePermissionAsync(Permission permission, SavePermissionGroupResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            var _permission = await _savePermissionQuery.ExecuteAsync(permission, connection, transaction, cancellationToken);

            if (_permission is null)
                throw SorschiaException.VariableIsNull<Permission>(nameof(_permission));

            result.Permissions.Add(_permission);
        }

        private async Task SaveApiPermissionsAsync(IList<ApiPermission> permissions, SavePermissionGroupResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (permissions != null && permissions.Count > 0)
                foreach (var permission in permissions)
                {
                    permission.GroupId = result.Group.Id;
                    await SaveApiPermissionAsync(permission, result, connection, transaction, cancellationToken);
                }
        }

        private async Task SaveApiPermissionAsync(ApiPermission permission, SavePermissionGroupResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            var _permission = await _saveApiPermissionQuery.ExecuteAsync(permission, connection, transaction, cancellationToken);

            if (_permission is null)
                throw SorschiaException.VariableIsNull<Permission>(nameof(_permission));

            result.ApiPermissions.Add(_permission);
        }

        private async Task DeletePermissionsAsync(IList<DeletePermissionModel> models, SavePermissionGroupResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (models != null && models.Count > 0)
                foreach (var model in models)
                    await DeletePermissionAsync(model, result, connection, transaction, cancellationToken);
        }

        private async Task DeletePermissionAsync(DeletePermissionModel model, SavePermissionGroupResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (await _deletePermissionQuery.ExecuteAsync(model, connection, transaction, cancellationToken))
                result.DeletedPermissionIds.Add(model.Id);
        }

        private async Task SaveSubGroupsAsync(IList<SavePermissionGroupModel> models, SavePermissionGroupResult parentResult, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (models != null && models.Count > 0)
                foreach (var model in models)
                {
                    model.Group.ParentId = parentResult.Group.Id;
                    await SaveSubGroupAsync(model, parentResult, connection, transaction, cancellationToken);
                }
        }

        private async Task SaveSubGroupAsync(SavePermissionGroupModel model, SavePermissionGroupResult parentResult, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            var result = new SavePermissionGroupResult();
            await SaveAsync(model, result, connection, transaction, cancellationToken);
            parentResult.SubGroups.Add(result);
        }

        private async Task DeleteSubGroupsAsync(IList<DeletePermissionGroupModel> models, SavePermissionGroupResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (models != null && models.Count > 0)
                foreach (var model in models)
                    await DeleteSubGroupAsync(model, result, connection, transaction, cancellationToken);
        }

        private async Task DeleteSubGroupAsync(DeletePermissionGroupModel model, SavePermissionGroupResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (await _deletePermissionGroupQuery.ExecuteAsync(model, connection, transaction, cancellationToken))
                result.DeletedSubGroupIds.Add(model.Id);
        }
    }
}
