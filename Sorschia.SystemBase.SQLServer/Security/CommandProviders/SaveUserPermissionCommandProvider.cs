using Sorschia.SystemBase.Data;
using Sorschia.SystemBase.Security.Entities;
using Sorschia.SystemBase.Security.ParameterProviders;
using System.Data.SqlClient;

namespace Sorschia.SystemBase.Security.CommandProviders
{
    internal sealed class SaveUserPermissionCommandProvider
    {
        public SaveUserPermissionCommandProvider(ICurrentSessionProvider currentSessionProvider, SaveUserPermissionParameterProvider parameterProvider)
        {
            _currentSessionProvider = currentSessionProvider;
            _parameterProvider = parameterProvider;
        }

        private readonly ICurrentSessionProvider _currentSessionProvider;
        private readonly SaveUserPermissionParameterProvider _parameterProvider;

        public SqlCommand Get(SystemUserPermission userPermission, SqlConnection connection, SqlTransaction transaction) =>
            connection.CreateProcedureCommand(StoredProcedures.Security.SaveUserPermission, transaction)
            .AddInParameter(_parameterProvider.Id, userPermission.Id, _parameterProvider.Id_Type)
            .AddInParameter(_parameterProvider.UserId, userPermission.UserId)
            .AddInParameter(_parameterProvider.PermissionId, userPermission.PermissionId)
            .AddInParameter(_parameterProvider.IsApproved, userPermission.IsApproved)
            .AddSessionIdParameter(_currentSessionProvider);
    }
}
