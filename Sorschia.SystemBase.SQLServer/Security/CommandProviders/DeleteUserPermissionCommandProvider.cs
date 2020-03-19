using Sorschia.SystemBase.Data;
using Sorschia.SystemBase.Security.ParameterProviders;
using System.Data.SqlClient;

namespace Sorschia.SystemBase.Security.CommandProviders
{
    internal sealed class DeleteUserPermissionCommandProvider
    {
        public DeleteUserPermissionCommandProvider(ICurrentSessionProvider currentSessionProvider, DeleteUserPermissionParameterProvider parameterProvider)
        {
            _currentSessionProvider = currentSessionProvider;
            _parameterProvider = parameterProvider;
        }

        private readonly ICurrentSessionProvider _currentSessionProvider;
        private readonly DeleteUserPermissionParameterProvider _parameterProvider;

        public SqlCommand Get(long id, SqlConnection connection, SqlTransaction transaction) =>
            connection.CreateProcedureCommand(StoredProcedures.Security.DeleteUserPermission, transaction)
            .AddInParameter(_parameterProvider.Id, id)
            .AddSessionIdParameter(_currentSessionProvider);
    }
}
