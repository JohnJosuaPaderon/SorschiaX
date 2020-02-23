using Sorschia.SystemBase.Security.Entities;
using Sorschia.SystemBase.Security.ParameterProviders;
using System.Data.SqlClient;

namespace Sorschia.SystemBase.Security.CommandProviders
{
    internal sealed class SaveUserPermissionCommandProvider
    {
        public SaveUserPermissionCommandProvider(ICurrentUserProvider currentUserProvider, SaveUserPermissionParameterProvider parameterProvider)
        {
            _currentUserProvider = currentUserProvider;
            _parameterProvider = parameterProvider;
        }

        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly SaveUserPermissionParameterProvider _parameterProvider;

        public SqlCommand Get(SystemUserPermission userPermission, SqlConnection connection, SqlTransaction transaction) =>
            connection.CreateProcedureCommand(StoredProcedures.Security.SaveUserPermission, transaction)
            .AddInParameter(_parameterProvider.Id, userPermission.Id, _parameterProvider.Id_Type)
            .AddInParameter(_parameterProvider.UserId, userPermission.UserId)
            .AddInParameter(_parameterProvider.PermissionId, userPermission.PermissionId)
            .AddInParameter(_parameterProvider.IsApproved, userPermission.IsApproved)
            .AddInParameter(_parameterProvider.SavedBy, _currentUserProvider.GetUsername());
    }
}
