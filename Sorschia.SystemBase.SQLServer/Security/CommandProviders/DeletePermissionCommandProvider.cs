using Sorschia.SystemBase.Data;
using Sorschia.SystemBase.Security.ParameterProviders;
using Sorschia.SystemBase.Security.Processes;
using System.Data.SqlClient;

namespace Sorschia.SystemBase.Security.CommandProviders
{
    internal sealed class DeletePermissionCommandProvider
    {
        public DeletePermissionCommandProvider(ICurrentSessionProvider currentSessionProvider, DeletePermissionParameterProvider parameterProvider)
        {
            _currentSessionProvider = currentSessionProvider;
            _parameterProvider = parameterProvider;
        }

        private readonly ICurrentSessionProvider _currentSessionProvider;
        private readonly DeletePermissionParameterProvider _parameterProvider;

        public SqlCommand Get(DeletePermissionModel model, SqlConnection connection, SqlTransaction transaction = default) =>
            connection.CreateProcedureCommand(StoredProcedures.Security.DeletePermission, transaction)
            .AddInParameter(_parameterProvider.Id, model.Id)
            .AddSessionIdParameter(_currentSessionProvider);
    }
}
